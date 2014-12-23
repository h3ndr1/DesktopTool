using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeX.DesktopTool.Print.Properties;
using System.Drawing.Printing;

namespace CodeX.DesktopTool.Print
{
    public partial class ApplicationSetting : Form
    {
        public ApplicationSetting()
        {
            InitializeComponent();

            chkUseNetworkPrinter.CheckedChanged += new EventHandler(chkUseNetworkPrinter_CheckedChanged);

            this.Text = string.Format("{0} - {1}", Constant.APP_ApplicationName, this.Text);
            InitializePrinterSettings();
            InitializeDataSourceConfig();
        }

        #region Event Handlers
        private void chkUseNetworkPrinter_CheckedChanged(object sender, EventArgs e)
        {
            cboCheckPrinterStatus.Enabled = !chkUseNetworkPrinter.Checked;
        }

        #endregion
        private void InitializePrinterSettings()
        {
            LoadPrinterList();
            LoadPrinterModelList();
            cboBarcodeType.Text = Settings.Default.BarcodeType;

            cboAutoSaveLog.Text = Settings.Default.AutoSaveLogFile.ToString();
            chkClearLog.Checked = Settings.Default.ClearLogFileWhenExit;

            chkUseNetworkPrinter.Checked = Settings.Default.UseNetworkPrinter;
            cboCheckPrinterStatus.Text = Settings.Default.CheckPrinterStatusInterval.ToString();
        }

        private void LoadPrinterModelList()
        {
            foreach (string item in ZebraPrinterLib.ZebraPrinterList)
            {
                cboPrinterModel.Items.Add(item);
            }
        }

        private void InitializeDataSourceConfig()
        {
        }

        private void LoadPrinterList()
        {
            string defaultPrinter = !string.IsNullOrWhiteSpace(Settings.Default.LabelPrinterName.ToString()) ? Settings.Default.LabelPrinterName : string.Empty;
            foreach (string printerName in PrinterSettings.InstalledPrinters)
            {
                PrinterSettings printer = new PrinterSettings();
                printer.PrinterName = printerName;


                if (string.IsNullOrWhiteSpace(defaultPrinter))
                {
                    if (printer.IsDefaultPrinter)
                        defaultPrinter = printer.PrinterName;
                }

                if (printer.IsValid)
                    cboPrinterList.Items.Add(printer.PrinterName);
            }

            if (cboPrinterList.Items.Count > 0)
            {
                cboPrinterList.Text = defaultPrinter;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            #region Printer Configuration
            Settings.Default.LabelPrinterName = cboPrinterList.Text;
            Settings.Default.UseNetworkPrinter = chkUseNetworkPrinter.Checked;
            Settings.Default.CheckPrinterStatusInterval = Convert.ToInt16(cboCheckPrinterStatus.Text);            
            #endregion
            Settings.Default.BarcodeType = cboBarcodeType.Text;

            Settings.Default.AutoSaveLogFile = Convert.ToInt16(cboAutoSaveLog.Text);
            Settings.Default.ClearLogFileWhenExit = chkClearLog.Checked;

            //Settings.Default.DataMode = cboDataMode.EditValue.ToString();
            //Settings.Default.RemoteDataPath = txtRemoteDataPath.Text;

            Settings.Default.Save();
            this.Close();
            MessageBox.Show("You've change some application configuration. Application will be restart.", "Configuration Change", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
