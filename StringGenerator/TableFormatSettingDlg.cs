using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StringFormatter.Converters;

namespace StringGenerator
{
    public partial class TableFormatSettingDlg : Form
    {
        public TableFormatterSetting tfs = new TableFormatterSetting();
        public TableFormatSettingDlg()
        {
            InitializeComponent();
            UpdateSettingsView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateSettingsModel();
        }

        private void UpdateSettingsModel()
        {
            tfs.oldRowDelimiter = txtOldRowDelimiter.Text;
            tfs.oldCellDelimiter = txtOldColDelimiter.Text;
            tfs.newRowDelimiter = txtNewRowDelimiter.Text;
            tfs.newCellDelimiter = txtNewColDelimiter.Text;
            tfs.rowLeftWrapper = txtNewRowLeftWrapper.Text;
            tfs.rowRightWrapper = txtNewRowRightWrapper.Text;
            tfs.cellLeftWrapper = txtNewColLeftWrapper.Text;
            tfs.cellRightWrapper = txtNewColRightWrapper.Text;
            tfs.customRowFormat = txtCustomTemplate.Text;
        }
        private void UpdateSettingsView()
        {
            txtOldRowDelimiter.Text = tfs.oldRowDelimiter;
            txtOldColDelimiter.Text = tfs.oldCellDelimiter;
            txtNewRowDelimiter.Text = tfs.newRowDelimiter; 
            txtNewColDelimiter.Text = tfs.newCellDelimiter;
            txtNewRowLeftWrapper.Text = tfs.rowLeftWrapper;  
            txtNewRowRightWrapper.Text = tfs.rowRightWrapper;
            txtNewColLeftWrapper.Text = tfs.cellLeftWrapper;
            txtNewColRightWrapper.Text = tfs.cellRightWrapper;
            txtCustomTemplate.Text = tfs.customRowFormat;
        }
    }
}
