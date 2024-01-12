using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LightOAuth2.Server.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage ="用户名不能为空")]
        public string Username { get; set; }
        [Required(ErrorMessage ="密码不能为空")]
        public string Password { get; set; }
    }
}
