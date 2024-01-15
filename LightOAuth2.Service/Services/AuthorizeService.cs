using AngleSharp.Dom;
using LightOAuth2.Service;
using LightOAuth2.Service.Dtos;
using LightOAuth2.Service.Services;
using System.Security.Claims;

namespace LightOAuth2.Server.Services
{
    public class AuthorizeService(CookieSimulateService cookieSimulateService, UserService userService)

    {
        private readonly CookieSimulateService cookieSimulateService = cookieSimulateService;
        private readonly UserService userService = userService;

        public UnifyResult<GetAccessTokenResponse> GetUserTicket(string code, string clientId, string clientSecret)
        {
            if (code != "test_code" || clientId != "test" || clientSecret != "test")
            {
                return UnifyResult<GetAccessTokenResponse>.Fail(40001, "数据不正确");
            }
            else
            {
                var data = new GetAccessTokenResponse()
                {
                    AccessToken = "access_token",
                    RefreshToken = "refresh_token",
                    ExpiresIn = 7200
                };
                return UnifyResult<GetAccessTokenResponse>.Success(data);
            }
        }

        public async Task<bool> IsLoginAsync()
        {
            var res = await cookieSimulateService.GetAsync<string>("token");
            return ValidateToken(res);
        }

        public UnifyResult<GetAccessTokenResponse> ReGenerateUserTicket(string refreshToken, string clientId, string clientSecret)
        {
            if (refreshToken != "refresh_token" || clientId != "test" || clientSecret != "test")
            {
                return UnifyResult<GetAccessTokenResponse>.Fail(40001, "数据不正确");
            }
            else
            {
                var data = new GetAccessTokenResponse()
                {
                    AccessToken = "access_token",
                    RefreshToken = "refresh_token",
                    ExpiresIn = 7200
                };
                return UnifyResult<GetAccessTokenResponse>.Success(data);
            }
        }

        public UnifyResult ValidateAccessToken(string accessToken)
        {
            return accessToken == "access_token" ? UnifyResult.Success() : UnifyResult.Fail("accessToken无效");
        }

        private bool ValidateToken(string? token)
        {
            return token == "123";
        }

    }
}
