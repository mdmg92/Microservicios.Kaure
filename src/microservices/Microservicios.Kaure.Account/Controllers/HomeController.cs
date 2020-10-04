using Microsoft.AspNetCore.Mvc;

namespace Microservicios.Kaure.Account.Controllers
{
    [Route("ping")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok();
    }
}