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
    }
}
