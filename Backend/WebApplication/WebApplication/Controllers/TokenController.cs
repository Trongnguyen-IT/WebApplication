using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using T.Core.Shared;
using T.Host.Token;

namespace T.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthentication authentication;

        public TokenController(IAuthentication authentication)
        {
            this.authentication = authentication;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ApiExcuteResult> Authenticate([FromBody]AuthenticateModel userParam)
        {
            var result = await authentication.Authenticate(userParam.UserNameOrEmailAddress, userParam.Password);
            return result;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = authentication.GetAll();
            return Ok(users);
        }
    }
}