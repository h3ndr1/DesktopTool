namespace CodeX.DesktopTool.Print
{
    partial class ApplicationSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationSetting));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkUseNetworkPrinter = new System.Windows.Forms.CheckBox();
            this.chkClearLog = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboCheckPrinterStatus = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboAutoSaveLog = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboPrinterModel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboPrinterList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pagLabelOption = new System.Windows.Forms.TabPage();
            this.cboBarcodeType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cboDataMode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panContent = new System.Windows.Forms.Panel();
            this.panButton = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pagLabelOption.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panContent.SuspendLayout();
            this.panButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.pagLabelOption);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(495, 325);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkUseNetworkPrinter);
            this.tabPage1.Controls.Add(this.chkClearLog);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.cboCheckPrinterStatus);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.cboAutoSaveLog);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.cboPrinterModel);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cboPrinterList);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(487, 299);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "7";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkUseNetworkPrinter
            // 
            this.chkUseNetworkPrinter.AutoSize = true;
            this.chkUseNetworkPrinter.Location = new System.Drawing.Point(119, 35);
            this.chkUseNetworkPrinter.Name = "chkUseNetworkPrinter";
            this.chkUseNetworkPrinter.Size = new System.Drawing.Size(157, 17);
            this.chkUseNetworkPrinter.TabIndex = 37;
            this.chkUseNetworkPrinter.Text = "Use network shared printer";
            this.chkUseNetworkPrinter.UseVisualStyleBackColor = true;
            // 
            // chkClearLog
            // 
            this.chkClearLog.AutoSize = true;
            this.chkClearLog.Location = new System.Drawing.Point(119, 129);
            this.chkClearLog.Name = "chkClearLog";
            this.chkClearLog.Size = new System.Drawing.Size(140, 17);
            this.chkClearLog.TabIndex = 36;
            this.chkClearLog.Text = "Clear log files when exit";
            this.chkClearLog.UseVisualStyleBackColor = true;
            this.chkClearLog.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(165, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "seconds";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboCheckPrinterStatus
            // 
            this.cboCheckPrinterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCheckPrinterStatus.FormattingEnabled = true;
            this.cboCheckPrinterStatus.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "30",
            "45",
            "60"});
            this.cboCheckPrinterStatus.Location = new System.Drawing.Point(119, 58);
            this.cboCheckPrinterStatus.Name = "cboCheckPrinterStatus";
            this.cboCheckPrinterStatus.Size = new System.Drawing.Size(44, 21);
            this.cboCheckPrinterStatus.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Check Printer Status";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(165, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "minutes";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Visible = false;
            // 
            // cboAutoSaveLog
            // 
            this.cboAutoSaveLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAutoSaveLog.FormattingEnabled = true;
            this.cboAutoSaveLog.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "30",
            "45",
            "60"});
            this.cboAutoSaveLog.Location = new System.Drawing.Point(119, 105);
            this.cboAutoSaveLog.Name = "cboAutoSaveLog";
            this.cboAutoSaveLog.Size = new System.Drawing.Size(44, 21);
            this.cboAutoSaveLog.TabIndex = 31;
            this.cboAutoSaveLog.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Auto Save Log File";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Visible = false;
            // 
            // cboPrinterModel
            // 
            this.cboPrinterModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinterModel.FormattingEnabled = true;
            this.cboPrinterModel.Location = new System.Drawing.Point(119, 81);
            this.cboPrinterModel.Name = "cboPrinterModel";
            this.cboPrinterModel.Size = new System.Drawing.Size(220, 21);
            this.cboPrinterModel.TabIndex = 29;
            this.cboPrinterModel.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Printer Model";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Visible = false;
            // 
            // cboPrinterList
            // 
            this.cboPrinterList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinterList.FormattingEnabled = true;
            this.cboPrinterList.Location = new System.Drawing.Point(119, 8);
            this.cboPrinterList.Name = "cboPrinterList";
            this.cboPrinterList.Size = new System.Drawing.Size(349, 21);
            this.cboPrinterList.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Printer Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pagLabelOption
            // 
            this.pagLabelOption.Controls.Add(this.cboBarcodeType);
            this.pagLabelOption.Controls.Add(this.label3);
            this.pagLabelOption.Location = new System.Drawing.Point(4, 22);
            this.pagLabelOption.Name = "pagLabelOption";
            this.pagLabelOption.Size = new System.Drawing.Size(487, 299);
            this.pagLabelOption.TabIndex = 2;
            this.pagLabelOption.Text = "Label Configuration";
            this.pagLabelOption.UseVisualStyleBackColor = true;
            // 
            // cboBarcodeType
            // 
            this.cboBarcodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBarcodeType.FormattingEnabled = true;
            this.cboBarcodeType.Items.AddRange(new object[] {
            "Linear",
            "QRCode"});
            this.cboBarcodeType.Location = new System.Drawing.Point(121, 12);
            this.cboBarcodeType.Name = "cboBarcodeType";
            this.cboBarcodeType.Size = new System.Drawing.Size(112, 21);
            this.cboBarcodeType.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Barcode Type";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cboDataMode);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.checkBox3);
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Controls.Add(this.txtConnectionString);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(487, 299);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Data Source";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cboDataMode
            // 
            this.cboDataMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataMode.FormattingEnabled = true;
            this.cboDataMode.Items.AddRange(new object[] {
            "Local",
            "Remote"});
            this.cboDataMode.Location = new System.Drawing.Point(135, 8);
            this.cboDataMode.Name = "cboDataMode";
            this.cboDataMode.Size = new System.Drawing.Size(174, 21);
            this.cboDataMode.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Data Mode";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(135, 35);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(174, 17);
            this.checkBox3.TabIndex = 38;
            this.checkBox3.Text = "Use Local Database ( if exists )";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(315, 10);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(143, 17);
            this.checkBox1.TabIndex = 37;
            this.checkBox1.Text = "Prioritize Local Database";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(135, 54);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(344, 21);
            this.txtConnectionString.TabIndex = 24;
            this.txtConnectionString.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Remote Connection";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Visible = false;
            // 
            // panContent
            // 
            this.panContent.Controls.Add(this.tabControl1);
            this.panContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panContent.Location = new System.Drawing.Point(0, 0);
            this.panContent.Name = "panContent";
            this.panContent.Size = new System.Drawing.Size(495, 325);
            this.panContent.TabIndex = 1;
            // 
            // panButton
            // 
            this.panButton.Controls.Add(this.btnCancel);
            this.panButton.Controls.Add(this.btnOK);
            this.panButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panButton.Location = new System.Drawing.Point(0, 279);
            this.panButton.Name = "panButton";
            this.panButton.Size = new System.Drawing.Size(495, 46);
            this.panButton.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(237, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(160, 11);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ApplicationSetting
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 325);
            this.Controls.Add(this.panButton);
            this.Controls.Add(this.panContent);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ApplicationSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.pagLabelOption.ResumeLayout(false);
            this.pagLabelOption.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panContent.ResumeLayout(false);
            this.panButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panContent;
        private System.Windows.Forms.Panel panButton;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cboPrinterList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.ComboBox cboPrinterModel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboAutoSaveLog;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboCheckPrinterStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkClearLog;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chkUseNetworkPrinter;
        private System.Windows.Forms.TabPage pagLabelOption;
        private System.Windows.Forms.ComboBox cboBarcodeType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDataMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox3;
    }
}