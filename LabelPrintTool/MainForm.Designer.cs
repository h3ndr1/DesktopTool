namespace CodeX.DesktopTool.Print
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.stbMain = new System.Windows.Forms.StatusStrip();
            this.lblPrinterStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCurrentDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCurrentTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCopyrightInformation = new System.Windows.Forms.ToolStripStatusLabel();
            this.stbStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panContent = new System.Windows.Forms.Panel();
            this.panEntry = new System.Windows.Forms.Panel();
            this.panRecentList = new System.Windows.Forms.Panel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.printControl = new CodeX.DesktopTool.Print.Controls.LabelPrintCtl();
            this.stbMain.SuspendLayout();
            this.panContent.SuspendLayout();
            this.panEntry.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // stbMain
            // 
            this.stbMain.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblPrinterStatus,
            this.lblConnectionStatus,
            this.lblCurrentDate,
            this.lblCurrentTime,
            this.lblCopyrightInformation});
            this.stbMain.Location = new System.Drawing.Point(0, 550);
            this.stbMain.Name = "stbMain";
            this.stbMain.Size = new System.Drawing.Size(762, 22);
            this.stbMain.TabIndex = 0;
            this.stbMain.Text = "statusStrip1";
            // 
            // lblPrinterStatus
            // 
            this.lblPrinterStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblPrinterStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrinterStatus.Name = "lblPrinterStatus";
            this.lblPrinterStatus.Size = new System.Drawing.Size(493, 17);
            this.lblPrinterStatus.Spring = true;
            this.lblPrinterStatus.Text = "Printer Status";
            this.lblPrinterStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblConnectionStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionStatus.ForeColor = System.Drawing.Color.Red;
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(118, 17);
            this.lblConnectionStatus.Text = "No Internet Access";
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(79, 17);
            this.lblCurrentDate.Text = "dd-MMM-yyyy";
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(57, 17);
            this.lblCurrentTime.Text = "hh:mm:ss";
            // 
            // lblCopyrightInformation
            // 
            this.lblCopyrightInformation.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblCopyrightInformation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblCopyrightInformation.Name = "lblCopyrightInformation";
            this.lblCopyrightInformation.Size = new System.Drawing.Size(197, 17);
            this.lblCopyrightInformation.Text = "Copyright © 2014, The Ronin Warriors";
            this.lblCopyrightInformation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCopyrightInformation.Visible = false;
            // 
            // stbStatusText
            // 
            this.stbStatusText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stbStatusText.Name = "stbStatusText";
            this.stbStatusText.Size = new System.Drawing.Size(423, 17);
            this.stbStatusText.Spring = true;
            this.stbStatusText.Text = "[Application Status]";
            this.stbStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(81, 17);
            this.toolStripStatusLabel2.Text = "[Printer Name]";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(243, 17);
            this.toolStripStatusLabel1.Text = "Copyright © 2012, PT. Quantum Infra Solusindo";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panContent
            // 
            this.panContent.BackColor = System.Drawing.Color.White;
            this.panContent.Controls.Add(this.panEntry);
            this.panContent.Controls.Add(this.panRecentList);
            this.panContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panContent.Location = new System.Drawing.Point(0, 0);
            this.panContent.Name = "panContent";
            this.panContent.Size = new System.Drawing.Size(762, 550);
            this.panContent.TabIndex = 2;
            // 
            // panEntry
            // 
            this.panEntry.Controls.Add(this.printControl);
            this.panEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panEntry.Location = new System.Drawing.Point(0, 0);
            this.panEntry.Name = "panEntry";
            this.panEntry.Size = new System.Drawing.Size(762, 550);
            this.panEntry.TabIndex = 3;
            // 
            // panRecentList
            // 
            this.panRecentList.Location = new System.Drawing.Point(395, 274);
            this.panRecentList.Name = "panRecentList";
            this.panRecentList.Size = new System.Drawing.Size(200, 100);
            this.panRecentList.TabIndex = 2;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(762, 547);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(762, 572);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(762, 547);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.Size = new System.Drawing.Size(762, 572);
            this.toolStripContainer2.TabIndex = 1;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // printControl
            // 
            this.printControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printControl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printControl.IsPrinterOnline = false;
            this.printControl.Location = new System.Drawing.Point(0, 0);
            this.printControl.Name = "printControl";
            this.printControl.Size = new System.Drawing.Size(762, 550);
            this.printControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 572);
            this.Controls.Add(this.panContent);
            this.Controls.Add(this.stbMain);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.toolStripContainer2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(768, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeX - Label Print Tool";
            this.stbMain.ResumeLayout(false);
            this.stbMain.PerformLayout();
            this.panContent.ResumeLayout(false);
            this.panEntry.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stbMain;
        private System.Windows.Forms.ToolStripStatusLabel stbStatusText;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Panel panContent;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private System.Windows.Forms.Panel panEntry;
        private System.Windows.Forms.Panel panRecentList;
        private System.Windows.Forms.ToolStripStatusLabel lblPrinterStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblConnectionStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblCopyrightInformation;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentDate;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentTime;
        private System.Windows.Forms.Timer timer1;
        private Controls.LabelPrintCtl printControl;
    }
}