using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightOAuth2.Service.Dtos
{
    public class GetUserInfoResponse
    {
        /// <summary>
        /// 用户唯一ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string? NickName { get; set; }

        /// <summary>
        /// 性别 0 男 1 女
        /// </summary>
        public int? Sex { get; set; }

        public string? Province { get; set; }

        public string? City { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string? Avator { get; set; }

        /// <summary>
        /// 用户权限 用逗号,分开
        /// </summary>
        public string? Privilege { get; set; }
    }
}
