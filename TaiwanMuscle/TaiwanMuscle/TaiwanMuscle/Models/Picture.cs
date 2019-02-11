using System;
using System.Collections.Generic;

namespace TaiwanMuscle.Models
{
    public partial class Picture
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public string HeadPic { get; set; }
        public string FirstPic { get; set; }
        public string SecondPic { get; set; }
        public string ThirdPic { get; set; }
        public string FourthPic { get; set; }
    }
}
