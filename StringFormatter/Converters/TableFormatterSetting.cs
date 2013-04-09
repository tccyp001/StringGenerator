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
                if (oldCellDelimiter.Contains("\n"))
                {
                    return oldCellDelimiter.Replace("\n", "CR");
                }
               return oldCellDelimiter; 
            }
            set 
            {
                if (value.ToLower().Contains("cr"))
               {
                   oldCellDelimiter = value.Replace("CR", "\n");
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
                if (newCellDelimiter.Contains("\n"))
                {
                    return newCellDelimiter.Replace("\n", "CR");
                }
                return newCellDelimiter;
            }
            set
            {
                if (value.ToLower().Contains("cr"))
                {
                    newCellDelimiter = value.Replace("CR", "\n");
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
                if (oldRowDelimiter.Contains("\n"))
                {
                    return oldRowDelimiter.Replace("\n", "CR");
                }
                return oldRowDelimiter;
            }
            set
            {
                if (value.ToLower().Contains("cr"))
                {
                    oldRowDelimiter = value.Replace("CR", "\n");
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
                if (newRowDelimiter.Contains("\n"))
                {
                    return newRowDelimiter.Replace("\n","CR");
                }
                return newRowDelimiter;
            }
            set
            {
                if (value.ToLower().Contains("cr"))
                {
                    newRowDelimiter = value.Replace("CR","\n");
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
        public List<MySeriazableListItem> ColFormatOperationDic = new List<MySeriazableListItem>();

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
