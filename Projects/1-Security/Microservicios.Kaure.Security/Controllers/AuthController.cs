using Microservicios.Kaure.Cross.Jwt;
using Microservicios.Kaure.Security.DTOs;
using Microservicios.Kaure.Security.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Microservicios.Kaure.Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtOptions _configuration;
        private readonly IAccessService _accessService;

        public AuthController(IOptionsSnapshot<JwtOptions> configuration,  IAccessService accessService)
        {
            _configuration = configuration.Value;
            _accessService = accessService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_accessService.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody]AuthRequest request)
        {
            if (!_accessService.Validate(request.Username, request.Password))
            {
                return Unauthorized();
            }

            Response.Headers.Add("access-control-expose-headers", "Authorization");
            Response.Headers.Add("Authorization", $"Bearer {JwtToken.Create(_configuration)}");

            return Ok();
        }
    }
}
