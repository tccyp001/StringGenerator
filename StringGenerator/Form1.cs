using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StringFormatter;
using StringFormatter.Converters;

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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void RTBInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFormatSetting_Click(object sender, EventArgs e)
        {
            TableFormatSettingDlg dlg = new TableFormatSettingDlg();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tfs = dlg.tfs;
            }
        }
    }
}
