using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverServices.Models
{
    /// <summary>
    /// 考题
    /// </summary>
    public class Exam
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// 目录
        /// </summary>
        public string Directory { set; get; }

        /// <summary>
        /// 题干
        /// </summary>
        public string Title { set; get; }

        /// <summary>
        /// 类型1单选2多选3判断
        /// </summary>
        public string Type { set; get; }

        /// <summary>
        /// 选项A
        /// </summary>
        public string OptionA { set; get; }

        /// <summary>
        /// 选项B
        /// </summary>
        public string OptionB { set; get; }

        /// <summary>
        /// 选项C
        /// </summary>
        public string OptionC { set; get; }

        /// <summary>
        /// 选项D
        /// </summary>
        public string OptionD { set; get; }

        /// <summary>
        /// 分值
        /// </summary>
        public string Score { set; get; }

        /// <summary>
        /// 删除标识0有效1无效
        /// </summary>
        public string Scbz { set; get; }
    }
}
