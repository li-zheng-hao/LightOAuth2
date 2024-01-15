using Blazored.LocalStorage;
using System.Security.Claims;
using System.Text;

namespace LightOAuth2.Service.Services
{
    public class AuthenticationService
    {
        private readonly CookieSimulateService cookieSimulateService;

        public AuthenticationService(CookieSimulateService cookieSimulateService)
        {
            this.cookieSimulateService = cookieSimulateService;
        }

        public string GenerateCode()
        {
            // todo 这里缓存在redis中，设置过期时间为5分钟
            return "test_code";
        }

        public async Task<string> SignInAsync(Claim[] claims)
        {
            var token = GenerateToken(claims);
            
            await cookieSimulateService.SetAsync<string>("token", token,TimeSpan.FromDays(7));
            return token;

        }
        public async Task SignOutAsync()
        {
            await cookieSimulateService.Remove("token");

        }
   
        /// <summary>
        /// 生成token
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        private string GenerateToken(Claim[] claims)
        {
            // todo 生成一个token，在缓存中存5分钟
            return "123";
        }



    }
}
