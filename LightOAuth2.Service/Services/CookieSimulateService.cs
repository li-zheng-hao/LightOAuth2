using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightOAuth2.Service.Services
{
    /// <summary>
    /// 模拟Cookie操作
    /// </summary>
    public class CookieSimulateService(ILocalStorageService localStorageService)
    {
        public ILocalStorageService LocalStorageService { get; } = localStorageService;


        public async Task SetAsync<T>(string key, T value, TimeSpan expire)
        {
            await LocalStorageService.SetItemAsync(key, new CookieWrapper<T>
            {
                Value = value,
                Expire = DateTimeOffset.Now.Add(expire).ToUnixTimeSeconds()
            });
        }

        public async Task<bool> RefreshAsync(string key, TimeSpan expire)
        {
            var item = await LocalStorageService.GetItemAsync<CookieWrapper<dynamic>>(key);
            if (item == null || item.Expire < DateTimeOffset.Now.ToUnixTimeSeconds())
                return false;
            item.Expire = DateTimeOffset.Now.Add(expire).ToUnixTimeSeconds();
            await LocalStorageService.SetItemAsync(key, item);
            return true;
        }

        public async Task Remove(string key)
        {
             await LocalStorageService.RemoveItemAsync(key);
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var item = await LocalStorageService.GetItemAsync<CookieWrapper<T>>(key);
            if (item==null||item.Expire < DateTimeOffset.Now.ToUnixTimeSeconds())
                return default;
            return item.Value;
        }
    }

    public class CookieWrapper<T>
    {
        public required T Value { get; set; }
        public long Expire { get; set; }
    }
}
