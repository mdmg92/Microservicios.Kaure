using System;
using Microservicios.Kaure.Withdrawal.DTOs;
using Microservicios.Kaure.Withdrawal.Models;
using Microservicios.Kaure.Withdrawal.Service;
using Microsoft.AspNetCore.Mvc;

namespace Microservicios.Kaure.Withdrawal.Controllers
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

            return Ok();
        }
    }
}
