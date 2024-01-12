using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using System.Security.Claims;

namespace LightOAuth2.Server.Services
{
    public class UserService(AuthenticationService authenticationService)
    {

        public async Task<bool> Login(string userName,string password)
        {
            if (userName == "admin" && password == "admin")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,"admin"),
                };

         
                await authenticationService.SignInAsync(claims.ToArray());

                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据accessToken获取用户信息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public string GetUserInfo(string accessToken)
        {
            return "12";
        }
    }
}
