using LightOAuth2.Server.Services;
using LightOAuth2.Service;
using LightOAuth2.Service.Dtos;
using LightOAuth2.Service.Services;
using LightOAuth2.Service.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LightOAuth2.Server.Controllers
{
    [Route("connect/oauth2")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private AuthorizeService _authorizeService;
        private UserService _userService;
        private readonly AuthenticationService authenticationService;

        public AuthorizeController(AuthorizeService authorizeService, UserService userService,AuthenticationService authenticationService)
        {
            _authorizeService = authorizeService;
            _userService = userService;
            this.authenticationService = authenticationService;
        }

        /// <summary>
        /// 通过code获取accessToken
        /// </summary>
        /// <param name="code"></param>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        [HttpGet("access_token"),ResponseCache(Duration =60)]
        public IActionResult GetToken([FromQuery]string code, [FromQuery]string clientId, [FromQuery]string clientSecret)
        {
            UnifyResult<GetAccessTokenResponse> resp = _authorizeService.GetUserTicket(code, clientId, clientSecret);
            if (resp.IsSuccess)
            {
                return Ok(resp.Data);
            }
            else
            {
                return Ok(resp);
            }
        }


        /// <summary>
        /// 刷新Token
        /// </summary>
        /// <param name="code"></param>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        [HttpGet("refresh_token"), ResponseCache(Duration = 60)]
        public IActionResult RefreshAccessToken([FromQuery] string refreshToken, [FromQuery] string clientId, [FromQuery] string clientSecret)
        {
            UnifyResult<GetAccessTokenResponse> resp = _authorizeService.ReGenerateUserTicket(refreshToken, clientId, clientSecret);
            if (resp.IsSuccess)
            {
                return Ok(resp.Data);
            }
            else
            {
                return Ok(resp);
            }
        }


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("user_info"), ResponseCache(Duration = 60)]
        public IActionResult GetUserInfo([FromQuery] string accessToken, [FromQuery] int userId)
        {
            
            UnifyResult validateResult = _authorizeService.ValidateAccessToken(accessToken);

            if(!validateResult.IsSuccess) return Ok(validateResult);

            UnifyResult<GetUserInfoResponse> result= _userService.GetUserInfo(userId);

            if(!result.IsSuccess) return Ok(result);

            return Ok(result.Data);
        }
    }
}
