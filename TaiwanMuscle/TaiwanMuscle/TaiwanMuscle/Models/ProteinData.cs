using System;
using System.Collections.Generic;

namespace TaiwanMuscle.Models
{
    public partial class ProteinData
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; }
        public string Favor { get; set; }
        public int Discount { get; set; }
    }
}
