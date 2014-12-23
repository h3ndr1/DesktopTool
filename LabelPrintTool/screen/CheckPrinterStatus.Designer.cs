namespace CodeX.DesktopTool.Print
{
    partial class CheckPrinterStatus
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
            this.btnPrinterStatus = new System.Windows.Forms.Button();
            this.btnCartridgeType = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtCartridgeType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstPrinter = new System.Windows.Forms.ListBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnPrinterStatus
            // 
            this.btnPrinterStatus.Location = new System.Drawing.Point(141, 81);
            this.btnPrinterStatus.Name = "btnPrinterStatus";
            this.btnPrinterStatus.Size = new System.Drawing.Size(87, 29);
            this.btnPrinterStatus.TabIndex = 0;
            this.btnPrinterStatus.Text = "Printer Status";
            this.btnPrinterStatus.UseVisualStyleBackColor = true;
            this.btnPrinterStatus.Click += new System.EventHandler(this.btnPrinterStatus_Click);
            // 
            // btnCartridgeType
            // 
            this.btnCartridgeType.Location = new System.Drawing.Point(234, 81);
            this.btnCartridgeType.Name = "btnCartridgeType";
            this.btnCartridgeType.Size = new System.Drawing.Size(87, 29);
            this.btnCartridgeType.TabIndex = 3;
            this.btnCartridgeType.Text = "Cartrige Type";
            this.btnCartridgeType.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Printer Model";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(102, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(295, 21);
            this.textBox1.TabIndex = 5;
            // 
            // txtCartridgeType
            // 
            this.txtCartridgeType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCartridgeType.Location = new System.Drawing.Point(102, 38);
            this.txtCartridgeType.Name = "txtCartridgeType";
            this.txtCartridgeType.ReadOnly = true;
            this.txtCartridgeType.Size = new System.Drawing.Size(295, 21);
            this.txtCartridgeType.TabIndex = 7;
            this.txtCartridgeType.Text = "Cartridge Type (Part Number : )";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cartridge Type";
            // 
            // lstPrinter
            // 
            this.lstPrinter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstPrinter.FormattingEnabled = true;
            this.lstPrinter.Location = new System.Drawing.Point(0, 228);
            this.lstPrinter.Name = "lstPrinter";
            this.lstPrinter.ScrollAlwaysVisible = true;
            this.lstPrinter.Size = new System.Drawing.Size(458, 134);
            this.lstPrinter.TabIndex = 2;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBox1.Location = new System.Drawing.Point(0, 132);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(458, 96);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // CheckPrinterStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 362);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.txtCartridgeType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCartridgeType);
            this.Controls.Add(this.lstPrinter);
            this.Controls.Add(this.btnPrinterStatus);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CheckPrinterStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Printer Status";
            this.Load += new System.EventHandler(this.CheckPrinterStatus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrinterStatus;
        private System.Windows.Forms.Button btnCartridgeType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtCartridgeType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstPrinter;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}