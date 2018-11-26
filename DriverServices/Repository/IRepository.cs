using DriverServices.Common;
using DriverServices.Controllers;
using DriverServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverServices.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// 手机号密码登录网站
        /// </summary>
        /// <param name="contactNo"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        List<UserInfo> UserInfoQuery(string contactNo, string password);

        /// <summary>
        /// 用户微信绑定
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Result<dynamic> UserBind(UserInfo user);

        /// <summary>
        /// 用户微信解绑
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        int UserUnBind(string openId);

        /// <summary>
        /// 根据微信openid获取用户信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        Result<List<UserInfo>> UserInfoQueryByWeixinId(string openId);

        /// <summary>
        /// 用户收藏考题
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Result<List<Exam>> UserCollectExamQuery(string userId, string type);

        /// <summary>
        /// 用户错题
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Result<List<Exam>> UserErrorExamQuery(string userId, string type);

        /// <summary>
        /// 用户历史考试成绩
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Result<List<UserScore>> UserScoreQuery(string userId, string type, int pageIndex, int pageSize);

        #region 练习

        /// <summary>
        /// 考题收藏
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="ExamId"></param>
        /// <param name="ExamType"></param>
        /// <returns></returns>
        Result<dynamic> CollectExam(string UserId, string ExamId, string ExamType);

        /// <summary>
        /// 错题记录
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="ExamId"></param>
        /// <param name="ExamType"></param>
        /// <returns></returns>
        Result<dynamic> SaveErrorExam(string UserId, string ExamId, string ExamType);
        #endregion

        #region 模拟考试
        /// <summary>
        /// 考试抽题
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        Result<List<Exam>> ExamQuery(string type);

        /// <summary>
        /// 交卷
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="type"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        int SubmitExam(string userId, string type, decimal score);
        #endregion
    }
}
