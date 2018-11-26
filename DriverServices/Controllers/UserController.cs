using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriverServices.Common;
using DriverServices.Models;
using DriverServices.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DriverServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// 仓储类
        /// </summary>
        private IRepository _repository = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        public UserController(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 微信用户绑定
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public Result<dynamic> UserLogin(UserInfo user)
        {
            return _repository.UserBind(user);
        }

        /// <summary>
        /// 根据微信openid查询用户信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        [HttpGet("Query")]
        public Result<List<UserInfo>> UserInfoQueryByWxId(string openId)
        {
            return _repository.UserInfoQueryByWeixinId(openId);
        }

        /// <summary>
        /// 微信解绑
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        [HttpPost("UnBind")]
        public Result<dynamic> UserUnBind(string openId)
        {
            if (_repository.UserUnBind(openId) > 0)
            {
                Result<dynamic> result = new Result<dynamic>();
                result.Success = true;
                return result;
            }
            else
            {
                Result<dynamic> result = new Result<dynamic>();
                result.Success = false;
                result.Message = "解绑失败";
                return result;
            }
        }

        /// <summary>
        /// 我的收藏
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="type">考试类型1客运2普货3危货</param>
        /// <returns></returns>
        [HttpGet("CollectQuery")]
        public Result<List<Exam>> UserCollectExamQuery(string userId, string type)
        {
            return _repository.UserCollectExamQuery(userId, type);
        }

        /// <summary>
        /// 我的错题
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="type">考试类型1客运2普货3危货</param>
        /// <returns></returns>
        [HttpGet("ErrorQuery")]
        public Result<List<Exam>> UserErrorExamQuery(string userId, string type)
        {
            return _repository.UserErrorExamQuery(userId, type);
        }

        /// <summary>
        /// 历次考试成绩查询
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="type">考试类型1客运2普货3危货</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页显示的记录条数</param>
        /// <returns></returns>
        [HttpGet("ScoreQuery")]
        public Result<List<UserScore>> UserScoreQuery(string userId, string type, int pageIndex, int pageSize)
        {
            return _repository.UserScoreQuery(userId, type, pageIndex, pageSize);
        }
    }
}