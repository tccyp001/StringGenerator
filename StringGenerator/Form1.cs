using System;
using System.Data;
using System.Windows.Forms;
using StringFormatter;
using StringFormatter.Converters;
using YpCommonLibrary.Utils;

namespace StringGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private TableFormatterSetting tfs;
        protected TableFormatterSetting GetSetting()
        {
            if (tfs == null)
            {
                tfs = TableFormatterSetting.GetDefaultSetting();
            }
            return tfs;
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            var inputStr = RTBInput.Text;
            if (!string.IsNullOrWhiteSpace(inputStr))
            {
                DataTable dt = StructureConverter.ConvertStrToDataTable(inputStr, GetSetting());
               OutputDataGridView.DataSource = dt;
               RTBOutput.Text = StructureConverter.ConvertDTToStr(dt, GetSetting());
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            StringFormatOnFly strOnFly = new StringFormatOnFly();
            var myExpr = RTBExpr.Text;
            var ret = strOnFly.ExecuteOnFlyCode(myExpr, RTBInput.Text);
            RTBOutput.Text = ret.ToString();
        }


        private void btnFormatSetting_Click(object sender, EventArgs e)
        {
            tfs = XmlSerializerHelper<TableFormatterSetting>.DeserializeObjectFromXml("tfs.xml");
            if (tfs == null)
            {
                tfs = new TableFormatterSetting();
            }
            TableFormatSettingDlg dlg = new TableFormatSettingDlg(tfs);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tfs = dlg.tfs;
                XmlSerializerHelper<TableFormatterSetting>.SerializeObjectToXml("tfs.xml", tfs);
            }
        }
    }
}
