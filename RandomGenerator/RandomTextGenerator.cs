using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGenerator
{
    public class RandomTextGenerator
    {
        private RandomSettings randomSettings;
        private int currentValue = 0;
        private Random r = new Random();
        public RandomTextGenerator(RandomSettings randomSettings)
        {
            this.randomSettings = randomSettings;
        }
        public List<string> GetRandomList()
        {
            List<string> retList = new List<string>();
            for (int i = 0; i < randomSettings.TargetListLen; i++)
            {
                var randStr = GetSingleRandom();
                retList.Add(randStr);
            }
            return retList;
        }

        private string GetSingleRandom()
        {
            if (randomSettings.RandType == RandomType.Sequence)
            {
                currentValue++;
                return currentValue.ToString();
            }
            if (randomSettings.RandType == RandomType.Number)
            {
                var tempRand = r.Next()%(randomSettings.RangeTo - randomSettings.RangeFrom) + randomSettings.RangeFrom;
                return tempRand.ToString();
            }
            if (randomSettings.RandType == RandomType.DecimalNumber)
            {
                var tempRand = r.Next()%(randomSettings.RangeTo - randomSettings.RangeFrom) + randomSettings.RangeFrom;
                int digits = (int) Math.Pow(10, randomSettings.DigitLen);
                decimal tempRandDecimal = r.Next()%digits;
                tempRandDecimal = tempRandDecimal/digits + tempRand;
                return tempRandDecimal.ToString();
            }
            if (randomSettings.RandType == RandomType.RanDate)
            {
                DateTime start = new DateTime(1986, 1, 1);
                int range = (int)(DateTime.Today - start).TotalDays;
                return start.AddDays(r.Next(range)).ToString();
            }
            if (randomSettings.RandType == RandomType.RanText)
            {
                int randSize = r.Next()%(randomSettings.MaxLen - randomSettings.MinLen) + randomSettings.MinLen;
                string randStr = RandomString(randSize);
                return randStr;
            }
            if (randomSettings.RandType == RandomType.RanTextFromDic)
            {
                int index = (r.Next()%randomSettings.dic.Count) + 1;
                if (randomSettings.dic.ContainsKey(index))
                {
                    return randomSettings.dic[index];
                }
                return randomSettings.dic.Values.FirstOrDefault();
            }
            return "default shouldn't see this";
        }
        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * r.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
}
