namespace StringFormatter.Converters
{
    public class TableFormatterSetting
    {
        public string oldCellDelimiter;
        public string newCellDelimiter;
        public string oldRowDelimiter;
        public string newRowDelimiter;
        public string cellLeftWrapper;
        public string cellRightWrapper;
        public string rowLeftWrapper;
        public string rowRightWrapper;
        public string customRowFormat;

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
            rowLeftWrapper = "\tnew object[]{";
            rowRightWrapper = "}";
            customRowFormat = string.Empty;
        }
    }
}
