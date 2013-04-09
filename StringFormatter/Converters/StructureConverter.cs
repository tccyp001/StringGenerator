using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
namespace StringFormatter.Converters
{
    public static class StructureConverter
    {
        public static DataTable ConvertStrToDataTable(string str, TableFormatterSetting tfs)
        {
            return ConvertStrListToDT(ConvertStrToStrLists(str, tfs));
        }
        public static DataTable ConvertStrListToDT(List<List<string>> stringTable)
        {
            if (stringTable.Count<=0)
                return null;

            DataTable dt = new DataTable();
            int colCount = stringTable[0].Count;
            for (int i = 0; i < colCount; i++)
            {
                dt.Columns.Add(new DataColumn());
            }

            foreach (var strLine in stringTable)
            {
                var dataRow = dt.NewRow();
// ReSharper disable CoVariantArrayConversion
                dataRow.ItemArray = strLine.ToArray();
// ReSharper restore CoVariantArrayConversion
                dt.Rows.Add(dataRow);
            }
            return dt;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tfs"></param>
        /// <returns></returns>
        public static List<List<string>> ConvertStrToStrLists(string str, TableFormatterSetting tfs)
        {
            List<List<string>> stringTable = new List<List<string>>();
            var strLines = str.Split(tfs.oldRowDelimiter.ToCharArray());
            int totalColCount = GetTotalColCount(strLines[0], tfs);
            foreach (var strLine in strLines)
            {
                var strRow = new List<string>();
                if (!string.IsNullOrWhiteSpace(strLine))
                {
                    var strCells = strLine.Split(tfs.oldCellDelimiter.ToCharArray());
                    if (strCells.Count() != totalColCount)
                    {
                        strCells = GetUnStandardRow(strCells, totalColCount, tfs); 
                    }
                    foreach (var strCell in strCells)
                    {
                        strRow.Add(strCell);
                    }
 
                    
                }
                stringTable.Add(strRow);
            }
            return stringTable;
        }

        private static string[] GetUnStandardRow(string[] strCells, int totalColCount, TableFormatterSetting tfs)
        {
            // like this ----- abc
            string[] retStrs = new string[totalColCount];
            int index =0;
            if (strCells.Count()< totalColCount)
            {
                foreach (var str in strCells)
                {
                    char emptyCellMark = tfs.emptyCellMark.ToCharArray()[0];
                    int emptyCellMarkCount = str.Count(f => f == emptyCellMark);
                    for (int i = 0; i < emptyCellMarkCount; i++)
                    {
                        retStrs[index] =string.Empty;
                        index++;
                    }
                    var strTemp = str.Replace(tfs.emptyCellMark, "");
                    if (!string.IsNullOrWhiteSpace(strTemp))
                    {
                        retStrs[index] = strTemp;
                        index++;
                    }
                }
            }
            if (strCells.Count()> totalColCount)
            {
                List<string> mylist = new List<string>();
                foreach (var str in strCells)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        mylist.Add(str);
                    }
                }
                for (int i = 0; i < Math.Max(mylist.Count, totalColCount); i++)
                {
                    retStrs[i] = mylist[i];
                }
            }
          
            return retStrs;
        }

        private static int GetTotalColCount(string str, TableFormatterSetting tfs)
        {
            if (tfs.totalColNum <=0)
            {
               var strs = str.Split(tfs.oldCellDelimiter.ToCharArray());
               List<string> strList = new List<string>();
               foreach (var item in strs)
               {
                   if (!string.IsNullOrWhiteSpace(item))
                   {
                       strList.Add(item);
                   }
               }
               tfs.totalColNum =  strList.Count();
            }
            return tfs.totalColNum;
        }
        public static string ConvertDTToStr(DataTable dt, TableFormatterSetting tfs)
        {
            StringBuilder sb = new StringBuilder();
            bool isFirstRow = true;
            foreach (DataRow row in dt.Rows)
            {
                if (!isFirstRow)
                {
                    sb.Append(tfs.newRowDelimiter);
                }
                sb.Append(tfs.rowLeftWrapper);
                GetRowStr(row, tfs, sb);
                sb.Append(tfs.rowRightWrapper); 
                isFirstRow = false;
            }
            return sb.ToString();
        }

        private static void GetRowStr(DataRow row, TableFormatterSetting tfs, StringBuilder sb)
        {
            if (string.IsNullOrWhiteSpace(tfs.customRowFormat))
            {
                GetRegularRowStr(row, tfs, sb);
            }
            else
            {
                GetCustomRowStr(row, tfs, sb);
            }
        }

        private static void GetCustomRowStr(DataRow row, TableFormatterSetting tfs, StringBuilder sb)
        {
            var templateStr = tfs.customRowFormat;
            for (int i = 0; i < row.ItemArray.Count(); i++)
            {
                var colKey = "{col" + i + "}";
                var keyIndex = templateStr.IndexOf(colKey, StringComparison.InvariantCultureIgnoreCase);
                
                if (keyIndex > -1)
	            {
                    var realKey = templateStr.Substring(keyIndex, colKey.Length);
                    templateStr = templateStr.Replace(realKey, GetRegularCellStr(row.ItemArray[i].ToString(), i, tfs));
	            }
            }
            var regKey = "{regularrow}";
            var regIndex = templateStr.IndexOf(regKey, StringComparison.InvariantCultureIgnoreCase);
            if (regIndex > -1)
            {
                templateStr = templateStr.Replace(templateStr.Substring(regIndex, regKey.Length), GetRegularRowStr(row, tfs));
            }
            sb.Append(templateStr);
        }
        public static void GetRegularRowStr(DataRow dr, TableFormatterSetting tfs, StringBuilder sb)
        {
            bool isFirstCell = true;
            int colIndex = 0;
            foreach (var cell in dr.ItemArray)
            {
                if (!isFirstCell)
                {
                    sb.Append(tfs.newCellDelimiter);
                }
                isFirstCell = false;
                sb.Append(tfs.cellLeftWrapper);
                sb.Append(GetRegularCellStr(cell.ToString(),colIndex,tfs));
                sb.Append(tfs.cellRightWrapper);
                colIndex++;
            }
        }

