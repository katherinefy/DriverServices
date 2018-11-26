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
    /// <summary>
    /// 考试相关
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        /// <summary>
        /// 仓储类
        /// </summary>
        private IRepository _repository = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        public ExamController(IRepository repository)
        {
            _repository = repository;
        } 

        /// <summary>
        /// 模拟考试抽题
        /// </summary>
        /// <param name="type">1客运2普货3危货</param>
        /// <returns></returns>
        [HttpGet("ExamQuery")]
        public Result<List<Exam>> ExamQuery(string type)
        {
            return _repository.ExamQuery(type);
        }

        /// <summary>
        /// 提交试卷
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="type"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        [HttpPost("Submit")]
        public Result<dynamic> SubmitExam(string userId, string type,decimal score)
        {
            if (_repository.SubmitExam(userId, type, score) > 0)
            {
                Result<dynamic> result = new Result<dynamic>();
                result.Success = true;
                return result;
            }
            else
            {
                Result<dynamic> result = new Result<dynamic>();
                result.Success = false;
                result.Message = "提交试卷失败，请稍后再试";
                return result;
            }
        }
    }
}