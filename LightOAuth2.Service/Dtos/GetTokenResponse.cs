using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightOAuth2.Service.ViewModels
{
    public class GetTokenResponse
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

    }
}
