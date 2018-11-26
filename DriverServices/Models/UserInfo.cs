using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverServices.Models
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string  ContactNo { set; get; }

        /// <summary>
        /// 微信openid
        /// </summary>
        public string WeiId { set; get; }

        /// <summary>
        /// 微信昵称
        /// </summary>
        public string WeiName { set; get; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { set; get; }

        /// <summary>
        /// 是否有效 0有效1无效
        /// </summary>
        public int  Scbz { set; get; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegistTime { set; get; }
       
    }
}
