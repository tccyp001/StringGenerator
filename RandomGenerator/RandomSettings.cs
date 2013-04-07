using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGenerator
{
    public class RandomSettings
    {
        public RandomType RandType { get; set; }
        public int RangeFrom {get; set; }
        public int RangeTo { get; set; }
        public int DigitLen { get; set; }
        public int MinLen {get;set;}
        public int MaxLen { get; set; }
        public int TargetListLen { get; set; }
        public Dictionary<int, string> dic { get; set; }
        public RandomSettings()
        {
            RandType = RandomType.Number;
            RangeFrom = 1;
            RangeTo = 100;
            DigitLen = 3;
            MinLen = 1;
            MaxLen = 3;
            TargetListLen = 10;
            dic = new Dictionary<int, string>();
        }
    }
}
