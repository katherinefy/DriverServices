using Chloe;
using Chloe.SqlServer;
using DriverServices.Common;
using DriverServices.Controllers;
using DriverServices.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DriverServices.Repository
{
    /// <summary>
    /// 数据库操作
    /// </summary>
    public class SqlRepository : IRepository
    {
        private string _connection = string.Empty;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="connection">连接字串</param>
        public SqlRepository(string connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// 手机号密码登录
        /// </summary>
        /// <param name="contactNo"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public List<UserInfo> UserInfoQuery(string contactNo, string password)
        {
            string cmdString = string.Format("select * from UserInfo where  contactNo='{0}' and Password='{1}' ", contactNo, password);
            MsSqlContext context = new MsSqlContext(_connection);
            List<UserInfo> userinfo = context.SqlQuery<UserInfo>(cmdString).ToList();

            Result<List<UserInfo>> result = new Result<List<UserInfo>>();
            result.Success = true;
            result.Data = userinfo;
            result.Total = userinfo.Count;

            return userinfo;
        }

        /// <summary>
        /// 微信绑定
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Result<dynamic> UserBind(UserInfo user)
        {
            MsSqlContext context = new MsSqlContext(_connection);

            DbParam[] dbParams = new DbParam[] {
                new DbParam("@Name", user.Name),
                new DbParam("@WeiId", user.WeiId),
                new DbParam("@WeiName", user.WeiName),
                new DbParam("@ContactNo", user.ContactNo),
                new DbParam("@Errmsg","",typeof(string)) { Direction = ParamDirection.Output }
            };
            int tag = context.Session.ExecuteNonQuery("P_UserBind", CommandType.StoredProcedure, dbParams);
            Result<dynamic> result = new Result<dynamic>();

            if (tag <= 0)
            {
                switch (dbParams[4].Value)
                {
                    case "2":
                        result.Success = false;
                        result.Message = "手机号已经在其它微信上绑定";
                        break;
                }
            }
            else
            {
                result.Success = true;
            }
            return result;
        }

        /// <summary>
        /// 微信解绑
        /// </summary>      
        /// <param name="openId"></param>
        /// <returns></returns>
        public int UserUnBind(string openId)
        {
            MsSqlContext context = new MsSqlContext(_connection);
            string cmdString = string.Format(" update UserInfo set WeiId =null where WeiId= '{0}' and scbz = 0 ", openId);
            return context.Session.ExecuteNonQuery(cmdString);
        }

        /// <summary>
        /// 根据微信openid获取用户信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public Result<List<UserInfo>> UserInfoQueryByWeixinId(string openId)
        {
            string cmdString = string.Format("select * from UserInfo where   WeiId='{0}' ", openId);
            MsSqlContext context = new MsSqlContext(_connection);
            List<UserInfo> userinfo = context.SqlQuery<UserInfo>(cmdString).ToList();

            Result<List<UserInfo>> result = new Result<List<UserInfo>>();
            result.Success = true;
            result.Data = userinfo;
            result.Total = userinfo.Count;
            return result;
        }

        /// <summary>
        /// 用户收藏考试查询
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public Result<List<Exam>> UserCollectExamQuery(string userId, string type)
        {
            string cmdString = string.Format("select * from CollectRecord where   userId='{0}' and ExamType='{1}' ", userId, type);
            MsSqlContext context = new MsSqlContext(_connection);
            List<Exam> data = context.SqlQuery<Exam>(cmdString).ToList();

            Result<List<Exam>> result = new Result<List<Exam>>();
            result.Success = true;
            result.Data = data;
            result.Total = data.Count;
            return result;
        }

        /// <summary>
        /// 用户错题查询
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public Result<List<Exam>> UserErrorExamQuery(string userId, string type)
        {
            string cmdString = string.Format("select * from ErrorRecord where   userId='{0}' and ExamType='{1}' ", userId, type);
            MsSqlContext context = new MsSqlContext(_connection);
            List<Exam> data = context.SqlQuery<Exam>(cmdString).ToList();

            Result<List<Exam>> result = new Result<List<Exam>>();
            result.Success = true;
            result.Data = data;
            result.Total = data.Count;
            return result;
        }

        /// <summary>
        /// 历史考试成绩
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public Result<List<UserScore>> UserScoreQuery(string userId, string type, int pageIndex, int pageSize)
        {
            string cmdString = string.Format("select * from UserScore where   userId='{0}'", userId);
            MsSqlContext context = new MsSqlContext(_connection);
            if (!string.IsNullOrEmpty(type))
            {
                cmdString += " and ExamType='" + type.ToString() + "'";
            }
            cmdString += " order by ExamTime desc ";
            List<UserScore> data = context.SqlQuery<UserScore>(cmdString)
                                                     .Skip(pageIndex * pageSize)
                                                     .Take(pageSize)
                                                     .ToList();
            Result<List<UserScore>> result = new Result<List<UserScore>>();
            result.Success = true;
            result.Data = data;
            result.Total = data.Count;
            return result;
        }

        #region 练习

        /// <summary>
        /// 收藏题目
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="ExamId"></param>
        /// <param name="ExamType"></param>
        /// <returns></returns>
        public Result<dynamic> CollectExam(string UserId, string ExamId, string ExamType)
        {
            MsSqlContext context = new MsSqlContext(_connection);
            DbParam[] dbParams = new DbParam[] {
                new DbParam("@UserId", UserId),
                new DbParam("@ExamId", ExamId),
                new DbParam("@ExamType", ExamType)
            };
            int tag = context.Session.ExecuteNonQuery("P_CollectExam", CommandType.StoredProcedure, dbParams);
            Result<dynamic> result = new Result<dynamic>();
            if (tag > 0)
            {
                result.Success = true;
            }
            else
            {
                result.Success = false;
                result.Message = "收藏失败";
            }
            return result;
        }

        /// <summary>
        /// 错题记录
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="ExamId"></param>
        /// <param name="ExamType"></param>
        /// <returns></returns>
        public Result<dynamic> SaveErrorExam(string UserId, string ExamId, string ExamType)
        {
            MsSqlContext context = new MsSqlContext(_connection);
            DbParam[] dbParams = new DbParam[] {
                new DbParam("@UserId", UserId),
                new DbParam("@ExamId", ExamId),
                new DbParam("@ExamType", ExamType)
            };
            int tag = context.Session.ExecuteNonQuery("P_SaveErrorExam", CommandType.StoredProcedure, dbParams);
            Result<dynamic> result = new Result<dynamic>();
            if (tag > 0)
            {
                result.Success = true;
            }
            else
            {
                result.Success = false;
                result.Message = "错题记录失败";
            }
            return result;
        }


        #endregion


        #region 模拟考试
        /// <summary>
        /// 考试抽题
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Result<List<Exam>> ExamQuery(string type)
        {
            MsSqlContext context = new MsSqlContext(_connection);
            DbParam dbParams = new DbParam("@type", type);
            List<Exam> data = context.SqlQuery<Exam>("P_GetExamDatabase", CommandType.StoredProcedure, dbParams).ToList();
            Result<List<Exam>> result = new Result<List<Exam>>();
            result.Success = true;
            result.Data = data;
            result.Total = data.Count;
            return result;
        }

        /// <summary>
        /// 交卷
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="type"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public int SubmitExam(string userId, string type, decimal score)
        {
            MsSqlContext context = new MsSqlContext(_connection);
            string cmdString = string.Format("  insert into UserScore(UserId,ExamType,Score,ExamTime)values('{0}','{1}','{2}',getdate()) ", userId,type,score);
            return context.Session.ExecuteNonQuery(cmdString);
        }
        #endregion
    }

}