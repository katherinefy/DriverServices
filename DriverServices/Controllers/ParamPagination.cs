using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverServices.Controllers
{
    public class ParamPagination
    {
        /// <summary>
        /// 每页显示的数据条数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 页索引
        /// </summary>
        public int PageIndex { get; set; }
    }
}
