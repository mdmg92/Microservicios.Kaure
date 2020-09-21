using System.Linq;
using Microservicios.Kaure.Account.DTOs;
using Microservicios.Kaure.Account.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Microservicios.Kaure.Account.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_accountService.GetAll());

        [HttpPost("Deposit")]
        public IActionResult Deposit([FromBody] AccountRequest request)
        {
            var result = _accountService.GetAll().FirstOrDefault(x => x.IdAccount == request.IdAccount);
            var account = new Models.Account()
            {
                IdAccount = request.IdAccount,
                IdCustomer = result.IdCustomer,
                TotalAmount = result.TotalAmount + request.Amount,
                Customer = result.Customer
            };

            _accountService.Deposit(account);

            return Ok();
        }

        [HttpPost("Withdrawal")]
        public IActionResult Withdrawal([FromBody] AccountRequest request)
        {
            var result = _accountService
                .GetAll()
                .FirstOrDefault(x => x.IdAccount == request.IdAccount);
            if (result.TotalAmount < request.Amount)
            {
                return BadRequest(new { message = "The indicated amount cannot be withdrawal" });
            }

            var account = new Models.Account()
            {
                IdAccount = request.IdAccount,
                IdCustomer = result.IdCustomer,
                TotalAmount = result.TotalAmount - request.Amount,
                Customer = result.Customer
            };
            _accountService.Withdrawal(account);

            return Ok();
        }
    }
}
