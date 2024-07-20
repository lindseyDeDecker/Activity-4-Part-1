namespace CST_150_Activity_3._1
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            lblSelectedFile = new Label();
            lblResults = new Label();
            selectFileDialog = new OpenFileDialog();
            lblSelectRow = new Label();
            cmbSelectRow = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.ForestGreen;
            button1.CausesValidation = false;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderColor = Color.Black;
            button1.FlatAppearance.MouseDownBackColor = Color.DarkOliveGreen;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.WhiteSmoke;
            button1.Location = new Point(314, 69);
            button1.Name = "button1";
            button1.Size = new Size(137, 48);
            button1.TabIndex = 0;
            button1.Text = "Read File";
            button1.UseVisualStyleBackColor = false;
            button1.Click += BtnReadFileClickEvent;
            // 
            // lblSelectedFile
            // 
            lblSelectedFile.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSelectedFile.ForeColor = Color.Firebrick;
            lblSelectedFile.Location = new Point(0, 418);
            lblSelectedFile.Name = "lblSelectedFile";
            lblSelectedFile.Size = new Size(799, 23);
            lblSelectedFile.TabIndex = 1;
            lblSelectedFile.Text = "label1";
            lblSelectedFile.TextAlign = ContentAlignment.MiddleCenter;
            lblSelectedFile.Click += lblSelectedFile_Click;
            // 
            // lblResults
            // 
            lblResults.AutoSize = true;
            lblResults.Font = new Font("Lucida Console", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblResults.Location = new Point(186, 216);
            lblResults.Name = "lblResults";
            lblResults.Size = new Size(73, 16);
            lblResults.TabIndex = 2;
            lblResults.Text = "label1";
            // 
            // selectFileDialog
            // 
            selectFileDialog.FileName = "openFileDialog1";
            // 
            // lblSelectRow
            // 
            lblSelectRow.AutoSize = true;
            lblSelectRow.Location = new Point(141, 121);
            lblSelectRow.Name = "lblSelectRow";
            lblSelectRow.Size = new Size(64, 15);
            lblSelectRow.TabIndex = 4;
            lblSelectRow.Text = "Select Row";
            // 
            // cmbSelectRow
            // 
            cmbSelectRow.FormattingEnabled = true;
            cmbSelectRow.Location = new Point(144, 140);
            cmbSelectRow.Name = "cmbSelectRow";
            cmbSelectRow.Size = new Size(121, 23);
            cmbSelectRow.TabIndex = 5;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbSelectRow);
            Controls.Add(lblSelectRow);
            Controls.Add(lblResults);
            Controls.Add(lblSelectedFile);
            Controls.Add(button1);
            Name = "FrmMain";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label lblSelectedFile;
        private Label lblResults;
        private OpenFileDialog selectFileDialog;
        private Label lblSelectRow;
        private ComboBox cmbSelectRow;
    }
}
