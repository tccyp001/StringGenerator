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

        private void BtnStart_Click(object sender, EventArgs e)
        {
            var inputStr = RTBInput.Text;
            if (!string.IsNullOrWhiteSpace(inputStr))
            {
               DataTable dt = StructureConverter.ConvertStrToDataTable(inputStr, TableFormatterSetting.GetDefaultSetting());
               OutputDataGridView.DataSource = dt;   
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
    }
}
