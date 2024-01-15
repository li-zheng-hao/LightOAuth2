using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightOAuth2.Service.Dtos
{
    public class GetAccessTokenResponse
    {
       
        public string AccessToken { get; set; }

      
        public string RefreshToken { get; set; }

        /// <summary>
        /// 超时 秒
        /// </summary>
        public int ExpiresIn { get; set; }

    }
}
