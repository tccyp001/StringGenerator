using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringFormatter.Converters;

namespace StringFormatter
{
    public class YPStringFormatter
    {
        public string Template { get; set; }
        public List<List<string>> StrVars { get; set; }

       
        public List<string> Format()
        {
            var resultList = new List<string>();

            foreach (var strs in StrVars)
            {
                 resultList.Add(string.Format(Template,strs));
            }
            return resultList;
        }
        public void SetStrVars(string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
               
            }
        }
    }
}
