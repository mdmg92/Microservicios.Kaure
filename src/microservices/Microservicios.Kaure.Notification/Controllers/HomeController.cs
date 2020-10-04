using Microsoft.AspNetCore.Mvc;

namespace Microservicios.Kaure.Notification.Controllers
{
    [Route("ping")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok();
    }
}