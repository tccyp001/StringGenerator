using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using StringFormatter;
using StringFormatter.Converters;

namespace StringGenerator
{
    public partial class TableFormatSettingDlg : Form
    {
        public TableFormatterSetting tfs = new TableFormatterSetting();
        private DataTable dt = new DataTable();
        public TableFormatSettingDlg(TableFormatterSetting tfs)
        {
            this.tfs = tfs;
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
            

        }
        private void SetColSettings()
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Column Index"));
            dt.Columns.Add(new DataColumn("Column Operation"));
            foreach (var item in tfs.ColFormatOperationDic)
            {
                var dr = dt.NewRow();
                dr[0] = item.Key;
                dr[1] = item.Value;
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
            SetColSettings();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

            var rowIndex = dataGVColSetting.SelectedCells[0].RowIndex;
            var cellStr = dataGVColSetting[0, rowIndex].Value;
            var item = tfs.ColFormatOperationDic.Find(m => string.Equals(m.Key.ToString(),cellStr));
            tfs.ColFormatOperationDic.Remove(item);
            SetColSettings();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int index = int.Parse(txtColIndex.Text);
            string op = txtColFormat.Text;
            tfs.ColFormatOperationDic.Add(new MySeriazableListItem()
                                              {
                                                  Key = index,
                                                  Value = op
                                              });
            SetColSettings();
        }
    }
}
