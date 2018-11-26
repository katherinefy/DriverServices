using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverServices.Common
{
    /// <summary>
    /// 执行结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public Result() { }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 数据总条数
        /// </summary>
        public int Total { get; set; }

        /////// <summary>
        /////// 
        /////// </summary>
        /////// <param name="message"></param>
        /////// <returns></returns>
        ////public static Result<T> Fail(string message = "服务器内部错误");

        /////// <summary>
        /////// 
        /////// </summary>
        /////// <returns></returns>
        ////public static Result<T> Ok();

        /////// <summary>
        /////// 
        /////// </summary>
        /////// <param name="data"></param>
        /////// <param name="total"></param>
        /////// <returns></returns>
        ////public static Result<T> Ok(T data, int total);

    }
}
