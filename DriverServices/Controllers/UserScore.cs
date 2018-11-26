using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverServices.Controllers
{
    /// <summary>
    /// 用户考试成绩
    /// </summary>
    public class UserScore
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { set; get; }

        /// <summary>
        /// 考试类型 1客运2普货3危货
        /// </summary>
        public int ExamType { set; get; }

        /// <summary>
        /// 考试成绩
        /// </summary>
        public decimal Score { set; get; }

        /// <summary>
        /// 考试时间
        /// </summary>
        public DateTime ExamTime { set; get; }
    }
}
