using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriverServices.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DriverServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        /// <summary>
        /// 微信接口认证  只需要执行一次
        /// </summary>
        /// <returns></returns>
        [HttpGet("WeiAuthorize")]
        public int WeiAuthorize()
        {
            string accessToken = "HelloTestCYStudy";
            LogHelper.WriteLog(accessToken);
            return 0;
        }
    }
}