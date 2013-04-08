using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YpCommonLibrary.Utils
{
    public static class StringExtension
    {
        public static bool ContainsInsensitiveCase(this string str, string str1)
        {
            return str.ToLower().Contains(str1.ToLower());
        }
    }
}
