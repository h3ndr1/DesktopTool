namespace CodeX.DesktopTool.Print.Controls
{
    partial class LabelPrintCtl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabItemInformation = new System.Windows.Forms.TabControl();
            this.pagSinglePrint = new System.Windows.Forms.TabPage();
            this.panPatientInfoEntry = new System.Windows.Forms.Panel();
            this.panDNRIndicator = new System.Windows.Forms.Panel();
            this.panFallRiskIndicator = new System.Windows.Forms.Panel();
            this.panAllergyIndicator = new System.Windows.Forms.Panel();
            this.chkIsDNR = new System.Windows.Forms.CheckBox();
            this.chkIsFallRisk = new System.Windows.Forms.CheckBox();
            this.txtAllergyInfo = new System.Windows.Forms.TextBox();
            this.lblAllergyInfo = new System.Windows.Forms.Label();
            this.chkIsAllergy = new System.Windows.Forms.CheckBox();
            this.optFemale = new System.Windows.Forms.RadioButton();
            this.optMale = new System.Windows.Forms.RadioButton();
            this.lblLabelType = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAgeInDay = new System.Windows.Forms.TextBox();
            this.txtAgeInMonth = new System.Windows.Forms.TextBox();
            this.txtAgeInYear = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dteDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.pagMultiItem = new System.Windows.Forms.TabPage();
            this.grdItem = new System.Windows.Forms.DataGridView();
            this.colItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.txtQuickFilter = new System.Windows.Forms.TextBox();
            this.lblQuickSearch = new System.Windows.Forms.Label();
            this.panLabelPreview = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPreviewLine1 = new System.Windows.Forms.Label();
            this.lblPreviewLine3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panPreviewTitle = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cboLabelType = new System.Windows.Forms.ComboBox();
            this.lblLabelPreviewTitle = new System.Windows.Forms.Label();
            this.panPreview = new System.Windows.Forms.Panel();
            this.panMainContent = new System.Windows.Forms.Panel();
            this.panPatientInformation = new System.Windows.Forms.Panel();
            this.panToolbar = new System.Windows.Forms.Panel();
            this.cboDatabase = new System.Windows.Forms.ComboBox();
            this.btnPrinterStatus = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnConfiguration = new System.Windows.Forms.Button();
            this.optLocalDB = new System.Windows.Forms.RadioButton();
            this.optRemoteDB = new System.Windows.Forms.RadioButton();
            this.btnRefreshLocalDB = new System.Windows.Forms.Button();
            this.btnPrintLabel = new System.Windows.Forms.Button();
            this.panRecentList = new System.Windows.Forms.Panel();
            this.grdPatient = new System.Windows.Forms.DataGridView();
            this.colMRN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrintNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tabItemInformation.SuspendLayout();
            this.pagSinglePrint.SuspendLayout();
            this.panPatientInfoEntry.SuspendLayout();
            this.pagMultiItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).BeginInit();
            this.panel2.SuspendLayout();
            this.panLabelPreview.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panPreviewTitle.SuspendLayout();
            this.panPreview.SuspendLayout();
            this.panMainContent.SuspendLayout();
            this.panPatientInformation.SuspendLayout();
            this.panToolbar.SuspendLayout();
            this.panRecentList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatient)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabItemInformation
            // 
            this.tabItemInformation.Controls.Add(this.pagSinglePrint);
            this.tabItemInformation.Controls.Add(this.pagMultiItem);
            this.tabItemInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabItemInformation.Location = new System.Drawing.Point(0, 0);
            this.tabItemInformation.Name = "tabItemInformation";
            this.tabItemInformation.SelectedIndex = 0;
            this.tabItemInformation.Size = new System.Drawing.Size(794, 259);
            this.tabItemInformation.TabIndex = 0;
            this.tabItemInformation.SelectedIndexChanged += new System.EventHandler(this.tabItemInformation_SelectedIndexChanged);
            // 
            // pagSinglePrint
            // 
            this.pagSinglePrint.Controls.Add(this.panPatientInfoEntry);
            this.pagSinglePrint.Controls.Add(this.txtItemName);
            this.pagSinglePrint.Controls.Add(this.lblItemCode);
            this.pagSinglePrint.Controls.Add(this.txtItemCode);
            this.pagSinglePrint.Controls.Add(this.lblFirstName);
            this.pagSinglePrint.Controls.Add(this.label1);
            this.pagSinglePrint.Controls.Add(this.txtShortName);
            this.pagSinglePrint.Location = new System.Drawing.Point(4, 22);
            this.pagSinglePrint.Name = "pagSinglePrint";
            this.pagSinglePrint.Size = new System.Drawing.Size(786, 233);
            this.pagSinglePrint.TabIndex = 1;
            this.pagSinglePrint.Text = "Single-Item Print";
            this.pagSinglePrint.UseVisualStyleBackColor = true;
            // 
            // panPatientInfoEntry
            // 
            this.panPatientInfoEntry.Controls.Add(this.panDNRIndicator);
            this.panPatientInfoEntry.Controls.Add(this.panFallRiskIndicator);
            this.panPatientInfoEntry.Controls.Add(this.panAllergyIndicator);
            this.panPatientInfoEntry.Controls.Add(this.chkIsDNR);
            this.panPatientInfoEntry.Controls.Add(this.chkIsFallRisk);
            this.panPatientInfoEntry.Controls.Add(this.txtAllergyInfo);
            this.panPatientInfoEntry.Controls.Add(this.lblAllergyInfo);
            this.panPatientInfoEntry.Controls.Add(this.chkIsAllergy);
            this.panPatientInfoEntry.Controls.Add(this.optFemale);
            this.panPatientInfoEntry.Controls.Add(this.optMale);
            this.panPatientInfoEntry.Controls.Add(this.lblLabelType);
            this.panPatientInfoEntry.Controls.Add(this.label6);
            this.panPatientInfoEntry.Controls.Add(this.label5);
            this.panPatientInfoEntry.Controls.Add(this.txtAgeInDay);
            this.panPatientInfoEntry.Controls.Add(this.txtAgeInMonth);
            this.panPatientInfoEntry.Controls.Add(this.txtAgeInYear);
            this.panPatientInfoEntry.Controls.Add(this.label3);
            this.panPatientInfoEntry.Controls.Add(this.dteDateOfBirth);
            this.panPatientInfoEntry.Controls.Add(this.label2);
            this.panPatientInfoEntry.Controls.Add(this.label4);
            this.panPatientInfoEntry.Location = new System.Drawing.Point(9, 220);
            this.panPatientInfoEntry.Name = "panPatientInfoEntry";
            this.panPatientInfoEntry.Size = new System.Drawing.Size(594, 160);
            this.panPatientInfoEntry.TabIndex = 6;
            this.panPatientInfoEntry.Visible = false;
            // 
            // panDNRIndicator
            // 
            this.panDNRIndicator.BackColor = System.Drawing.Color.Purple;
            this.panDNRIndicator.Location = new System.Drawing.Point(74, 127);
            this.panDNRIndicator.Name = "panDNRIndicator";
            this.panDNRIndicator.Size = new System.Drawing.Size(36, 14);
            this.panDNRIndicator.TabIndex = 24;
            this.panDNRIndicator.Visible = false;
            // 
            // panFallRiskIndicator
            // 
            this.panFallRiskIndicator.BackColor = System.Drawing.Color.Yellow;
            this.panFallRiskIndicator.Location = new System.Drawing.Point(74, 106);
            this.panFallRiskIndicator.Name = "panFallRiskIndicator";
            this.panFallRiskIndicator.Size = new System.Drawing.Size(36, 14);
            this.panFallRiskIndicator.TabIndex = 22;
            this.panFallRiskIndicator.Visible = false;
            // 
            // panAllergyIndicator
            // 
            this.panAllergyIndicator.BackColor = System.Drawing.Color.Red;
            this.panAllergyIndicator.Location = new System.Drawing.Point(74, 84);
            this.panAllergyIndicator.Name = "panAllergyIndicator";
            this.panAllergyIndicator.Size = new System.Drawing.Size(36, 14);
            this.panAllergyIndicator.TabIndex = 18;
            // 
            // chkIsDNR
            // 
            this.chkIsDNR.AutoSize = true;
            this.chkIsDNR.Location = new System.Drawing.Point(116, 128);
            this.chkIsDNR.Name = "chkIsDNR";
            this.chkIsDNR.Size = new System.Drawing.Size(168, 17);
            this.chkIsDNR.TabIndex = 25;
            this.chkIsDNR.Text = "DO NOT RESUSCITATE (DNR)";
            this.chkIsDNR.UseVisualStyleBackColor = false;
            // 
            // chkIsFallRisk
            // 
            this.chkIsFallRisk.AutoSize = true;
            this.chkIsFallRisk.Location = new System.Drawing.Point(116, 105);
            this.chkIsFallRisk.Name = "chkIsFallRisk";
            this.chkIsFallRisk.Size = new System.Drawing.Size(64, 17);
            this.chkIsFallRisk.TabIndex = 23;
            this.chkIsFallRisk.Text = "Fall Risk";
            this.chkIsFallRisk.UseVisualStyleBackColor = false;
            // 
            // txtAllergyInfo
            // 
            this.txtAllergyInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAllergyInfo.Location = new System.Drawing.Point(380, 80);
            this.txtAllergyInfo.Name = "txtAllergyInfo";
            this.txtAllergyInfo.Size = new System.Drawing.Size(171, 21);
            this.txtAllergyInfo.TabIndex = 21;
            // 
            // lblAllergyInfo
            // 
            this.lblAllergyInfo.AutoSize = true;
            this.lblAllergyInfo.Location = new System.Drawing.Point(276, 84);
            this.lblAllergyInfo.Name = "lblAllergyInfo";
            this.lblAllergyInfo.Size = new System.Drawing.Size(99, 13);
            this.lblAllergyInfo.TabIndex = 20;
            this.lblAllergyInfo.Text = "Allergy Information";
            this.lblAllergyInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkIsAllergy
            // 
            this.chkIsAllergy.AutoSize = true;
            this.chkIsAllergy.Location = new System.Drawing.Point(116, 82);
            this.chkIsAllergy.Name = "chkIsAllergy";
            this.chkIsAllergy.Size = new System.Drawing.Size(59, 17);
            this.chkIsAllergy.TabIndex = 19;
            this.chkIsAllergy.Text = "Allergy";
            this.chkIsAllergy.UseVisualStyleBackColor = false;
            // 
            // optFemale
            // 
            this.optFemale.AutoSize = true;
            this.optFemale.Location = new System.Drawing.Point(433, 8);
            this.optFemale.Name = "optFemale";
            this.optFemale.Size = new System.Drawing.Size(111, 17);
            this.optFemale.TabIndex = 5;
            this.optFemale.Text = "Large (Packaging)";
            this.optFemale.UseVisualStyleBackColor = true;
            // 
            // optMale
            // 
            this.optMale.AutoSize = true;
            this.optMale.Checked = true;
            this.optMale.Location = new System.Drawing.Point(380, 8);
            this.optMale.Name = "optMale";
            this.optMale.Size = new System.Drawing.Size(49, 17);
            this.optMale.TabIndex = 3;
            this.optMale.TabStop = true;
            this.optMale.Text = "Small";
            this.optMale.UseVisualStyleBackColor = true;
            // 
            // lblLabelType
            // 
            this.lblLabelType.AutoSize = true;
            this.lblLabelType.Location = new System.Drawing.Point(289, 10);
            this.lblLabelType.Name = "lblLabelType";
            this.lblLabelType.Size = new System.Drawing.Size(59, 13);
            this.lblLabelType.TabIndex = 2;
            this.lblLabelType.Text = "Label Type";
            this.lblLabelType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(526, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "hari";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(472, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "bln";
            // 
            // txtAgeInDay
            // 
            this.txtAgeInDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAgeInDay.Location = new System.Drawing.Point(493, 54);
            this.txtAgeInDay.Name = "txtAgeInDay";
            this.txtAgeInDay.Size = new System.Drawing.Size(32, 21);
            this.txtAgeInDay.TabIndex = 11;
            this.txtAgeInDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAgeInMonth
            // 
            this.txtAgeInMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAgeInMonth.Location = new System.Drawing.Point(439, 54);
            this.txtAgeInMonth.Name = "txtAgeInMonth";
            this.txtAgeInMonth.Size = new System.Drawing.Size(32, 21);
            this.txtAgeInMonth.TabIndex = 14;
            this.txtAgeInMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAgeInYear
            // 
            this.txtAgeInYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAgeInYear.Location = new System.Drawing.Point(380, 54);
            this.txtAgeInYear.Name = "txtAgeInYear";
            this.txtAgeInYear.Size = new System.Drawing.Size(32, 21);
            this.txtAgeInYear.TabIndex = 13;
            this.txtAgeInYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(345, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Age";
            // 
            // dteDateOfBirth
            // 
            this.dteDateOfBirth.CustomFormat = "dd-MMM-yyyy";
            this.dteDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteDateOfBirth.Location = new System.Drawing.Point(116, 55);
            this.dteDateOfBirth.Name = "dteDateOfBirth";
            this.dteDateOfBirth.Size = new System.Drawing.Size(100, 21);
            this.dteDateOfBirth.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Date of Birth";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(414, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "thn";
            // 
            // txtItemName
            // 
            this.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemName.Location = new System.Drawing.Point(85, 31);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(336, 21);
            this.txtItemName.TabIndex = 7;
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.Location = new System.Drawing.Point(25, 13);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(57, 13);
            this.lblItemCode.TabIndex = 0;
            this.lblItemCode.Text = "Item Code";
            this.lblItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemCode
            // 
            this.txtItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemCode.Location = new System.Drawing.Point(85, 9);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(115, 21);
            this.txtItemCode.TabIndex = 1;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(23, 35);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(59, 13);
            this.lblFirstName.TabIndex = 6;
            this.lblFirstName.Text = "Item Name";
            this.lblFirstName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Short Name";
            // 
            // txtShortName
            // 
            this.txtShortName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShortName.Location = new System.Drawing.Point(85, 53);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(208, 21);
            this.txtShortName.TabIndex = 9;
            // 
            // pagMultiItem
            // 
            this.pagMultiItem.Controls.Add(this.grdItem);
            this.pagMultiItem.Controls.Add(this.panel2);
            this.pagMultiItem.Location = new System.Drawing.Point(4, 22);
            this.pagMultiItem.Name = "pagMultiItem";
            this.pagMultiItem.Padding = new System.Windows.Forms.Padding(3);
            this.pagMultiItem.Size = new System.Drawing.Size(786, 233);
            this.pagMultiItem.TabIndex = 0;
            this.pagMultiItem.Text = "Multi-Item Print";
            this.pagMultiItem.UseVisualStyleBackColor = true;
            // 
            // grdItem
            // 
            this.grdItem.AllowUserToAddRows = false;
            this.grdItem.AllowUserToDeleteRows = false;
            this.grdItem.AllowUserToResizeColumns = false;
            this.grdItem.AllowUserToResizeRows = false;
            this.grdItem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grdItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemCode,
            this.colItemName,
            this.colShortName});
            this.grdItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdItem.Location = new System.Drawing.Point(3, 32);
            this.grdItem.Name = "grdItem";
            this.grdItem.RowHeadersVisible = false;
            this.grdItem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdItem.ShowEditingIcon = false;
            this.grdItem.ShowRowErrors = false;
            this.grdItem.Size = new System.Drawing.Size(780, 198);
            this.grdItem.TabIndex = 22;
            // 
            // colItemCode
            // 
            this.colItemCode.DataPropertyName = "ItemCode";
            this.colItemCode.HeaderText = "Item Code";
            this.colItemCode.Name = "colItemCode";
            this.colItemCode.ReadOnly = true;
            // 
            // colItemName
            // 
            this.colItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colItemName.DataPropertyName = "ItemName";
            this.colItemName.HeaderText = "Item Name";
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            // 
            // colShortName
            // 
            this.colShortName.DataPropertyName = "ShortName";
            this.colShortName.HeaderText = "Short Name";
            this.colShortName.Name = "colShortName";
            this.colShortName.ReadOnly = true;
            this.colShortName.Visible = false;
            this.colShortName.Width = 200;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnApplyFilter);
            this.panel2.Controls.Add(this.txtQuickFilter);
            this.panel2.Controls.Add(this.lblQuickSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(780, 29);
            this.panel2.TabIndex = 24;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(496, 4);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(95, 21);
            this.btnApplyFilter.TabIndex = 25;
            this.btnApplyFilter.Text = "Apply Filter";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // txtQuickFilter
            // 
            this.txtQuickFilter.Location = new System.Drawing.Point(93, 4);
            this.txtQuickFilter.Name = "txtQuickFilter";
            this.txtQuickFilter.Size = new System.Drawing.Size(400, 21);
            this.txtQuickFilter.TabIndex = 24;
            this.txtQuickFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuickFilter_KeyDown);
            // 
            // lblQuickSearch
            // 
            this.lblQuickSearch.AutoSize = true;
            this.lblQuickSearch.Location = new System.Drawing.Point(8, 8);
            this.lblQuickSearch.Name = "lblQuickSearch";
            this.lblQuickSearch.Size = new System.Drawing.Size(60, 13);
            this.lblQuickSearch.TabIndex = 23;
            this.lblQuickSearch.Text = "Quick Filter";
            // 
            // panLabelPreview
            // 
            this.panLabelPreview.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panLabelPreview.Controls.Add(this.panel3);
            this.panLabelPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panLabelPreview.Location = new System.Drawing.Point(0, 31);
            this.panLabelPreview.Name = "panLabelPreview";
            this.panLabelPreview.Size = new System.Drawing.Size(794, 123);
            this.panLabelPreview.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblPreviewLine1);
            this.panel3.Controls.Add(this.lblPreviewLine3);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(8, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(230, 94);
            this.panel3.TabIndex = 20;
            // 
            // lblPreviewLine1
            // 
            this.lblPreviewLine1.AutoSize = true;
            this.lblPreviewLine1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreviewLine1.Location = new System.Drawing.Point(3, 0);
            this.lblPreviewLine1.Name = "lblPreviewLine1";
            this.lblPreviewLine1.Size = new System.Drawing.Size(77, 16);
            this.lblPreviewLine1.TabIndex = 17;
            this.lblPreviewLine1.Text = "Item Name";
            this.lblPreviewLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPreviewLine3
            // 
            this.lblPreviewLine3.AutoSize = true;
            this.lblPreviewLine3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreviewLine3.Location = new System.Drawing.Point(40, 76);
            this.lblPreviewLine3.Name = "lblPreviewLine3";
            this.lblPreviewLine3.Size = new System.Drawing.Size(66, 13);
            this.lblPreviewLine3.TabIndex = 19;
            this.lblPreviewLine3.Text = "Item Code";
            this.lblPreviewLine3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::CodeX.DesktopTool.Print.Properties.Resources.barcode128;
            this.pictureBox1.InitialImage = global::CodeX.DesktopTool.Print.Properties.Resources.barcode128;
            this.pictureBox1.Location = new System.Drawing.Point(6, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // panPreviewTitle
            // 
            this.panPreviewTitle.BackColor = System.Drawing.Color.DodgerBlue;
            this.panPreviewTitle.Controls.Add(this.label7);
            this.panPreviewTitle.Controls.Add(this.cboLabelType);
            this.panPreviewTitle.Controls.Add(this.lblLabelPreviewTitle);
            this.panPreviewTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panPreviewTitle.Location = new System.Drawing.Point(0, 0);
            this.panPreviewTitle.Name = "panPreviewTitle";
            this.panPreviewTitle.Size = new System.Drawing.Size(794, 31);
            this.panPreviewTitle.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(532, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 16);
            this.label7.TabIndex = 31;
            this.label7.Text = "Label Type :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboLabelType
            // 
            this.cboLabelType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLabelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLabelType.FormattingEnabled = true;
            this.cboLabelType.Location = new System.Drawing.Point(621, 6);
            this.cboLabelType.Name = "cboLabelType";
            this.cboLabelType.Size = new System.Drawing.Size(166, 21);
            this.cboLabelType.TabIndex = 30;
            // 
            // lblLabelPreviewTitle
            // 
            this.lblLabelPreviewTitle.AutoSize = true;
            this.lblLabelPreviewTitle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelPreviewTitle.ForeColor = System.Drawing.Color.White;
            this.lblLabelPreviewTitle.Location = new System.Drawing.Point(5, 7);
            this.lblLabelPreviewTitle.Name = "lblLabelPreviewTitle";
            this.lblLabelPreviewTitle.Size = new System.Drawing.Size(107, 16);
            this.lblLabelPreviewTitle.TabIndex = 18;
            this.lblLabelPreviewTitle.Text = "Label Preview :";
            this.lblLabelPreviewTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLabelPreviewTitle.Click += new System.EventHandler(this.lblLabelPreviewTitle_Click);
            // 
            // panPreview
            // 
            this.panPreview.Controls.Add(this.panLabelPreview);
            this.panPreview.Controls.Add(this.panPreviewTitle);
            this.panPreview.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panPreview.Location = new System.Drawing.Point(0, 290);
            this.panPreview.Name = "panPreview";
            this.panPreview.Size = new System.Drawing.Size(794, 154);
            this.panPreview.TabIndex = 4;
            // 
            // panMainContent
            // 
            this.panMainContent.Controls.Add(this.panPatientInformation);
            this.panMainContent.Controls.Add(this.panToolbar);
            this.panMainContent.Controls.Add(this.panPreview);
            this.panMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMainContent.Location = new System.Drawing.Point(0, 0);
            this.panMainContent.Name = "panMainContent";
            this.panMainContent.Size = new System.Drawing.Size(794, 444);
            this.panMainContent.TabIndex = 5;
            // 
            // panPatientInformation
            // 
            this.panPatientInformation.Controls.Add(this.tabItemInformation);
            this.panPatientInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panPatientInformation.Location = new System.Drawing.Point(0, 31);
            this.panPatientInformation.Name = "panPatientInformation";
            this.panPatientInformation.Size = new System.Drawing.Size(794, 259);
            this.panPatientInformation.TabIndex = 6;
            // 
            // panToolbar
            // 
            this.panToolbar.BackColor = System.Drawing.Color.DodgerBlue;
            this.panToolbar.Controls.Add(this.cboDatabase);
            this.panToolbar.Controls.Add(this.btnPrinterStatus);
            this.panToolbar.Controls.Add(this.label8);
            this.panToolbar.Controls.Add(this.btnConfiguration);
            this.panToolbar.Controls.Add(this.optLocalDB);
            this.panToolbar.Controls.Add(this.optRemoteDB);
            this.panToolbar.Controls.Add(this.btnRefreshLocalDB);
            this.panToolbar.Controls.Add(this.btnPrintLabel);
            this.panToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panToolbar.Location = new System.Drawing.Point(0, 0);
            this.panToolbar.Name = "panToolbar";
            this.panToolbar.Size = new System.Drawing.Size(794, 31);
            this.panToolbar.TabIndex = 5;
            // 
            // cboDatabase
            // 
            this.cboDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDatabase.FormattingEnabled = true;
            this.cboDatabase.Location = new System.Drawing.Point(126, 5);
            this.cboDatabase.Name = "cboDatabase";
            this.cboDatabase.Size = new System.Drawing.Size(191, 21);
            this.cboDatabase.TabIndex = 11;
            // 
            // btnPrinterStatus
            // 
            this.btnPrinterStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPrinterStatus.Location = new System.Drawing.Point(388, 0);
            this.btnPrinterStatus.Name = "btnPrinterStatus";
            this.btnPrinterStatus.Size = new System.Drawing.Size(95, 31);
            this.btnPrinterStatus.TabIndex = 3;
            this.btnPrinterStatus.Text = "Printer Status";
            this.btnPrinterStatus.UseVisualStyleBackColor = true;
            this.btnPrinterStatus.Visible = false;
            this.btnPrinterStatus.Click += new System.EventHandler(this.btnPrinterStatus_Click);
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label8.Size = new System.Drawing.Size(123, 31);
            this.label8.TabIndex = 10;
            this.label8.Text = "Connect to Database";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnConfiguration
            // 
            this.btnConfiguration.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnConfiguration.Location = new System.Drawing.Point(483, 0);
            this.btnConfiguration.Name = "btnConfiguration";
            this.btnConfiguration.Size = new System.Drawing.Size(95, 31);
            this.btnConfiguration.TabIndex = 2;
            this.btnConfiguration.Text = "Configuration";
            this.btnConfiguration.UseVisualStyleBackColor = true;
            this.btnConfiguration.Click += new System.EventHandler(this.btnConfiguration_Click);
            // 
            // optLocalDB
            // 
            this.optLocalDB.AutoSize = true;
            this.optLocalDB.Checked = true;
            this.optLocalDB.Location = new System.Drawing.Point(108, 7);
            this.optLocalDB.Name = "optLocalDB";
            this.optLocalDB.Size = new System.Drawing.Size(98, 17);
            this.optLocalDB.TabIndex = 6;
            this.optLocalDB.TabStop = true;
            this.optLocalDB.Text = "Local Database";
            this.optLocalDB.UseVisualStyleBackColor = true;
            this.optLocalDB.Visible = false;
            // 
            // optRemoteDB
            // 
            this.optRemoteDB.AutoSize = true;
            this.optRemoteDB.Location = new System.Drawing.Point(206, 7);
            this.optRemoteDB.Name = "optRemoteDB";
            this.optRemoteDB.Size = new System.Drawing.Size(111, 17);
            this.optRemoteDB.TabIndex = 5;
            this.optRemoteDB.Text = "Remote Database";
            this.optRemoteDB.UseVisualStyleBackColor = true;
            this.optRemoteDB.Visible = false;
            this.optRemoteDB.CheckedChanged += new System.EventHandler(this.optConnectionMode_CheckedChanged);
            // 
            // btnRefreshLocalDB
            // 
            this.btnRefreshLocalDB.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefreshLocalDB.Location = new System.Drawing.Point(578, 0);
            this.btnRefreshLocalDB.Name = "btnRefreshLocalDB";
            this.btnRefreshLocalDB.Size = new System.Drawing.Size(108, 31);
            this.btnRefreshLocalDB.TabIndex = 4;
            this.btnRefreshLocalDB.Text = "Update Local DB";
            this.btnRefreshLocalDB.UseVisualStyleBackColor = true;
            this.btnRefreshLocalDB.Click += new System.EventHandler(this.btnRefreshLocalDB_Click);
            // 
            // btnPrintLabel
            // 
            this.btnPrintLabel.BackColor = System.Drawing.Color.Red;
            this.btnPrintLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPrintLabel.Location = new System.Drawing.Point(686, 0);
            this.btnPrintLabel.Name = "btnPrintLabel";
            this.btnPrintLabel.Size = new System.Drawing.Size(108, 31);
            this.btnPrintLabel.TabIndex = 1;
            this.btnPrintLabel.Text = "Print Label";
            this.btnPrintLabel.UseVisualStyleBackColor = false;
            this.btnPrintLabel.Click += new System.EventHandler(this.btnPrintLabel_Click);
            // 
            // panRecentList
            // 
            this.panRecentList.BackColor = System.Drawing.Color.White;
            this.panRecentList.Controls.Add(this.grdPatient);
            this.panRecentList.Controls.Add(this.panel1);
            this.panRecentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRecentList.Location = new System.Drawing.Point(0, 0);
            this.panRecentList.Name = "panRecentList";
            this.panRecentList.Size = new System.Drawing.Size(96, 100);
            this.panRecentList.TabIndex = 6;
            // 
            // grdPatient
            // 
            this.grdPatient.AllowUserToAddRows = false;
            this.grdPatient.AllowUserToDeleteRows = false;
            this.grdPatient.AllowUserToResizeColumns = false;
            this.grdPatient.AllowUserToResizeRows = false;
            this.grdPatient.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grdPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMRN,
            this.PrintNo});
            this.grdPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPatient.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdPatient.Location = new System.Drawing.Point(0, 31);
            this.grdPatient.MultiSelect = false;
            this.grdPatient.Name = "grdPatient";
            this.grdPatient.ReadOnly = true;
            this.grdPatient.RowHeadersVisible = false;
            this.grdPatient.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPatient.ShowEditingIcon = false;
            this.grdPatient.ShowRowErrors = false;
            this.grdPatient.Size = new System.Drawing.Size(96, 69);
            this.grdPatient.TabIndex = 20;
            // 
            // colMRN
            // 
            this.colMRN.DataPropertyName = "MRN";
            this.colMRN.HeaderText = "Item Code";
            this.colMRN.Name = "colMRN";
            this.colMRN.ReadOnly = true;
            this.colMRN.Width = 130;
            // 
            // PrintNo
            // 
            this.PrintNo.HeaderText = "#Print ";
            this.PrintNo.Name = "PrintNo";
            this.PrintNo.ReadOnly = true;
            this.PrintNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PrintNo.Width = 50;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.label20);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(96, 31);
            this.panel1.TabIndex = 4;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(5, 7);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(82, 16);
            this.label20.TabIndex = 18;
            this.label20.Text = "Today Print";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panMainContent);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panRecentList);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(794, 444);
            this.splitContainer1.SplitterDistance = 608;
            this.splitContainer1.TabIndex = 7;
            // 
            // LabelPrintCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LabelPrintCtl";
            this.Size = new System.Drawing.Size(794, 444);
            this.tabItemInformation.ResumeLayout(false);
            this.pagSinglePrint.ResumeLayout(false);
            this.pagSinglePrint.PerformLayout();
            this.panPatientInfoEntry.ResumeLayout(false);
            this.panPatientInfoEntry.PerformLayout();
            this.pagMultiItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panLabelPreview.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panPreviewTitle.ResumeLayout(false);
            this.panPreviewTitle.PerformLayout();
            this.panPreview.ResumeLayout(false);
            this.panMainContent.ResumeLayout(false);
            this.panPatientInformation.ResumeLayout(false);
            this.panToolbar.ResumeLayout(false);
            this.panToolbar.PerformLayout();
            this.panRecentList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPatient)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabItemInformation;
        private System.Windows.Forms.TabPage pagMultiItem;
        private System.Windows.Forms.Panel panLabelPreview;
        private System.Windows.Forms.Label lblPreviewLine1;
        private System.Windows.Forms.Label lblPreviewLine3;
        private System.Windows.Forms.Panel panPreviewTitle;
        private System.Windows.Forms.Label lblLabelPreviewTitle;
        private System.Windows.Forms.Panel panPreview;
        private System.Windows.Forms.Panel panMainContent;
        private System.Windows.Forms.Panel panRecentList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnPrintLabel;
        private System.Windows.Forms.Panel panPatientInformation;
        private System.Windows.Forms.Panel panToolbar;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnConfiguration;
        private System.Windows.Forms.Button btnPrinterStatus;
        private System.Windows.Forms.Button btnRefreshLocalDB;
        private System.Windows.Forms.DataGridView grdItem;
        private System.Windows.Forms.DataGridView grdPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMRN;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrintNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboLabelType;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtQuickFilter;
        private System.Windows.Forms.Label lblQuickSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShortName;
        private System.Windows.Forms.TabPage pagSinglePrint;
        private System.Windows.Forms.Panel panPatientInfoEntry;
        private System.Windows.Forms.Panel panDNRIndicator;
        private System.Windows.Forms.Panel panFallRiskIndicator;
        private System.Windows.Forms.Panel panAllergyIndicator;
        private System.Windows.Forms.CheckBox chkIsDNR;
        private System.Windows.Forms.CheckBox chkIsFallRisk;
        private System.Windows.Forms.TextBox txtAllergyInfo;
        private System.Windows.Forms.Label lblAllergyInfo;
        private System.Windows.Forms.CheckBox chkIsAllergy;
        private System.Windows.Forms.RadioButton optFemale;
        private System.Windows.Forms.RadioButton optMale;
        private System.Windows.Forms.Label lblLabelType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAgeInDay;
        private System.Windows.Forms.TextBox txtAgeInMonth;
        private System.Windows.Forms.TextBox txtAgeInYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dteDateOfBirth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton optLocalDB;
        private System.Windows.Forms.RadioButton optRemoteDB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboDatabase;
    }
}
