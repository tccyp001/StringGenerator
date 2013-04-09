namespace StringGenerator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnStart = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.RTBOutput = new System.Windows.Forms.RichTextBox();
            this.RTBExpr = new System.Windows.Forms.RichTextBox();
            this.RTBInput = new System.Windows.Forms.RichTextBox();
            this.OutputDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnFormatSetting = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutputDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(555, 627);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(75, 23);
            this.BtnStart.TabIndex = 2;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(227, 627);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 3;
            this.btnTest.Text = "test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1169, 595);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.RTBOutput);
            this.tabPage1.Controls.Add(this.RTBExpr);
            this.tabPage1.Controls.Add(this.RTBInput);
            this.tabPage1.Controls.Add(this.OutputDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1161, 569);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // RTBOutput
            // 
            this.RTBOutput.Location = new System.Drawing.Point(18, 294);
            this.RTBOutput.Name = "RTBOutput";
            this.RTBOutput.Size = new System.Drawing.Size(1070, 164);
            this.RTBOutput.TabIndex = 9;
            this.RTBOutput.Text = "";
            // 
            // RTBExpr
            // 
            this.RTBExpr.Location = new System.Drawing.Point(493, 138);
            this.RTBExpr.Name = "RTBExpr";
            this.RTBExpr.Size = new System.Drawing.Size(595, 150);
            this.RTBExpr.TabIndex = 8;
            this.RTBExpr.Text = "";
            // 
            // RTBInput
            // 
            this.RTBInput.Location = new System.Drawing.Point(18, 17);
            this.RTBInput.Name = "RTBInput";
            this.RTBInput.Size = new System.Drawing.Size(1070, 106);
            this.RTBInput.TabIndex = 7;
            this.RTBInput.Text = "";
            // 
            // OutputDataGridView
            // 
            this.OutputDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OutputDataGridView.Location = new System.Drawing.Point(18, 138);
            this.OutputDataGridView.Name = "OutputDataGridView";
            this.OutputDataGridView.Size = new System.Drawing.Size(438, 150);
            this.OutputDataGridView.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1161, 569);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnFormatSetting
            // 
            this.btnFormatSetting.Location = new System.Drawing.Point(34, 626);
            this.btnFormatSetting.Name = "btnFormatSetting";
            this.btnFormatSetting.Size = new System.Drawing.Size(86, 23);
            this.btnFormatSetting.TabIndex = 7;
            this.btnFormatSetting.Text = "FormatSetting";
            this.btnFormatSetting.UseVisualStyleBackColor = true;
            this.btnFormatSetting.Click += new System.EventHandler(this.btnFormatSetting_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1443, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 686);
            this.Controls.Add(this.btnFormatSetting);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OutputDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox RTBOutput;
        private System.Windows.Forms.RichTextBox RTBExpr;
        private System.Windows.Forms.RichTextBox RTBInput;
        private System.Windows.Forms.DataGridView OutputDataGridView;
        private System.Windows.Forms.Button btnFormatSetting;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

