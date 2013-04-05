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
    }
}
