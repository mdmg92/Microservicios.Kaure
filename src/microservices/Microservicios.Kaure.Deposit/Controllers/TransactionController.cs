using System;
using Microservicios.Kaure.Deposit.DTOs;
using Microservicios.Kaure.Deposit.Services;
using Microsoft.AspNetCore.Mvc;

namespace Microservicios.Kaure.Deposit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
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

            return Ok();
        }
    }
}
