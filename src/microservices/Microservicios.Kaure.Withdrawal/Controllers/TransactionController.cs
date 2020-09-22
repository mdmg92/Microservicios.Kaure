using System;
using Microservicios.Kaure.Cross.RabbitMQ.Bus;
using Microservicios.Kaure.Withdrawal.DTOs;
using Microservicios.Kaure.Withdrawal.Models;
using Microservicios.Kaure.Withdrawal.RabbitMQ.Commands;
using Microservicios.Kaure.Withdrawal.Service;
using Microsoft.AspNetCore.Mvc;

namespace Microservicios.Kaure.Withdrawal.Controllers
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

        [HttpPost("Withdrawal")]
        public IActionResult Withdrawal([FromBody] TransactionRequest request)
        {
            var transaction = new Transaction()
            {
                AccountId = request.AccountId,
                Amount = request.Amount,
                CreationDate = DateTime.Now.ToShortDateString(),
                Type = "Withdrawal"
            };
            _transactionService.Withdrawal(transaction);

            _bus.SendCommand(new WithdrawalCreateCommand(
                idTransaction: transaction.Id,
                amount: transaction.Amount,
                type: transaction.Type,
                creationDate: transaction.CreationDate,
                accountId: transaction.AccountId));

            return Ok();
        }
    }
}