        public static string GetRegularCellStr(string input, int colIndex, TableFormatterSetting tfs)
        {
            var opStr = GetOpStr(colIndex, tfs.ColFormatOperationDic);
            if (!string.IsNullOrWhiteSpace(opStr))
            {
                return ApplyCellCustomOp(input, opStr);
            }
            return input;
        }

        public static string GetOpStr(int colIndex, List<MySeriazableListItem> formatOperationList)
        {
            foreach (var item in formatOperationList)
            {
                if (colIndex == item.Key)
                {
                    return item.Value;
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// operation should be as following format 
        /// Insert(1,"bbb") RevInsert(0,"ccc")
        /// Delete(1,2) RevDelete(2,2)
        /// Update(1,"aaa") RevUpdate(2,"aaa")
        /// Get(1,2) RevGet(1,2)
        /// Reverse() Reverse()
        /// </summary>
        /// <param name="input"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static string ApplyCellCustomOp(string input, string operation)
        {
            bool reverseFlag = false;
            string retStr = input;
            int index1, index2;
            if (operation.IndexOf("rev", StringComparison.InvariantCultureIgnoreCase)>=0 || 
                   operation.IndexOf("reverse", StringComparison.InvariantCultureIgnoreCase)>=0)
            {
                reverseFlag = true;
            }
            index1 = operation.IndexOf("ins", StringComparison.InvariantCultureIgnoreCase);
            index2 = operation.IndexOf("insert", StringComparison.InvariantCultureIgnoreCase);
            if (index1 >0 || index2>0)
            {
                string value1;
                string value2;
                GetOperationValues(operation, out value1, out value2);
                
                int index = int.Parse(value1);
                value2 = RemoveQuote(value2);
                if (reverseFlag)
                {
                    index = input.Length - index;
                }
                if (index >= 0 && index < input.Length)
                {
                    retStr = input.Insert(index, value2);
                }
            }
            index1 = operation.IndexOf("del", StringComparison.InvariantCultureIgnoreCase);
            index2 = operation.IndexOf("delete", StringComparison.InvariantCultureIgnoreCase);
            if (index1 >=0 || index2>=0)
            {
                string value1;
                string value2;
                GetOperationValues(operation, out value1, out value2);

                int index = int.Parse(value1);
                int len = int.Parse(value2);
                if (reverseFlag)
                {
                    index = input.Length - index ;
                }
                if (index >= 0 && index + len < input.Length)
                {
                    retStr = input.Remove(index, len);
                }
            }
            index1 = operation.IndexOf("upd", StringComparison.InvariantCultureIgnoreCase);
            index2 = operation.IndexOf("update", StringComparison.InvariantCultureIgnoreCase);
            if (index1 >=0)
            {
                string value1;
                string value2;
                GetOperationValues(operation, out value1, out value2);

                int index = int.Parse(value1);
                value2 = RemoveQuote(value2);
                
                if (reverseFlag)
                {
                    index = input.Length - index ;
                }
                if (index >= 0 && index + value2.Length < input.Length)
                {
                    retStr = input.Remove(index, value2.Length);
                    retStr = retStr.Insert(index, value2);
                }
            }
            index1 = operation.IndexOf("get", StringComparison.InvariantCultureIgnoreCase);
            if (index1 >=0 || index2>=0)
            {
                string value1;
                string value2;
                GetOperationValues(operation, out value1, out value2);

                int index = int.Parse(value1);
                int len = int.Parse(value2);
                if (reverseFlag)
                {
                    index = input.Length - index;
                }
                if (index >= 0 && index + len < input.Length)
                {
                    retStr = input.Substring(index, len);
                }
            }

            return retStr;
        }
        private static string RemoveQuote(string input)
        { 
            if (string.IsNullOrWhiteSpace(input))
                return input;
      
            if (input[0] == '"' && input[input.Length -1] == '"' ||
                input[0] == '\'' && input[input.Length -1] == '\'')
            {
                return input.Substring(1, input.Length -2);
            }
            return input;

        }

        private static void GetOperationValues(string input, out string value1, out string value2)
        {
            int lbindex;
            int firstCommaIndex;
            int rbindex;
            lbindex = input.IndexOf("(");
            firstCommaIndex = input.IndexOf(",");
            rbindex = input.IndexOf(")");
            value1 = input.Substring(lbindex + 1, firstCommaIndex - lbindex - 1);
            value2 = input.Substring(firstCommaIndex + 1, rbindex - firstCommaIndex - 1);
        }

        public static string GetRegularRowStr(DataRow dr, TableFormatterSetting tfs)
        {
            StringBuilder sb = new StringBuilder();
            bool isFirstCell = true;
            foreach (var cell in dr.ItemArray)
            {
                if (!isFirstCell)
                {
                    sb.Append(tfs.newCellDelimiter);
                }
                isFirstCell = false;
                sb.Append(tfs.cellLeftWrapper);
                sb.Append(cell.ToString());
                sb.Append(tfs.cellRightWrapper);
            }
            return sb.ToString();
        }
    }
}
