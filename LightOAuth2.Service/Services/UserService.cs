using LightOAuth2.Service.Dtos;
using LightOAuth2.Service;
using LightOAuth2.Service.Services;
using System.Security.Claims;

namespace LightOAuth2.Server.Services
{
    public class UserService(AuthenticationService authenticationService)
    {

        public async Task<bool> Login(string userName, string password)
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

        public UnifyResult<GetUserInfoResponse> GetUserInfo(int userId)
        {
            if (userId == 1)
            {   
                var data = new GetUserInfoResponse()
                {
                    UserId = 1,
                    Avator = "https://xxxxx.jpg",
                    Sex=0,
                    NickName="admin",
                    Privilege="admin,user"
                };
                return UnifyResult<GetUserInfoResponse>.Success(data);
            }
            else
            {
                return UnifyResult<GetUserInfoResponse>.Fail(40001, "用户不存在");
            }
        }
    }
}
