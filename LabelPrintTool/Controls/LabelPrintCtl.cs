using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Threading.Tasks;
using CodeX.DesktopTool.Print.Properties;
using CodeX.Data.Model;
using CodeX.DesktopTool;
using CodeX.DesktopTool.model;
using System.Reflection;

namespace CodeX.DesktopTool.Print.Controls
{
    public partial class LabelPrintCtl : UserControl
    {
        private MainForm mainForm;
        private IEnumerable<vItemProduct> Items; //list of all items
        private enum AutoCompleteType
        {
            MRN,
            FirstName,
            LastName,
            PhysicianName,
            WardName,
            RoomNo,
            BedNo,
            ItemCode,
            ItemName
        }

        private bool _isPrinterOnline;
        private bool _isConnectedToDS;

        public bool IsPrinterOnline
        {
            get { return _isPrinterOnline; }
            set { _isPrinterOnline = value; SetPrintStatus(); }
        }

        public delegate List<vItemProduct> AsyncLoadItemFromRemoteDB();
        public delegate bool AsyncSetAutoCompleteDataSource();

        public LabelPrintCtl()
        {
            InitializeComponent();
            btnPrintLabel.EnabledChanged += new EventHandler(btnPrintLabel_EnabledChanged);
            optRemoteDB.CheckedChanged += new EventHandler(optConnectionMode_CheckedChanged);
            cboDatabase.SelectedIndexChanged += new EventHandler(cboDatabase_SelectedIndexChanged);
        }

        void cboDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = ((ComboBoxItem)cboDatabase.SelectedItem).Tag.ToString();
            ChangeConnectionString(connectionString);
            RefreshData();
        }

        private void ChangeConnectionString(string connStr)
        {
            var settings = ConfigurationManager.ConnectionStrings["cnsetting"];
            //use reflection to poke values in as a way to get access to the non-public fields (and methods).
            var fi = typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            fi.SetValue(settings, false);
            settings.ConnectionString = connStr;
        }

