using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TaiwanMuscle.ReponseModels
{
    [DataContract]
    public class P001
    {
        /// <summary>
        /// id
        /// </summary>
        [DataMember]
        public int Id { get; set; }
        /// <summary>
        /// 價格
        /// </summary>
        [DataMember]
        public int Price { get; set; }
        /// <summary>
        /// 庫存
        /// </summary>
        [DataMember]
        public int Stock { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        [DataMember]
        public string Brand { get; set; }
        /// <summary>
        /// 口味
        /// </summary>
        [DataMember]
        public string Favor { get; set; }

    }
}
