using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YpCommonLibrary.Utils;
namespace RandomGenerator
{
    public static class RandomSettingParser
    {
        private const string LengthKey = "len";
        private const string RangeKey = "range";
        private const string DigitLenKey = "decimal";
        private const string TargetListLenKey = "total";
        private const string DicKey = "dic";

        public static RandomSettings ParseSingleLineStr(string configStr)
        {
            RandomSettings randSettings = new RandomSettings();
            SetRandType(configStr, randSettings);
            SetLength(configStr, randSettings);
            SetRange(configStr, randSettings);
            SetDigitLength(configStr, randSettings);
            SetTargetListLength(configStr, randSettings);
            SetDictionary(configStr, randSettings);
            return randSettings;
        }
        private static void SetDictionary(string configStr, RandomSettings randSettings)
        {
            if (configStr.ContainsInsensitiveCase(DicKey))
            {
                int kIndex = configStr.IndexOf(DicKey, StringComparison.InvariantCultureIgnoreCase);
                var values = GetConfigValues(configStr, kIndex);
                for (int i = 0; i < values.Count(); i++)
                {
                    randSettings.dic.Add(i + 1, values[i]);
                }
            }
        }
        private static void SetTargetListLength(string configStr, RandomSettings randSettings)
        {
            if (configStr == null) throw new ArgumentNullException("configStr");
            if (randSettings == null) throw new ArgumentNullException("randSettings");
            int value1, value2;
            SetConfigValues(configStr, TargetListLenKey, out value1, out value2);
            if (value1!=-1)
            {
                randSettings.TargetListLen = value1;
            }
        }

        private static void SetConfigValues(string configStr, string strKey, out int value1, out int value2)
        {
            value1 = -1;
            value2 = -1;
            if (configStr.ContainsInsensitiveCase(strKey))
            {
                int kIndex = configStr.IndexOf(strKey, StringComparison.InvariantCultureIgnoreCase);
                var values = GetConfigValues(configStr, kIndex);
                if (values.Count() > 0)
                {
                    value1 = int.Parse(values[0]);
                }
                if (values.Count() > 1)
                {
                    value2 = int.Parse(values[1]);
                }
            }
        }

        private static void SetDigitLength(string configStr, RandomSettings randSettings)
        {
            int value1, value2;
            SetConfigValues(configStr, DigitLenKey, out value1, out value2);
            if (value1!=-1)
            {
                randSettings.DigitLen = value1;
            }
        }


        private static void SetRange(string configStr, RandomSettings randSettings)
        {
            int value1, value2;
            SetConfigValues(configStr, RangeKey, out value1, out value2);
            if (value1!=-1)
            {
                randSettings.RangeFrom = value1;
            }
            if (value2 != -1)
            {
                randSettings.RangeTo = value2;

            }
            
        }
        private static void SetLength(string configStr, RandomSettings randSettings)
        {
            int value1, value2;
            SetConfigValues(configStr, LengthKey, out value1, out value2);
            if (value1!=-1)
            {
                randSettings.MinLen = value1;
            }
            if (value2 != -1)
            {
                randSettings.MaxLen = value2;

            }
        }

        private static string[] GetConfigValues(string configStr, int kIndex)
        {
            int leftBIndex = configStr.IndexOf("(", kIndex);
            int rightBIndex = configStr.IndexOf(")", kIndex);
            string[] itemStrs = new string[]{};
            if (leftBIndex < rightBIndex)
            {
                string valueStr = configStr.Substring(leftBIndex + 1, rightBIndex - leftBIndex - 1);
                itemStrs = valueStr.Split(',');
            }
            else
            {
                throw new Exception("wrong random config format");
            }
            return itemStrs;
        }

        
        private static void SetRandType(string configStr, RandomSettings randSettings)
        {
            if (configStr.Trim().StartsWith("\\d"))
            {
                randSettings.RandType = RandomType.Number;
            }
            if (configStr.Trim().StartsWith("\\seq"))
            {
                randSettings.RandType = RandomType.Sequence;
            }
            if (configStr.Trim().StartsWith("\\decimal"))
            {
                randSettings.RandType = RandomType.DecimalNumber;
            }
            if (configStr.Trim().StartsWith("\\text"))
            {
                randSettings.RandType = RandomType.RanText;
            }
            if (configStr.Trim().StartsWith("\\textList"))
            {
                randSettings.RandType = RandomType.RanTextFromDic;
            }
            if (configStr.Trim().StartsWith("\\date"))
            {
                randSettings.RandType = RandomType.RanDate;
            }
        }
    }
}