        #region Event Handlers
        private void txtItemCode_LostFocus(object sender, EventArgs e)
        {
            vItemProduct oItem = Items.Where(lst => lst.ItemCode.Equals(txtItemCode.Text)).FirstOrDefault();
            txtItemName.Text = oItem != null ? oItem.ItemName : string.Empty;
            txtShortName.Text = txtItemName.Text;
            lblPreviewLine3.Text = txtItemCode.Text;
            txtShortName.Focus();
        }
        private void txtItemName_LostFocus(object sender, EventArgs e)
        {
            vItemProduct oItem = Items.Where(lst => lst.ItemName.Equals(txtItemName.Text)).FirstOrDefault();
            txtItemCode.Text = oItem != null ? oItem.ItemCode : string.Empty;
            txtShortName.Text = txtItemName.Text;
            lblPreviewLine1.Text = txtItemName.Text;
            lblPreviewLine3.Text = txtItemCode.Text;
        }
        private void txtShortName_TextChanged(object sender, EventArgs e)
        {
            lblPreviewLine1.Text = txtShortName.Text;
        }
        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            ApplicationSetting settingDialog = new ApplicationSetting();
            settingDialog.ShowDialog();
        }
        private void btnPrintLabel_Click(object sender, EventArgs e)
        {
            PrintLabel(Settings.Default.LabelPrinterName);
        }
        private void btnPrintLabel_EnabledChanged(object sender, EventArgs e)
        {
            SetPrintStatus();
        }
        private void btnPrinterStatus_Click(object sender, EventArgs e)
        {
            CheckPrinterStatus printerStatus = new CheckPrinterStatus();
            printerStatus.ShowDialog();
        }

        private void optConnectionMode_CheckedChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void txtQuickFilter_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return:
                    ApplyFilter();
                    break;
                default:
                    break;
            }
        }
        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void tabItemInformation_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdItem.MultiSelect = tabItemInformation.SelectedIndex == 1;
        }

        private void btnRefreshLocalDB_Click(object sender, EventArgs e)
        {
            // Invoke LoadItemFromRemoteDB asynchronously. Pass an AsyncCallback
            // delegate instance referencing the CallbackHandler method that
            // will be called automatically when the asynchronous method
            // completes. Pass a reference to the AsyncExampleDelegate delegate
            // instance as asynchronous state; otherwise, the callback method
            // has no access to the delegate instance in order to call
            // EndInvoke.
            AsyncLoadItemFromRemoteDB loadItemMethod = LoadItemFromRemoteDB;
            IAsyncResult asyncResult = loadItemMethod.BeginInvoke(LoadItemFromRemoteDBCallback, loadItemMethod);
        }

        // A method to handle asynchronous completion using callbacks.
        public void LoadItemFromRemoteDBCallback(IAsyncResult result)
        {
            // Extract the reference to the AsyncExampleDelegate instance
            // from the IAsyncResult instance. This allows you to obtain the
            // completion data.
            AsyncLoadItemFromRemoteDB loadItemMethod = (AsyncLoadItemFromRemoteDB)result.AsyncState;
            // Obtain the completion data for the asynchronous method.
            DateTime completion = DateTime.MinValue;
            try
            {
                ApplicationParameter.ItemList = loadItemMethod.EndInvoke(result);
                Items = ApplicationParameter.ItemList.AsEnumerable();
                CacheToLocalDB();
                RefreshBindingSource();
                MessageBox.Show("Local Database is updated!");
            }
            catch
            {
                // Catch and handle those exceptions you would if calling
                // LoadItemFromRemoteDB directly.
            }
        }
        private void CacheToLocalDB()
        {
            string dbName = ((ComboBoxItem)cboDatabase.SelectedItem).Tag.ToString();
            string fileName = string.Format(@"{0}\data\{1}.dat", Application.StartupPath, dbName);
            File.Delete(fileName);
            List<string> list = ConvertToList(this.Items);
            File.WriteAllLines(fileName, list);
        }
        #endregion

        #region Initializing Control
        public void InitializeControls(MainForm mainForm)
        {
            this.mainForm = mainForm;

            txtItemCode.LostFocus += new EventHandler(txtItemCode_LostFocus);
            txtItemName.LostFocus += new EventHandler(txtItemName_LostFocus);
            txtShortName.TextChanged += new EventHandler(txtShortName_TextChanged);

            InitializeConnectionMode();
            InitializeDataSource();
            InitializeLabelPreview();
            InitializePrinter();
        }
        private void InitializeConnectionMode()
        {
            LoadDatabaseList();
            if (cboDatabase.Items.Count > 0)
            {
                cboDatabase.SelectedIndex = 0;
                cboDatabase.Text = ((ComboBoxItem)cboDatabase.SelectedItem).Text.ToString();
            }

            //optRemoteDB.Enabled = this.mainForm.IsConnectToInternet;
            btnRefreshLocalDB.Enabled = this.mainForm.IsConnectToInternet;

            optLocalDB.Enabled = this.mainForm.IsLocalDBAvailable;

            _isConnectedToDS = (this.mainForm.IsConnectToInternet || this.mainForm.IsLocalDBAvailable);
        }

        private void InitializeDataSource()
        {
            if (_isConnectedToDS)
            {
                InitializeGrid();
            }
        }
        private void InitializeGrid()
        {
            grdItem.AutoGenerateColumns = false;
            grdItem.DataSource = bindingSource1;
        }
        private void InitializeLabelPreview()
        {
            LoadLabelType();
            if (Settings.Default.BarcodeType != "QRCode")
                pictureBox1.Image = Resources.barcode128;
            else
                pictureBox1.Image = Resources.qrcode;
        }
        private void InitializePrinter()
        {
            SetPrintStatus();
        }
        #endregion

        #region Helper Function and Methods
        private string ConvertItemDataToString(vItemProduct itemInfo)
        {
            // Read the data and convert it to the appropriate data type.
            string item = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}",
                itemInfo.GCItemType,
                itemInfo.ItemID,
                itemInfo.ItemCode,
                itemInfo.ItemName,
                itemInfo.ItemGroupID,
                itemInfo.ItemGroupCode,
                itemInfo.ItemGroupName,
                itemInfo.ItemUnit,
                itemInfo.ItemStatus
                );
            return item;
        }
        private vItemProduct ConvertIntoItemObject(string[] record)
        {
            vItemProduct oItem = new vItemProduct();
            oItem.ItemType = record[0];
            oItem.ItemID = Convert.ToInt16(record[1]);
            oItem.ItemCode = record[2];
            oItem.ItemName = record[3];
            oItem.ItemGroupID = Convert.ToInt16(record[4]);
            oItem.ItemGroupCode = record[5];
            oItem.ItemGroupName = record[6];
            oItem.ItemUnit = record[7];
            oItem.ItemStatus = record[8];
            return oItem;
        }
        private void SetPrintStatus()
        {
            if (!Settings.Default.UseNetworkPrinter)
            {
                btnPrintLabel.Enabled = ZebraPrinterLib.isZebraPrinter && this.IsPrinterOnline;
                if (btnPrintLabel.Enabled)
                {
                    btnPrintLabel.BackColor = Color.LawnGreen;
                }
                else
                {
                    btnPrintLabel.BackColor = Color.Red;
                }
            }
            else
            {
                btnPrintLabel.Enabled = true;
                btnPrintLabel.BackColor = Color.LawnGreen;
            }

        }
        #endregion

        private void LoadItemList()
        {
            if (_isConnectedToDS)
            {
                if (this.mainForm.IsLocalDBAvailable)
                {
                    optLocalDB.Enabled = true;
                    optLocalDB.Checked = true;
                    LoadItemFromLocalDB();
                }
                else
                {
                    optLocalDB.Enabled = false;
                    optLocalDB.Checked = false;
                    LoadItemFromRemoteDB();
                }
            }
            else
            {
                MessageBox.Show("No connection to data source !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void LoadDatabaseList()
        {
            string fileName = string.Format(@"{0}\data\db.lst", Application.StartupPath);
            FileInfo file = new FileInfo(fileName);
            if (file.Exists)
            {
                IEnumerable<string> recordList = File.ReadAllLines(file.FullName);
                cboDatabase.Items.Clear();
                cboDatabase.DisplayMember = "Text";
                cboDatabase.ValueMember = "Value";
                foreach (string itemInfo in recordList)
                {
                    string[] record = itemInfo.Split('|');
                    ComboBoxItem item = new ComboBoxItem() { Value = record[0], Text = record[1], Tag = record[2] };
                    cboDatabase.Items.Add(item);
                }
            }
        }

        private void LoadItemFromLocalDB()
        {
            string dbName = ((ComboBoxItem)cboDatabase.SelectedItem).Value.ToString();
            string fileName = string.Format(@"{0}\data\{1}.dat", Application.StartupPath, dbName);
            FileInfo file = new FileInfo(fileName);
            if (file.Exists)
            {
                IEnumerable<string> recordList = File.ReadAllLines(file.FullName);
                List<vItemProduct> lstItem = new List<vItemProduct>();
                foreach (string itemInfo in recordList)
                {
                    // Read the data and convert it to the appropriate data type.
                    string[] record = itemInfo.Split(';');
                    vItemProduct oItem = new vItemProduct();
                    oItem = ConvertIntoItemObject(record);
                    lstItem.Add(oItem);
                }
                ApplicationParameter.ItemList = lstItem;
                Items = lstItem.AsEnumerable();
                RefreshBindingSource();
            }
        }
        private List<vItemProduct> LoadItemFromRemoteDB()
        {
            string filterExpression = string.Format("1=1 AND IsDeleted=0 ORDER BY ItemCode");
            List<vItemProduct> listProduct = BusinessLayer.GetvItemProductList(filterExpression);
            return listProduct;
        }
        private void RefreshBindingSource()
        {
            bindingSource1.DataSource = ApplicationParameter.ItemList;
            bindingSource1.ResetBindings(false);
            RefreshAutoCompleteDataSource();
        }
        private bool PrintLabel(string printerName)
        {
            if (String.IsNullOrEmpty(lblPreviewLine3.Text))
            {
                MessageBox.Show("Please select valid item to print!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            try
            {
                string itemCode = string.Empty;
                string itemName = string.Empty;
                string command;
                if (tabItemInformation.SelectedIndex == 0)
                {
                    //Single-item print mode
                    itemCode = txtItemCode.Text;
                    itemName = txtShortName.Text;
                    command = GenerateZPLCommand(cboLabelType.Text.Trim(), itemCode, itemName);
                    SendCommandToPrinter(printerName, command);
                }
                else
                {
                    //Multi-item print mode
                    if (grdItem.SelectedRows.Count != 0)
                    {
                        foreach (DataGridViewRow row in grdItem.SelectedRows)
                        {
                            itemCode = row.Cells["colItemCode"].Value.ToString();
                            itemName = row.Cells["colItemName"].Value.ToString();
                            command = GenerateZPLCommand(cboLabelType.Text.Trim(), itemCode, itemName);
                            SendCommandToPrinter(printerName, command);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Communication problem with device: \n{1}", ex.Message), Constant.APP_ApplicationName);
                return false;
            }
        }

        private void SendCommandToPrinter(string printerName, string command)
        {
            DirectPrinting print = new DirectPrinting();
            //Initialize Printer
            print.OpenPrinter(printerName);
            print.StartDocPrinter();
            print.Send("\n");
            print.Send("n\n"); // clear the image buffer
            print.Send(command.ToString());
            print.Send("p1\n"); //print one label
            print.EndDocPrinter();
        }
        private void RefreshAutoCompleteDataSource()
        {
            //Invoke the methods concurrently
            Parallel.Invoke(
                () => SetAutoCompleteDataSource(txtItemCode, AutoCompleteType.ItemCode),
                () => SetAutoCompleteDataSource(txtItemName, AutoCompleteType.ItemName)
                );
        }
        private void SetAutoCompleteDataSource(TextBox control, AutoCompleteType type)
        {
            string[] autoCompleteDS = new string[] { "" };
            switch (type)
            {
                case AutoCompleteType.ItemCode:
                    autoCompleteDS = (from p in Items
                                      select p.ItemCode).Distinct().ToArray();
                    break;
                case AutoCompleteType.ItemName:
                    autoCompleteDS = (from p in Items
                                      select p.ItemName).Distinct().ToArray();
                    break;
                default:
                    break;
            }
            control.AutoCompleteCustomSource.AddRange(autoCompleteDS);
            control.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            control.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        #region Obsolete Code
        public void RefreshData()
        {
            if (optRemoteDB.Checked)
                LoadItemFromRemoteDB();
            else
                LoadItemFromLocalDB();
        }
        private void btnPrintDM_Click(object sender, EventArgs e)
        {
            DirectPrinting print = new DirectPrinting();
            //Initialize Printer
            print.OpenPrinter(@"\\HENDRI-PC\EPSON LX-300+ II");

            //string command = GenerateZPLCommand(entityPatient, entityVisit, registrationNo);
            string command = "Test Print";

            print.StartDocPrinter();
            print.Send("\n");
            print.Send("n\n"); // clear the image buffer
            print.Send(command.ToString());
            print.Send("p1\n"); //print one label
            print.EndDocPrinter();
        }
        #region Generate ZPL Methods

        //private string GenerateZPLForAdultAdhesive(Patient oPatient)
        //{
        //    StringBuilder command = new StringBuilder();
        //    string qrCodeContent = string.Format("{0},{1},{2},{3},{4},{5}", oPatient.MRN, oPatient.FirstName, oPatient.LastName, oPatient.Gender, oPatient.RegistrationNo, oPatient.AllergenName);
        //    string barcodeValue = txtItemCode.Text;

        //    command.Append(string.Format(@"^XA"));
        //    command.Append(string.Format(@"^POI"));
        //    command.Append(string.Format(@"^FWR"));     // Set the default orientation for all command fields (FD)
        //    command.Append(string.Format(@"^LH0,236")); // Set the Label Home
        //    if (Settings.Default.BarcodeType == Enumeration.BarcodeType.QRCode.ToString())
        //        command.Append(string.Format(@"^FO60,160 ^BQN,2,6,M^FDMA{0}^FS", qrCodeContent));
        //    else
        //        command.Append(string.Format(@"^FO80,160 ^BY1,2.0,180^BCN,180,Y,N,N^FD{0}^FS", barcodeValue));

        //    command.Append(string.Format(@"^FO250,400 ^A0,38,38^FD{0}^FS", lblPreviewLine1.Text));
        //    command.Append(string.Format(@"^FO190,400 ^A0,33,33^FD{0}^FS", lblPreviewLine2.Text));
        //    command.Append(string.Format(@"^FO150,400 ^A0,33,33^FD{0}^FS", lblPreviewLine3.Text));
        //    command.Append(string.Format(@"^FO110,400 ^A0,33,33^FD{0}^FS", lblPreviewLine4.Text));
        //    if (oPatient.IsAllergy)
        //        command.Append(string.Format(@"^FO110,850 ^A0,33,33^FD{0}^FS", lblPatientStatus.Text));
        //    if (lblCustomAttribute.Visible)
        //        command.Append(string.Format(@"^FO60,400 ^A0,31,31^FD{0}^FS", lblCustomAttribute.Text));

        //    //command.Append(string.Format(@"^FO60,380 ^A0,31,31^FD{0}^FS", lblCustomAttribute.Text));

        //    command.Append(string.Format(@"^FO30,400 ^A0,26,26^FD{0}^FS", mainForm.HospitalName));
        //    command.AppendLine(string.Format("^XZ"));

        //    return command.ToString();
        //}

        //private string GenerateZPLForAdultClip(Patient oPatient)
        //{
        //    StringBuilder command = new StringBuilder();
        //    string qrCodeContent = string.Format("{0},{1},{2},{3},{4},{5}", oPatient.MRN, oPatient.FirstName, oPatient.LastName, oPatient.Gender, oPatient.RegistrationNo, oPatient.AllergenName);
        //    string barcodeValue = txtItemCode.Text;

        //    command.Append(string.Format(@"^XA"));
        //    command.Append(string.Format(@"^POI"));
        //    command.Append(string.Format(@"^FWR"));     // Set the default orientation for all command fields (FD)
        //    command.Append(string.Format(@"^LH0,236")); // Set the Label Home
        //    if (Settings.Default.BarcodeType == "QRCode")
        //        command.Append(string.Format(@"^FO95,80 ^BQN,2,8,M^FDMA{0}^FS", qrCodeContent));
        //    else
        //        command.Append(string.Format(@"^FO45,80 ^BY2,2.9,200^BCN,200,Y,N,N^FD{0}^FS", barcodeValue));
        //    command.Append(string.Format(@"^FO300,370 ^A0,38,38^FD{0}^FS", lblPreviewLine1.Text));
        //    command.Append(string.Format(@"^FO240,370 ^A0,33,33^FD{0}^FS", lblPreviewLine2.Text));
        //    command.Append(string.Format(@"^FO200,370 ^A0,33,33^FD{0}^FS", lblPreviewLine3.Text));
        //    command.Append(string.Format(@"^FO160,370 ^A0,33,33^FD{0}^FS", lblPreviewLine4.Text));
        //    if (oPatient.IsAllergy)
        //    {
        //        command.Append(string.Format(@"^FO160,830 ^A0,33,33^FD{0}^FS", lblPatientStatus.Text));
        //    }

        //    if (lblCustomAttribute.Visible)
        //    {
        //        command.Append(string.Format(@"^FO110,370 ^A0,33,33^FD{0}^FS", lblCustomAttribute.Text));
        //    }
        //    command.Append(string.Format(@"^FO30,370 ^A0,26,26^FD{0}^FS", mainForm.HospitalName));
        //    command.AppendLine(string.Format("^XZ"));

        //    return command.ToString();
        //}

        //private string GenerateZPLForInfantClip(Patient oPatient)
        //{
        //    StringBuilder command = new StringBuilder();
        //    string qrCodeContent = string.Format("{0},{1},{2},{3},{4},{5}", oPatient.MRN, oPatient.FirstName, oPatient.LastName, oPatient.Gender, oPatient.RegistrationNo, oPatient.AllergenName);
        //    string barcodeValue = txtItemCode.Text;

        //    command.Append(string.Format(@"^XA"));
        //    command.Append(string.Format(@"^POI"));
        //    command.Append(string.Format(@"^FWR"));     // Set the default orientation for all command fields (FD)
        //    command.Append(string.Format(@"^LH0,260")); // Set the Label Home
        //    if (Settings.Default.BarcodeType == Enumeration.BarcodeType.QRCode.ToString())
        //        command.Append(string.Format(@"^FO50,80 ^BQN,2,7,M^FDMA{0}^FS", qrCodeContent));
        //    else
        //        command.Append(string.Format(@"^FO80,110 ^BY1,2.0,180^BCN,180,Y,N,N^FD{0}^FS", barcodeValue));
        //    command.Append(string.Format(@"^FO250,340 ^A0,38,38^FD{0}^FS", lblPreviewLine1.Text));
        //    command.Append(string.Format(@"^FO190,340 ^A0,33,33^FD{0}^FS", lblPreviewLine2.Text));
        //    command.Append(string.Format(@"^FO150,340 ^A0,33,33^FD{0}^FS", lblPreviewLine3.Text));
        //    command.Append(string.Format(@"^FO110,340 ^A0,33,33^FD{0}^FS", lblPreviewLine4.Text));
        //    if (oPatient.IsAllergy)
        //    {
        //        command.Append(string.Format(@"^FO110,800 ^A0,33,33^FD{0}^FS", lblPatientStatus.Text));
        //    }
        //    if (lblCustomAttribute.Visible)
        //    {
        //        command.Append(string.Format(@"^FO60,340 ^A0,31,31^FD{0}^FS", lblCustomAttribute.Text));
        //    }

        //    command.Append(string.Format(@"^FO30,340 ^A0,26,26^FD{0}^FS", mainForm.HospitalName));
        //    command.AppendLine(string.Format("^XZ"));

        //    return command.ToString();
        //}
        #endregion
        #region Calculate Patient Age
        private void CalculatePatientAge()
        {
            int ageInDay = 0;
            int ageInMonth = 0;
            int ageInYear = 0;

            DateTime currentDate = DateTime.Now;
            DateTime patientDOB = dteDateOfBirth.Value;
            ageInDay = GetPatientAgeInDay(patientDOB, currentDate);
            ageInMonth = GetPatientAgeInMonth(patientDOB, currentDate);
            ageInYear = GetPatientAgeInYear(patientDOB, currentDate);
            txtAgeInDay.Text = String.Format("{0}", Convert.ToString(ageInDay));
            txtAgeInMonth.Text = String.Format("{0}", Convert.ToString(ageInMonth));
            txtAgeInYear.Text = String.Format("{0}", Convert.ToString(ageInYear));
        }
        public int GetPatientAgeInDay(DateTime dateOfBirth, DateTime nowDate)
        {
            int day = GetPatientAge(dateOfBirth, nowDate, 1);
            return day;
        }
        public int GetPatientAgeInMonth(DateTime dateOfBirth, DateTime nowDate)
        {
            int month = GetPatientAge(dateOfBirth, nowDate, 2);
            return month;
        }
        public int GetPatientAgeInYear(DateTime dateOfBirth, DateTime nowDate)
        {
            int year = GetPatientAge(dateOfBirth, nowDate, 3);
            return year;
        }
        public int GetPatientAge(DateTime dateOfBirth, DateTime nowDate, int type)
        {
            int day = nowDate.Day - dateOfBirth.Day;
            int month = nowDate.Month - dateOfBirth.Month;
            int year = nowDate.Year - dateOfBirth.Year;
            int typo = 0;

            while (day < 0)
            {
                int selisihDay = DateTime.FromOADate(0).Day;
                day = day + selisihDay;
                month = month - 1;
            }

            if (month < 0)
            {
                month = month + 12;
                year = year - 1;
            }
            switch (type)
            {
                case 1:
                    typo = day;
                    break;
                case 2:
                    typo = month;
                    break;
                case 3:
                    typo = year;
                    break;
            }
            return typo;
        }
        #endregion
        #endregion

        private void lblLabelPreviewTitle_Click(object sender, EventArgs e)
        {
            string zplCommand = GenerateZPLCommand(cboLabelType.Text.Trim(), lblPreviewLine3.Text, lblPreviewLine1.Text);
            ZPLCommandPreview previewWin = new ZPLCommandPreview(zplCommand);
            previewWin.ShowDialog();
        }

        #region Label Methods and Functions
        private void LoadLabelType()
        {
            string fileName = string.Format(@"{0}\zpl\label.typ", Application.StartupPath);
            IEnumerable<string> lstType = File.ReadAllLines(fileName);
            cboLabelType.Items.Clear();
            int defaultIndex = 0;
            int itemIndex = 0;
            foreach (string label in lstType)
            {
                string[] type = label.Split('|');
                if (!string.IsNullOrEmpty(type[0].Trim()))
                    cboLabelType.Items.Add(type[0]);
                if (type[1] == "1")
                    defaultIndex = itemIndex;
                itemIndex += 1;
            }
            if (cboLabelType.Items.Count > 0)
                cboLabelType.SelectedIndex = defaultIndex;
            cboLabelType.Enabled = cboLabelType.Items.Count > 1;
        }
        private string GenerateZPLCommand(string labelType, string itemCode, string itemName)
        {
            string fileName = string.Format(@"{0}\zpl\{1}.zpl", Application.StartupPath, labelType);
            IEnumerable<string> lstCommand = File.ReadAllLines(fileName);
            StringBuilder commandText = new StringBuilder();
            foreach (string command in lstCommand)
            {
                commandText.AppendLine(command);
            }
            string result = commandText.ToString();
            result = result.Replace("{ItemName}", itemName);
            result = result.Replace("{ItemCode}", itemCode);

            return result;
        }
        #endregion

        private List<string> ConvertToList(IEnumerable<vItemProduct> itemList)
        {
            List<string> lst = new List<string>();
            foreach (vItemProduct item in itemList)
            {
                lst.Add(ConvertItemDataToString(item));
            }
            return lst;
        }

        private void ApplyFilter()
        {
            string expression = string.Format("{0}", txtQuickFilter.Text.ToLower());
            IEnumerable<vItemProduct> itemMaster = ApplicationParameter.ItemList.Where(lst => lst.ItemCode.ToLower().Contains(expression) || lst.ItemName.ToLower().Contains(expression));
            bindingSource1.DataSource = itemMaster;
            bindingSource1.ResetBindings(false);
        }

    }
}
