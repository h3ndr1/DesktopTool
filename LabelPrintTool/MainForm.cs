using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeX.DesktopTool.Print.Properties;

namespace CodeX.DesktopTool.Print
{
    public partial class MainForm : Form
    {
        private string _companyName = string.Empty;
        private DateTime _selectedDate;
        private bool _isPrinterOnline;
        private bool _isConnectToInternet;
        private bool _isLocalDBAvailable;

        public bool IsConnectToInternet
        {
            get { return _isConnectToInternet; }
            set { _isConnectToInternet = value; }
        }
        public bool IsLocalDBAvailable
        {
            get { return _isLocalDBAvailable; }
            set { _isLocalDBAvailable = value; }
        }

        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }
        public bool IsPrinterOnline
        {
            get { return _isPrinterOnline; }
            set { _isPrinterOnline = value; printControl.IsPrinterOnline = _isPrinterOnline; }
        }
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set { _selectedDate = value; /*lblSelectedDate.Caption = value.ToString(Constant.DATE_FORMAT_1);*/ }
        }

        //private member to auto process counter/interval (in seconds)
        private int checkStatusCounter = 0;
        private int checkStatusInterval = 5;

        private int refreshAutoCompleteDataSource = 0;
        private int refreshAutoCompleteInterval = 5;

        private DateTime lastAutoSave;
        private int autoSaveCounter = 0;
        private int autoSaveInterval = 60;

        public MainForm(bool isLicensed)
        {
            InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
            this.Activated += new EventHandler(MainForm_Activated);
            timer1.Tick += new EventHandler(timer1_Tick);

            //this.SuspendLayout();
            InitializeApplication();
            InitializePrinter();
            InitializeScreen();
            InitializeData();
            if (isLicensed)
                GetLicenseInfo();
            timer1.Start();
            //this.ResumeLayout();
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            autoSaveCounter += 1;
            checkStatusCounter += 1;
            refreshAutoCompleteDataSource += 1;

            lblCurrentTime.Text = DateTime.Now.ToLongTimeString();

            //if (autoSaveCounter == autoSaveInterval)
            //{
            //    autoSaveCounter = 0;
            //    lastAutoSave = DateTime.Now;
            //    AutoSavePrintLog();
            //}

            if (!Settings.Default.UseNetworkPrinter)
            {
                if (checkStatusCounter == checkStatusInterval)
                {
                    checkStatusCounter = 0;
                    Parallel.Invoke(
                        () => CheckPrinterStatus()
                        );
                } 
            }

            //if (refreshAutoCompleteDataSource == refreshAutoCompleteInterval)
            //    printControl.RefreshAutoCompleteDataSource();
        }

        private void AutoSavePrintLog()
        {
            try
            {
                IEnumerable<Patient> lstPatient = (IEnumerable<Patient>)ApplicationParameter.ItemList;
                List<string> lstPatientData = new List<string>();
                foreach (Patient patientInfo in lstPatient)
                {
                    string patientData = ConvertPatientDataToString(patientInfo);
                    lstPatientData.Add(patientData);
                }

                SaveLogToTempFile(lstPatientData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Constant.APP_ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void MainForm_Activated(object sender, EventArgs e)
        {
        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //LogDataToFile();
            //if (Settings.Default.ClearLogFileWhenExit)
            //{
            //    DeleteLogFile();
            //}
        }

        private void DeleteLogFile()
        {
            DirectoryInfo dir = new DirectoryInfo(string.Format(@"{0}\data", Application.StartupPath));
            List<FileInfo> lstFile = dir.GetFiles("*.tmp").ToList();
            List<Patient> lstPatient = new List<Patient>();
            foreach (FileInfo file in lstFile)
            {
                File.Delete(file.FullName);
            }
        }

        private void LogDataToFile()
        {
            try
            {
                IEnumerable<Patient> lstPatient = (IEnumerable<Patient>)ApplicationParameter.ItemList;
                List<string> lstPatientData = new List<string>();
                foreach (Patient patientInfo in lstPatient)
                {
                    string patientData = ConvertPatientDataToString(patientInfo);
                    lstPatientData.Add(patientData);
                }

                SaveLogToFile(lstPatientData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Constant.APP_ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveLogToFile(List<string> lstPatientData)
        {
            string fileName = string.Format(@"{0}\data\{1}.dat", Application.StartupPath, DateTime.Now.Date.ToString("yyyyMMdd"));
            string dataMode = String.IsNullOrEmpty(Settings.Default.DataMode) ? "Local" : Settings.Default.DataMode;
            if (dataMode != "Local")
            {
                fileName = string.Format(@"{0}\{1}.dat", Settings.Default.RemoteDataPath, DateTime.Now.Date.ToString("yyyyMMdd"));
            }
            File.Delete(fileName);
            File.WriteAllLines(fileName, lstPatientData.AsEnumerable());
        }

        private void SaveLogToTempFile(List<string> lstPatientData)
        {
            string fileName = string.Format(@"{0}\data\{1}_{2}.tmp", Application.StartupPath, DateTime.Now.Date.ToString("yyyyMMdd"), DateTime.Now.ToString(Constant.TIME_FORMAT).Replace(':', '_'));
            File.WriteAllLines(fileName, lstPatientData.AsEnumerable());
        }

        private string ConvertPatientDataToString(Patient patientInfo)
        {
            // Read the data and convert it to the appropriate data type.
            string patientData = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16};{17};{18};{19};{20};{21};{22};{23};{24}",
                patientInfo.MRN,
                patientInfo.FirstName,
                patientInfo.LastName,
                patientInfo.Gender,
                patientInfo.DateOfBirth,
                patientInfo.IsAllergy ? "1" : "0",
                string.IsNullOrWhiteSpace(patientInfo.AllergenName) ? string.Empty : patientInfo.AllergenName,
                patientInfo.IsFallenRisk ? "1" : "0",
                patientInfo.IsDNR ? "1" : "0",
                patientInfo.RegistrationNo,
                patientInfo.RegistrationDate,
                patientInfo.RegistrationTime,
                patientInfo.Physician,
                patientInfo.WardName,
                patientInfo.RoomNo,
                patientInfo.BedNo,
                patientInfo.AgeInYear,
                patientInfo.AgeInMonth,
                patientInfo.AgeInDay,
                patientInfo.CustomAttribute1,
                patientInfo.CustomAttribute2,
                patientInfo.CustomAttribute3,
                patientInfo.CustomAttribute4,
                patientInfo.CustomAttribute5,
                patientInfo.WristBandType
                );
            return patientData;
        }

        private void GetLicenseInfo()
        {
            //string fileName = string.Format(@"{0}\{1}", Application.StartupPath, "ronin.snk");
            //IEnumerable<string> lstInfo = File.ReadAllLines(fileName);
            //DirectPrinting print = new DirectPrinting();
            //hospitalName = print.DecryptText(lstInfo.First());
            this.Text = string.Format("{0} ver {1} - {2} (Alpha Version)", Constant.APP_ApplicationName,Application.ProductVersion,  _companyName);
        }

        private void InitializeData()
        {
            SelectedDate = DateTime.Now.Date;
        }

        private void InitializePrinter()
        {
            /* Check whether using printer label or not */
            string fileName = string.Format(@"{0}\{1}", Application.StartupPath, "label.cfg");
            FileInfo file = new FileInfo(fileName);
            ApplicationParameter.IsUsingPrinterLabel = file.Exists;
            if (!Settings.Default.UseNetworkPrinter)
            {
                CheckPrinterStatus();
            }
            else
            {
                _isPrinterOnline = true;
                lblPrinterStatus.Text = string.Format("{0} - {1}", Settings.Default.LabelPrinterName, "(network-shared printer)");
            }
        }

        private void InitializeApplication()
        {
            //Check all initial application configuration
            // TODO : Get License Information
            SetConnectionStatus();
            _isLocalDBAvailable = CheckForLocalDB();
            autoSaveCounter = 0;
            autoSaveInterval = Settings.Default.AutoSaveLogFile * 60;
            checkStatusCounter = 0;
            checkStatusInterval = Settings.Default.CheckPrinterStatusInterval;
            refreshAutoCompleteDataSource = 0;
            lastAutoSave = DateTime.Now;
        }

        private void SetConnectionStatus()
        {
            _isConnectToInternet = Utility.CheckForInternetConnection();
            lblConnectionStatus.Text = _isConnectToInternet ? "Internet Access" : "No Internet Access";
            if (_isConnectToInternet)
                lblConnectionStatus.ForeColor = Color.Black;
            else
                lblConnectionStatus.ForeColor = Color.Red;
        }

        private void InitializeScreen()
        {
            lblCurrentDate.Text = DateTime.Now.Date.ToString(Constant.DATE_FORMAT_1);
            printControl.InitializeControls(this);
        }

        #region Helper Function and Methods
        private bool CheckForLocalDB()
        {
            string fileName = string.Format(@"{0}\data\item.dat", Application.StartupPath);
            FileInfo file = new FileInfo(fileName);
            return file.Exists;
        }
        private void CheckPrinterStatus()
        {
            ZebraPrinterLib.LoadZebraDevicesArray();
            string printerName = Settings.Default.LabelPrinterName;
            if (ZebraPrinterLib.CheckPrinterIsConnected(printerName))
                IsPrinterOnline = true;
            else
                IsPrinterOnline = false;

            lblPrinterStatus.Text = string.Format("{0} - {1}", printerName, IsPrinterOnline ? "Online" : "Offline");

            if (IsPrinterOnline)
                lblPrinterStatus.ForeColor = Color.Black;
            else
                lblPrinterStatus.ForeColor = Color.Red;
        }
        #endregion
    }
}
