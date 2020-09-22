using System;
using System.Threading.Tasks;
using Microservicios.Kaure.Cross.Proxy.Http;
using Microservicios.Kaure.Deposit.DTOs;
using Microservicios.Kaure.Deposit.Models;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.CircuitBreaker;

namespace Microservicios.Kaure.Deposit.Services
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly ITransactionService _service;
        private readonly IHttpClient _httpClient;

        public AccountService(
            IConfiguration configuration,
            ITransactionService service,
            IHttpClient httpClient)
        {
            _configuration = configuration;
            _service = service;
            _httpClient = httpClient;
        }

        public async Task<bool> DepositAccount(AccountRequest request)
        {
            var url = _configuration["proxy:urlAccountDeposit"];
            var response = await _httpClient.PostAsync(url, request);
            response.EnsureSuccessStatusCode();

            return true;
        }

        public bool DepositReverse(Transaction request)
        {
            _service.DepositReverse(request);

            return true;
        }

        public bool Execute(Transaction request)
        {
            var response = false;

            var circuitBreakerPolicy = Policy.Handle<Exception>().
                CircuitBreaker(3, TimeSpan.FromSeconds(15),
                    onBreak: (ex, timespan, context) =>
                    {
                        Console.WriteLine("El circuito entró en estado de falla");
                    }, onReset: (context) =>
                    {
                        Console.WriteLine("Circuito dejó estado de falla");
                    });

            var retry = Policy.Handle<Exception>()
                .WaitAndRetryForever(attemp => TimeSpan.FromMilliseconds(300))
                .Wrap(circuitBreakerPolicy);

            retry.Execute(() =>
            {
                if (circuitBreakerPolicy.CircuitState == CircuitState.Closed)
                {
                    circuitBreakerPolicy.Execute(() =>
                    {
                        var account = new AccountRequest
                        {
                            Amount = request.Amount,
                            IdAccount = request.AccountId
                        };
                        response = DepositAccount(account).Result;
                        Console.WriteLine("Solicitud realizada con éxito");
                    });
                }

                if (circuitBreakerPolicy.CircuitState != CircuitState.Closed)
                {
                    var transaction = new Transaction()
                    {
                        AccountId = request.AccountId,
                        Amount = request.Amount,
                        CreationDate = DateTime.Now.ToShortDateString(),
                        Type = "Deposit"
                    };
                    response = DepositReverse(transaction);
                    response = false;
                }
            });

            return response;
        }
    }
}