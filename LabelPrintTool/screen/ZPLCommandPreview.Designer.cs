namespace CodeX.DesktopTool.Print
{
    partial class ZPLCommandPreview
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
            this.memCommand = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // memCommand
            // 
            this.memCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memCommand.ForeColor = System.Drawing.Color.Maroon;
            this.memCommand.Location = new System.Drawing.Point(0, 0);
            this.memCommand.Name = "memCommand";
            this.memCommand.ReadOnly = true;
            this.memCommand.Size = new System.Drawing.Size(381, 173);
            this.memCommand.TabIndex = 9;
            this.memCommand.Text = "";
            // 
            // ZPLCommandPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 173);
            this.Controls.Add(this.memCommand);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ZPLCommandPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ZPL Command - Preview";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox memCommand;
    }
}