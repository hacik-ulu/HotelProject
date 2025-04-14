using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Models;

namespace WebApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly CreateToken _createToken;
        public TokenController(CreateToken createToken)
        {
            _createToken = createToken;
        }

        [HttpGet("[action]")]
        public IActionResult GenerateToken()
        {
            var token = _createToken.TokenCreate();
            return Ok(new { Token = token });
        }

        
        [HttpGet("[action]")]
        public IActionResult GenerateTokenAdmin()
        {
            var token = _createToken.TokenCreateAdmin();
            return Ok(new { Token = token });
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult Test()
        {
            return Ok("Hoşgeldiniz");
        }

        [Authorize(Roles ="Admin,Visitor")]
        [HttpGet("[action]")]
        public IActionResult AdminTest()
        {
            return Ok("Token başarılı şekilde giriş yaptı");
        }


    }
}
