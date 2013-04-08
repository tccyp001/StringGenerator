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
            foreach (var strLine in strLines)
            {
                var strRow = new List<string>();
                if (!string.IsNullOrWhiteSpace(strLine))
                {
                    var strCells = strLine.Split(tfs.oldCellDelimiter.ToCharArray());
                    foreach (var strCell in strCells)
                    {
                        strRow.Add(strCell);
                    }
                }
                stringTable.Add(strRow);
            }
            return stringTable;
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
                var realKey = templateStr.Substring(keyIndex, colKey.Length);
                if (keyIndex > -1)
	            {
                    templateStr = templateStr.Replace(realKey, row.ItemArray[i].ToString());
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
