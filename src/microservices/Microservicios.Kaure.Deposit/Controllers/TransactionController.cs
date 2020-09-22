using System;
using Microservicios.Kaure.Cross.RabbitMQ.Bus;
using Microservicios.Kaure.Deposit.DTOs;
using Microservicios.Kaure.Deposit.RabbitMQ.Commands;
using Microservicios.Kaure.Deposit.Services;
using Microsoft.AspNetCore.Mvc;

namespace Microservicios.Kaure.Deposit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IEventBus _bus;

        public TransactionController(
            ITransactionService transactionService,
            IEventBus bus)
        {
            _transactionService = transactionService;
            _bus = bus;
        }

        [HttpPost("Deposit")]
        public IActionResult Deposit([FromBody] TransactionRequest request)
        {
            var transaction = new Models.Transaction
            {
                AccountId = request.AccountId,
                Amount = request.Amount,
                CreationDate = DateTime.Now.ToShortDateString(),
                Type = "Deposit"
            };
            _transactionService.Deposit(transaction);
            
            _bus.SendCommand(new DepositCreateCommand(
                idTransaction: transaction.Id,
                amount: transaction.Amount,
                type: transaction.Type,
                creationDate: transaction.CreationDate,
                accountId: transaction.AccountId));

            _bus.SendCommand(new NotificateTransactionCommand()
            {
                AccountId = transaction.AccountId,
                SendDate = transaction.CreationDate
            });

            return Ok();
        }
    }
}
