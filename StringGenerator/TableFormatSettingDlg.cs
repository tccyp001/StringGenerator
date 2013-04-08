using System;
using System.Collections.Generic;
using System.Data;
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
            DialogResult = DialogResult.OK;
        }

        private void UpdateSettingsModel()
        {
            tfs.OldRowDelimiterDisplay = txtOldRowDelimiter.Text;
            tfs.OldCellDelimiterDisplay = txtOldColDelimiter.Text;
            tfs.NewRowDelimiterDisplay = txtNewRowDelimiter.Text;
            tfs.NewCellDelimiterDisplay = txtNewColDelimiter.Text;
            tfs.rowLeftWrapper = txtNewRowLeftWrapper.Text;
            tfs.rowRightWrapper = txtNewRowRightWrapper.Text;
            tfs.cellLeftWrapper = txtNewColLeftWrapper.Text;
            tfs.cellRightWrapper = txtNewColRightWrapper.Text;
            tfs.customRowFormat = txtCustomTemplate.Text;
            tfs.emptyCellMark =  txtEmptyCellMark.Text;
            SetColSettings();

        }
        private void SetColSettings()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Column Index"));
            dt.Columns.Add(new DataColumn("Column Operation"));
            foreach (var key in tfs.ColFormatOperationDic.Keys)
            {
                var dr = dt.NewRow();
                dr[0] = key;
                dr[1] = tfs.ColFormatOperationDic[key];
                dt.Rows.Add(dr);
            }
            dataGVColSetting.DataSource = dt;
        }
        private void UpdateSettingsView()
        {
            txtOldRowDelimiter.Text = tfs.OldRowDelimiterDisplay;
            txtOldColDelimiter.Text = tfs.OldCellDelimiterDisplay;
            txtNewRowDelimiter.Text = tfs.NewRowDelimiterDisplay;
            txtNewColDelimiter.Text = tfs.NewCellDelimiterDisplay;
            txtNewRowLeftWrapper.Text = tfs.rowLeftWrapper;  
            txtNewRowRightWrapper.Text = tfs.rowRightWrapper;
            txtNewColLeftWrapper.Text = tfs.cellLeftWrapper;
            txtNewColRightWrapper.Text = tfs.cellRightWrapper;
            txtCustomTemplate.Text = tfs.customRowFormat;
            txtEmptyCellMark.Text = tfs.emptyCellMark;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            //dataGVColSetting.SelectedRows.
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int index = int.Parse(txtColIndex.Text);
            string op = txtColFormat.Text;
            tfs.ColFormatOperationDic.Add(index, op);
            SetColSettings();
        }
    }
}
