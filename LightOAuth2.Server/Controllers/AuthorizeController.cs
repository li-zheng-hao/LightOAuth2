using LightOAuth2.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LightOAuth2.Server.Controllers
{
    [Route("api/authorize")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private AuthorizeService _authorizeService;
        private UserService _userService;

        public AuthorizeController(AuthorizeService authorizeService, UserService userService)
        {
            _authorizeService = authorizeService;
            _userService = userService;
        }

    }
}
