using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaiwanMuscle
{
    /// <summary>
    /// 返回结果集（为了跟其他项目对接，统一为小写）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T>
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public int ok { get; set; }

        /// <summary>
        /// 返回码
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        public T data { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string msg { get; set; }

    }
}
