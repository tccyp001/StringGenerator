using System.Collections.Generic;

namespace StringFormatter.Converters
{
    public class TableFormatterSetting
    {
        public string oldCellDelimiter;
        public string newCellDelimiter;
        public string oldRowDelimiter;
        public string newRowDelimiter;

        public string OldCellDelimiterDisplay
        {
            get 
            {
                if (oldCellDelimiter == "\n")
                {
                    return "CR";
                }
               return oldCellDelimiter; 
            }
            set 
            {
               if (value.ToLower() == "cr")
               {
                   oldCellDelimiter = "\n";
               }
               else
               {
                   oldCellDelimiter = value;
               }
               
            }
        }
        public string NewCellDelimiterDisplay
        {
            get
            {
                if (newCellDelimiter == "\n")
                {
                    return "CR";
                }
                return newCellDelimiter;
            }
            set
            {
                if (value.ToLower() == "cr")
                {
                    newCellDelimiter = "\n";
                }
                else
                {
                    newCellDelimiter = value;
                }
                
            }
        }
        public string OldRowDelimiterDisplay
        {
            get
            {
                if (oldRowDelimiter == "\n")
                {
                    return "CR";
                }
                return oldRowDelimiter;
            }
            set
            {
                if (value.ToLower() == "cr")
                {
                    oldRowDelimiter = "\n";
                }
                else
                {
                    oldRowDelimiter = value;
                }
            }
        }
        public string NewRowDelimiterDisplay
        {
            get
            {
                if (newRowDelimiter == "\n")
                {
                    return "CR";
                }
                return newRowDelimiter;
            }
            set
            {
                if (value.ToLower() == "cr")
                {
                    newRowDelimiter = "\n";
                }
                else
                {
                    newRowDelimiter = value;
                }
            }
        }


        public string cellLeftWrapper;
        public string cellRightWrapper;
        public string rowLeftWrapper;
        public string rowRightWrapper;
        public string customRowFormat;
        public string emptyCellMark;
        public int totalColNum;
        public Dictionary<int, string> ColFormatOperationDic = new Dictionary<int, string>();


        public static TableFormatterSetting GetDefaultSetting()
        {
            return new TableFormatterSetting();
        }
        public TableFormatterSetting()
        {
            //set default value
            oldCellDelimiter = " ";
            newCellDelimiter = ",";
            oldRowDelimiter = "\n";
            newRowDelimiter = ",\n";
            cellLeftWrapper = "\"";
            cellRightWrapper = "\"";
            rowLeftWrapper = "\t{";
            rowRightWrapper = "}";
            customRowFormat = string.Empty;
            emptyCellMark = "-";
        }
    }
}
