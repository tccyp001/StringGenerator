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
            this.OutputDataGridView = new System.Windows.Forms.DataGridView();
            this.RTBInput = new System.Windows.Forms.RichTextBox();
            this.BtnStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OutputDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // OutputDataGridView
            // 
            this.OutputDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OutputDataGridView.Location = new System.Drawing.Point(50, 325);
            this.OutputDataGridView.Name = "OutputDataGridView";
            this.OutputDataGridView.Size = new System.Drawing.Size(240, 150);
            this.OutputDataGridView.TabIndex = 0;
            // 
            // RTBInput
            // 
            this.RTBInput.Location = new System.Drawing.Point(50, 30);
            this.RTBInput.Name = "RTBInput";
            this.RTBInput.Size = new System.Drawing.Size(677, 249);
            this.RTBInput.TabIndex = 1;
            this.RTBInput.Text = "";
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(650, 451);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(75, 23);
            this.BtnStart.TabIndex = 2;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 581);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.RTBInput);
            this.Controls.Add(this.OutputDataGridView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.OutputDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView OutputDataGridView;
        private System.Windows.Forms.RichTextBox RTBInput;
        private System.Windows.Forms.Button BtnStart;
    }
}

