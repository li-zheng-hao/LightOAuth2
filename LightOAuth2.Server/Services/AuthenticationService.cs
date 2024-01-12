using Blazored.LocalStorage;
using Microsoft.Extensions.ObjectPool;
using System.Security.Claims;
using System.Text;

namespace LightOAuth2.Server.Services
{
    public class AuthenticationService
    {
        private ILocalStorageService _storageService;

        public AuthenticationService(ILocalStorageService storageService)
        {
            _storageService = storageService;
        }

    

        public async Task<string> SignInAsync(Claim[] claims)
        {
            var token = GenerateToken(claims);
            await _storageService.SetItemAsync("token", token);
            return token;

        }
        public async Task SignOutAsync()
        {
            await _storageService.RemoveItemAsync("token");

        }
        public async Task<bool> IsLoginAsync()
        {
            var res = await _storageService.GetItemAsync<string>("token");
            return ValidateToken(res);
        }
        /// <summary>
        /// 生成token
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        private string GenerateToken(Claim[] claims)
        {
            return "123";
        }

        private bool ValidateToken(string token)
        {
            return token == "123";
        }

     
    }
}
