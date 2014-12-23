using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using CodeX.DesktopTool.PrintManager.Properties;

namespace CodeX.DesktopTool.PrintManager.Controls
{
    public partial class WristbandPrintCtl : UserControl
    {
        private MainForm mainForm;
        private IEnumerable<Patient> Patients; //list of all patients
        private bool isAddNew = true;
        private enum AutoCompleteType
        {
            MRN,
            FirstName,
            LastName,
            PhysicianName,
            WardName,
            RoomNo,
            BedNo
        }

        private bool isPrinterOnline;
        public bool IsPrinterOnline
        {
            get { return isPrinterOnline; }
            set { isPrinterOnline = value; SetPrintStatus(); }
        }

        public WristbandPrintCtl()
        {
            InitializeComponent();

            dteRegistrationDate.CustomFormat = Constant.DATE_FORMAT_1;
            txtMRN.TextChanged += new EventHandler(OnPatientIdentificationNumberChanged);
            txtMRN.LostFocus += new EventHandler(txtMRN_LostFocus);

            txtFirstName.TextChanged += new EventHandler(OnPatientInformationTextChanged);
            txtLastName.TextChanged += new EventHandler(OnPatientInformationTextChanged);
            optMale.CheckedChanged += new EventHandler(OnPatientInformationTextChanged);
            optFemale.CheckedChanged += new EventHandler(OnPatientInformationTextChanged);
            dteDateOfBirth.LostFocus += new EventHandler(dteDateOfBirth_LostFocus);

            chkIsAllergy.CheckedChanged += new EventHandler(chkIsAllergy_CheckedChanged);
            txtAllergyInfo.TextChanged += new EventHandler(txtAllergyInfo_TextChanged);

            txtCustomAttribute1.TextChanged += new EventHandler(OnCustomAttributeChanged);
            txtCustomAttribute2.TextChanged += new EventHandler(OnCustomAttributeChanged);
            txtCustomAttribute3.TextChanged += new EventHandler(OnCustomAttributeChanged);
            txtCustomAttribute4.TextChanged += new EventHandler(OnCustomAttributeChanged);
            txtCustomAttribute5.TextChanged += new EventHandler(OnCustomAttributeChanged);

            txtRegistrationNo.TextChanged += new EventHandler(OnPatientIdentificationNumberChanged);
            txtPhysicianName.TextChanged += new EventHandler(OnPhysicianAndLocationTextChanged);
            txtWardName.TextChanged += new EventHandler(OnPhysicianAndLocationTextChanged);
            txtRoomNo.TextChanged += new EventHandler(OnPhysicianAndLocationTextChanged);
            txtBedNo.TextChanged += new EventHandler(OnPhysicianAndLocationTextChanged);

            btnPrintLabel.EnabledChanged += new EventHandler(btnPrintLabel_EnabledChanged);
        }

        #region Event Handlers
        private void OnPatientInformationTextChanged(object sender, EventArgs e)
        {
            string firstName = string.IsNullOrEmpty(txtFirstName.Text) ? "First Name" : txtFirstName.Text;
            string lastName = string.IsNullOrEmpty(txtLastName.Text) ? "Last Name" : txtLastName.Text.ToUpper();
            string gender = optMale.Checked ? "Male" : "Female";
            string age = Convert.ToInt16(txtAgeInYear.Text) > 5 ? string.Format("{0} thn", txtAgeInYear.Text) : string.Format("{0} thn {1} bln {2} hari", txtAgeInYear.Text, txtAgeInMonth.Text, txtAgeInDay.Text);
            lblPreviewLine1.Text = string.Format("{0},{1} ({2},{3})", lastName, firstName, gender, age);

            string dateOfBirth = string.IsNullOrWhiteSpace(dteDateOfBirth.Value.ToString(Constant.DATE_FORMAT_1)) ? "dd-MMM-yyyy" : dteDateOfBirth.Value.ToString(Constant.DATE_FORMAT_1);
            lblPreviewLine4.Text = string.Format("Date of Birth : {0}", dateOfBirth);
        }

        private void OnCustomAttributeChanged(object sender, EventArgs e)
        {
            string customAttribute1, customAttribute2, customAttribute3, customAttribute4, customAttribute5 = string.Empty;

            customAttribute1 = !string.IsNullOrWhiteSpace(txtCustomAttribute1.Text) ? string.Format("{0}: {1};", lblCustomAttribute1.Text, txtCustomAttribute1.Text) : string.Empty;
            customAttribute2 = !string.IsNullOrWhiteSpace(txtCustomAttribute2.Text) ? string.Format("{0}: {1};", lblCustomAttribute2.Text, txtCustomAttribute2.Text) : string.Empty;
            customAttribute3 = !string.IsNullOrWhiteSpace(txtCustomAttribute3.Text) ? string.Format("{0}: {1};", lblCustomAttribute3.Text, txtCustomAttribute3.Text) : string.Empty;
            customAttribute4 = !string.IsNullOrWhiteSpace(txtCustomAttribute4.Text) ? string.Format("{0}: {1};", lblCustomAttribute4.Text, txtCustomAttribute4.Text) : string.Empty;
            customAttribute5 = !string.IsNullOrWhiteSpace(txtCustomAttribute5.Text) ? string.Format("{0}: {1};", lblCustomAttribute4.Text, txtCustomAttribute5.Text) : string.Empty;

            if (!string.IsNullOrWhiteSpace(customAttribute1) ||
                !string.IsNullOrWhiteSpace(customAttribute2) ||
                !string.IsNullOrWhiteSpace(customAttribute3) ||
                !string.IsNullOrWhiteSpace(customAttribute4) ||
                !string.IsNullOrWhiteSpace(customAttribute5))
            {
                lblCustomAttribute.Visible = true;
                lblCustomAttribute.Text = string.Format("( {0}{1}{2}{3}{4} )", customAttribute1, customAttribute2, customAttribute3, customAttribute4, customAttribute5);
            }
            else
            {
                lblCustomAttribute.Visible = false;
            }
        }

        private void OnPhysicianAndLocationTextChanged(object sender, EventArgs e)
        {
            string physicianName = string.IsNullOrWhiteSpace(txtPhysicianName.Text) ? "Physician Name" : txtPhysicianName.Text;
            string wardName = string.IsNullOrWhiteSpace(txtWardName.Text) ? "Ward Name" : txtWardName.Text;
            string roomNo = string.IsNullOrWhiteSpace(txtRoomNo.Text) ? "Room Number" : txtRoomNo.Text;
            string bedNo = string.IsNullOrWhiteSpace(txtBedNo.Text) ? "Bed Number" : txtBedNo.Text;
            string patientLocation = string.Format("{0}  #{1}-{2}", wardName, roomNo, bedNo);
            lblPreviewLine2.Text = string.Format("{0}   {1}", physicianName, patientLocation);
        }

        private void OnPatientIdentificationNumberChanged(object sender, EventArgs e)
        {
            string mrn = string.IsNullOrWhiteSpace(txtMRN.Text) ? "MRN" : txtMRN.Text;
            string registrationNo = string.IsNullOrWhiteSpace(txtRegistrationNo.Text) ? "Registration Number" : txtRegistrationNo.Text;
            lblPreviewLine3.Text = string.Format("{0}     {1}", mrn, registrationNo);
        }

        private void dteDateOfBirth_LostFocus(object sender, EventArgs e)
        {
            CalculatePatientAge();
            OnPatientInformationTextChanged(sender, e);
        }

        private void txtAllergyInfo_TextChanged(object sender, EventArgs e)
        {
            lblPatientStatus.Text = string.Format("ALLERGY : {0}", txtAllergyInfo.Text);
        }

        private void chkIsAllergy_CheckedChanged(object sender, EventArgs e)
        {
            lblAllergyInfo.Visible = chkIsAllergy.Checked;
            txtAllergyInfo.Visible = chkIsAllergy.Checked;
            lblPatientStatus.Visible = chkIsAllergy.Checked;
            if (chkIsAllergy.Checked)
                txtAllergyInfo.Focus();
        }

        private void txtMRN_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMRN.Text))
            {
                Patient oPatient = Patients.Where(lst => lst.MRN == txtMRN.Text).FirstOrDefault();
                if (oPatient != null)
                {
                    txtFirstName.Text = oPatient.FirstName;
                    txtLastName.Text = oPatient.LastName;
                    optMale.Checked = oPatient.Gender == "M";
                    optFemale.Checked = oPatient.Gender == "F";
                    dteDateOfBirth.Value = oPatient.DOB;
                    chkIsAllergy.Checked = oPatient.IsAllergy;
                    txtAllergyInfo.Text = oPatient.AllergenName;
                    txtCustomAttribute1.Text = oPatient.CustomAttribute1;
                    txtCustomAttribute2.Text = oPatient.CustomAttribute2;
                    txtCustomAttribute3.Text = oPatient.CustomAttribute3;
                    txtCustomAttribute4.Text = oPatient.CustomAttribute4;
                    txtCustomAttribute5.Text = oPatient.CustomAttribute5;
                    CalculatePatientAge();

                    txtRegistrationNo.Text = oPatient.RegistrationNo;
                    dteRegistrationDate.Value = oPatient.PatientRegistrationDate;
                    txtRegistrationTime.Text = oPatient.RegistrationTime;
                    txtPhysicianName.Text = oPatient.Physician;
                    txtWardName.Text = oPatient.WardName;
                    txtRoomNo.Text = oPatient.RoomNo;
                    txtBedNo.Text = oPatient.BedNo;
                }
                else
                {
                    txtFirstName.Text = string.Empty;
                    txtLastName.Text = string.Empty;
                    optMale.Checked = true;
                    dteDateOfBirth.Value = DateTime.Now.Date;
                    txtAgeInYear.Text = "0";
                    txtAgeInMonth.Text = "0";
                    txtAgeInDay.Text = "0";
                    chkIsAllergy.Checked = false;
                    txtAllergyInfo.Text = string.Empty;
                    txtCustomAttribute1.Text = string.Empty;
                    txtCustomAttribute2.Text = string.Empty;
                    txtCustomAttribute3.Text = string.Empty;
                    txtCustomAttribute4.Text = string.Empty;
                    txtCustomAttribute5.Text = string.Empty;

                    txtRegistrationNo.Text = Settings.Default.RegistrationNoPrefix;
                    dteRegistrationDate.Value = DateTime.Now.Date;
                    txtRegistrationTime.Text = DateTime.Now.ToString(Constant.TIME_FORMAT);
                    txtPhysicianName.Text = string.Empty;
                    txtWardName.Text = string.Empty;
                    txtRoomNo.Text = string.Empty;
                    txtBedNo.Text = string.Empty;
                }

                OnPatientInformationTextChanged(sender, e);
            }
        }

        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            ApplicationSetting settingDialog = new ApplicationSetting();
            settingDialog.ShowDialog();
        }

        private void btnPrintLabel_Click(object sender, EventArgs e)
        {
            PrintPatientLabel();
            SetAutoCompleteDataSource(txtMRN, AutoCompleteType.MRN);
            SetAutoCompleteDataSource(txtFirstName, AutoCompleteType.FirstName);
            SetAutoCompleteDataSource(txtLastName, AutoCompleteType.LastName);
            SetAutoCompleteDataSource(txtPhysicianName, AutoCompleteType.PhysicianName);
            SetAutoCompleteDataSource(txtWardName, AutoCompleteType.WardName);
            SetAutoCompleteDataSource(txtRoomNo, AutoCompleteType.RoomNo);
            SetAutoCompleteDataSource(txtBedNo, AutoCompleteType.BedNo);
            
            ResetPatientEntry();
        }

        private void btnPrintLabel_EnabledChanged(object sender, EventArgs e)
        {
            //Printer Status
            SetPrintStatus();
        }

        private void btnPrinterStatus_Click(object sender, EventArgs e)
        {
            CheckPrinterStatus printerStatus = new CheckPrinterStatus();
            printerStatus.ShowDialog();
        }

        private void btnResetEntry_Click(object sender, EventArgs e)
        {
            ResetPatientEntry();
        }

        #endregion

        public void InitializeControls(MainForm mainForm)
        {
            this.mainForm = mainForm;

            //Start Display Option
            chkIsAllergy.Visible = Settings.Default.DisplayAllergyOption;
            panAllergyIndicator.Visible = chkIsAllergy.Visible;
            chkIsFallRisk.Visible = Settings.Default.DisplayFallRiskOption;
            panFallRiskIndicator.Visible = chkIsFallRisk.Visible;
            chkIsDNR.Visible = Settings.Default.DisplayDNROption;
            panDNRIndicator.Visible = chkIsDNR.Visible;
            lblHospitalName.Text = mainForm.CompanyName;

            if (Settings.Default.BarcodeType != "QRCode")
                pictureBox1.Image = Resources.barcode128;
            else
                pictureBox1.Image = Resources.qrcode;

            dteDateOfBirth.MaxDate = DateTime.Now.Date;
            dteRegistrationDate.MaxDate = DateTime.Now.Date;

            //End Display Option

            //Initialize the GridView
            //LoadPrintingLog(DateTime.Now);
            InitializeGrid();

            //Auto-complete Textbox
            //LoadPatientList();
            //RefreshAutoCompleteDataSource();
            SetPrintStatus();
            //ResetPatientEntry();
        }

        private void InitializeGrid()
        {
            grdPatient.AutoGenerateColumns = false;
            grdPatient.DataSource = bindingSource1;
        }

        private Patient ConvertIntoPatientObject(string[] record)
        {
            Patient oPatient = new Patient();

            oPatient.MRN = record[0];
            oPatient.FirstName = record[1];
            oPatient.LastName = record[2];
            oPatient.Gender = record[3];
            oPatient.DateOfBirth = record[4];
            oPatient.IsAllergy = record[5] == "1" ? true : false;
            oPatient.AllergenName = string.IsNullOrWhiteSpace(record[6]) ? string.Empty : record[6];
            oPatient.IsFallenRisk = record[7] == "1" ? true : false;
            oPatient.IsDNR = record[8] == "1" ? true : false;
            oPatient.RegistrationNo = record[9];
            oPatient.RegistrationDate = record[10];
            oPatient.RegistrationTime = record[11];
            oPatient.Physician = record[12];
            oPatient.WardName = record[13];
            oPatient.RoomNo = record[14];
            oPatient.BedNo = record[15];
            if (record.Length == 16)
            {
                //to support old version of Log Data files which consist only 15 information
                oPatient.AgeInYear = 0;
                oPatient.AgeInMonth = 0;
                oPatient.AgeInDay = 0;
                oPatient.CustomAttribute1 = string.Empty;
                oPatient.CustomAttribute2 = string.Empty;
                oPatient.CustomAttribute3 = string.Empty;
                oPatient.CustomAttribute4 = string.Empty;
                oPatient.CustomAttribute5 = string.Empty;
                oPatient.WristBandType = "ADULT";
            }
            else
            {
                oPatient.AgeInYear = Convert.ToInt32(string.IsNullOrEmpty(record[16]) ? "0" : record[16]);
                oPatient.AgeInMonth = Convert.ToInt32(string.IsNullOrEmpty(record[17]) ? "0" : record[17]);
                oPatient.AgeInDay = Convert.ToInt32(string.IsNullOrEmpty(record[18]) ? "0" : record[18]);
                oPatient.CustomAttribute1 = string.IsNullOrEmpty(record[19]) ? string.Empty : record[19];
                oPatient.CustomAttribute2 = string.IsNullOrEmpty(record[20]) ? string.Empty : record[20];
                oPatient.CustomAttribute3 = string.IsNullOrEmpty(record[21]) ? string.Empty : record[21];
                oPatient.CustomAttribute4 = string.IsNullOrEmpty(record[22]) ? string.Empty : record[22];
                oPatient.CustomAttribute5 = string.IsNullOrEmpty(record[23]) ? string.Empty : record[23];
                oPatient.WristBandType = string.IsNullOrEmpty(record[24]) ? "ADULT" : record[24];
            }

            return oPatient;
        }

        private void ResetPatientEntry()
        {
            txtMRN.Text = string.Empty;
            optMale.Checked = true;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            dteDateOfBirth.Value = DateTime.Now.Date;
            txtAgeInYear.Text = "0";
            txtAgeInMonth.Text = "0";
            txtAgeInDay.Text = "0";
            chkIsAllergy.Checked = false;
            chkIsFallRisk.Checked = false;
            chkIsDNR.Checked = false;

            if (Settings.Default.IsUsingPatientCustomAttribute)
            {
                txtCustomAttribute1.Text = string.Empty;
                txtCustomAttribute2.Text = string.Empty;
                txtCustomAttribute3.Text = string.Empty;
                txtCustomAttribute4.Text = string.Empty;
                txtCustomAttribute5.Text = string.Empty;
            }

            txtRegistrationNo.Text = Settings.Default.RegistrationNoPrefix;
            dteRegistrationDate.Value = DateTime.Now.Date;
            txtRegistrationTime.Text = DateTime.Now.ToString(Constant.TIME_FORMAT);
            txtPhysicianName.Text = string.Empty;
            txtWardName.Text = string.Empty;
            txtRoomNo.Text = string.Empty;
            txtBedNo.Text = string.Empty;

            tabPatientInformation.SelectedIndex = 0;
            txtMRN.Focus();
        }

        private void SetPrintStatus()
        {
            //Enabled or Disabled Button Print
            btnPrintLabel.Enabled = ZebraPrinterLib.isZebraPrinter && this.IsPrinterOnline;
            if (btnPrintLabel.Enabled)
            {
                lblWristbandType.Text = ZebraPrinterLib.WristbandType;
                btnPrintLabel.BackColor = Color.LawnGreen;
            }
            else
            {
                lblWristbandType.Text = string.Empty;
                btnPrintLabel.BackColor = Color.Red;
            }
        }

        private void SetAutoCompleteDataSource(TextBox control, AutoCompleteType type)
        {
            string[] autoCompleteDS = new string[] { "" };
            switch (type)
            {
                case AutoCompleteType.MRN:
                    autoCompleteDS = (from p in Patients
                                      select p.MRN).Distinct().ToArray();
                    break;
                case AutoCompleteType.FirstName:
                    autoCompleteDS = (from p in Patients
                                      select p.FirstName).Distinct().ToArray();
                    break;
                case AutoCompleteType.LastName:
                    autoCompleteDS = (from p in Patients
                                      select p.LastName).Distinct().ToArray();
                    break;
                case AutoCompleteType.PhysicianName:
                    autoCompleteDS = (from p in Patients
                                      select p.Physician).Distinct().ToArray();
                    break;
                case AutoCompleteType.WardName:
                    autoCompleteDS = (from p in Patients
                                      select p.WardName).Distinct().ToArray();
                    break;
                case AutoCompleteType.RoomNo:
                    autoCompleteDS = (from p in Patients
                                      select p.RoomNo).Distinct().ToArray();
                    break;
                case AutoCompleteType.BedNo:
                    autoCompleteDS = (from p in Patients
                                      select p.BedNo).Distinct().ToArray();
                    break;
                default:
                    break;
            }
            control.AutoCompleteCustomSource.AddRange(autoCompleteDS);
            control.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            control.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        //private void LoadPrintingLog(DateTime registrationDate)
        //{
        //    try
        //    {
        //        string fileName = string.Format(@"{0}\data\{1}.dat", Application.StartupPath, registrationDate.Date.ToString("yyyyMMdd"));
        //        string dataMode = String.IsNullOrEmpty(Settings.Default.DataMode) ? "Local" : Settings.Default.DataMode;
        //        if (dataMode != "Local")
        //        {
        //            fileName = string.Format(@"{0}\{1}.dat", Settings.Default.RemoteDataPath, registrationDate.Date.ToString("yyyyMMdd"));
        //        }

        //        FileInfo file = new FileInfo(fileName);

        //        if (file.Exists)
        //        {
        //            ApplicationParameter.ItemList = new List<Patient>();
        //            IEnumerable<string> recordList = File.ReadAllLines(fileName);
        //            foreach (string patientInfo in recordList)
        //            {
        //                // Read the data and convert it to the appropriate data type.
        //                string[] record = patientInfo.Split(';');
        //                Patient oPatient = new Patient();
        //                oPatient = ConvertIntoPatientObject(record);
        //                ApplicationParameter.ItemList.Add(oPatient);
        //            }
        //        }
        //        else
        //        {
        //            ApplicationParameter.ItemList = new List<Patient>();
        //        }
        //        RefreshBindingSource();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, Constant.APP_ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void LoadPatientList()
        {
            try
            {
                LoadPatientListFromLog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Constant.APP_ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPatientListFromLog()
        {
            DirectoryInfo dir = new DirectoryInfo(string.Format(@"{0}\data", Application.StartupPath));
            List<FileInfo> lstFile = dir.GetFiles("*.dat").ToList();
            List<Patient> lstPatient = new List<Patient>();
            foreach (FileInfo file in lstFile)
            {
                if (file.Exists)
                {
                    IEnumerable<string> recordList = File.ReadAllLines(file.FullName);
                    foreach (string patientInfo in recordList)
                    {
                        // Read the data and convert it to the appropriate data type.
                        string[] record = patientInfo.Split(';');
                        Patient oPatient = lstPatient.Where(lst => lst.MRN == record[0]).FirstOrDefault();
                        if (oPatient == null)
                        {
                            oPatient = new Patient();
                        }
                        else
                        {
                            lstPatient.Remove(oPatient);
                        }

                        oPatient = ConvertIntoPatientObject(record);
                        lstPatient.Add(oPatient);
                    }
                }
            }
            Patients = lstPatient.AsEnumerable<Patient>();
        }

        public void RefreshData(Patient oPatient)
        {
            RefreshBindingSource();
            RefreshPatientList(oPatient);
        }

        private void RefreshPatientList(Patient oPatient)
        {
            Patient patient = Patients.Where(lst => lst.MRN == oPatient.MRN).FirstOrDefault();
            List<Patient> lstPatient = Patients.ToList();
            if (patient == null)
            {
                patient = oPatient;
            }
            else
            {
                lstPatient.Remove(oPatient);
            }

            lstPatient.Add(oPatient);
            Patients = lstPatient.AsEnumerable();
        }

        private void RefreshAutoCompleteDataSource()
        {
            //Invoke the methods concurrently
            Parallel.Invoke(
                () => SetAutoCompleteDataSource(txtMRN, AutoCompleteType.MRN),
                () => SetAutoCompleteDataSource(txtFirstName, AutoCompleteType.FirstName),
                () => SetAutoCompleteDataSource(txtLastName, AutoCompleteType.LastName),
                () => SetAutoCompleteDataSource(txtPhysicianName, AutoCompleteType.PhysicianName),
                () => SetAutoCompleteDataSource(txtWardName, AutoCompleteType.WardName),
                () => SetAutoCompleteDataSource(txtRoomNo, AutoCompleteType.RoomNo),
                () => SetAutoCompleteDataSource(txtBedNo, AutoCompleteType.BedNo)
                );
        }

        private void RefreshBindingSource()
        {
            bindingSource1.DataSource = ApplicationParameter.ItemList;
            bindingSource1.ResetBindings(false);
        }

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

        private void PrintPatientLabel()
        {
            Patient oPatient;

            string customAttribute1 = string.Empty;
            string customAttribute2 = string.Empty;
            string customAttribute3 = string.Empty;
            string customAttribute4 = string.Empty;
            string customAttribute5 = string.Empty;
            if (Settings.Default.IsUsingPatientCustomAttribute)
            {
                customAttribute1 = !string.IsNullOrEmpty(txtCustomAttribute1.Text) ? txtCustomAttribute1.Text : string.Empty;
                customAttribute2 = !string.IsNullOrEmpty(txtCustomAttribute2.Text) ? txtCustomAttribute2.Text : string.Empty;
                customAttribute3 = !string.IsNullOrEmpty(txtCustomAttribute3.Text) ? txtCustomAttribute3.Text : string.Empty;
                customAttribute4 = !string.IsNullOrEmpty(txtCustomAttribute4.Text) ? txtCustomAttribute4.Text : string.Empty;
                customAttribute5 = !string.IsNullOrEmpty(txtCustomAttribute5.Text) ? txtCustomAttribute5.Text : string.Empty;
            }

            if (isAddNew)
            {
                oPatient = new Patient()
                {
                    MRN = txtMRN.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Gender = optMale.Checked ? "M" : "F",
                    DateOfBirth = dteDateOfBirth.Value.ToString("yyyyMMdd"),
                    IsAllergy = chkIsAllergy.Checked,
                    AllergenName = txtAllergyInfo.Text,
                    IsFallenRisk = chkIsFallRisk.Checked,
                    IsDNR = chkIsDNR.Checked,
                    RegistrationNo = txtRegistrationNo.Text,
                    RegistrationDate = dteRegistrationDate.Value.ToString("yyyyMMdd"),
                    RegistrationTime = txtRegistrationTime.Text,
                    Physician = txtPhysicianName.Text,
                    WardName = txtWardName.Text,
                    RoomNo = txtRoomNo.Text,
                    BedNo = txtBedNo.Text,
                    AgeInYear = Convert.ToInt32(txtAgeInYear.Text),
                    AgeInMonth = Convert.ToInt32(txtAgeInMonth.Text),
                    AgeInDay = Convert.ToInt32(txtAgeInDay.Text),
                    CustomAttribute1 = customAttribute1,
                    CustomAttribute2 = customAttribute2,
                    CustomAttribute3 = customAttribute3,
                    CustomAttribute4 = customAttribute4,
                    CustomAttribute5 = customAttribute5,
                    WristBandType = ZebraPrinterLib.WristbandType
                };
                PrintLabel(oPatient);
                UpdatePatientList(oPatient);
            }
        }

        private void PrintLabel(Patient oPatient)
        {
            try
            {
                //if (MainForm.IsUsingPrinterLabel)
                //{
                //    if (chkPrintWristband.Checked)
                //PrintWristband(Settings.Default.WristbandPrinterName, oPatient);
                //    if (chkPrintLabel.Checked)
                //        PrintLabel(Settings.Default.PrinterLabelName, oPatient);
                //}
                //else
                //{
                PrintWristband(Settings.Default.LabelPrinterName, oPatient);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Communication problem with device: \n{1}", ex.Message), Constant.APP_ApplicationName);
            }
        }

        private bool PrintWristband(string printerName, Patient oPatient)
        {
            try
            {
                DirectPrinting print = new DirectPrinting();

                //Initialize Printer
                print.OpenPrinter(printerName);
                print.StartDocPrinter();
                print.Send("\n");

                string command = GenerateZPLCommand(oPatient);

                print.Send("n\n"); // clear the image buffer
                print.Send(command.ToString());
                print.Send("p1\n"); //print one label
                print.EndDocPrinter();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private string GenerateZPLCommand(Patient oPatient)
        {
            string result = "";
            switch (ZebraPrinterLib.WristbandType)
            {
                case ZebraPrinterLib.WRISTBAND_TYPE_Adult_Clip:
                    result = GenerateZPLForAdultClip(oPatient);
                    break;
                case ZebraPrinterLib.WRISTBAND_TYPE_Adult_Adhesive:
                    result = GenerateZPLForAdultAdhesive(oPatient);
                    break;
                case ZebraPrinterLib.WRISTBAND_Type_Adult_Comfort_Blue:
                    result = GenerateZPLForAdultAdhesive(oPatient);
                    break;
                case ZebraPrinterLib.WRISTBAND_Type_Adult_Comfort_Pink:
                    result = GenerateZPLForAdultAdhesive(oPatient);
                    break;
                case ZebraPrinterLib.WRISTBAND_Type_Adult_Splash_Blue:
                    result = GenerateZPLForAdultAdhesive(oPatient);
                    break;
                case ZebraPrinterLib.WRISTBAND_Type_Adult_Splash_Pink:
                    result = GenerateZPLForAdultAdhesive(oPatient);
                    break;
                case ZebraPrinterLib.WRISTBAND_Type_Adult_Splash_Red:
                    result = GenerateZPLForAdultAdhesive(oPatient);
                    break;
                case ZebraPrinterLib.WRISTBAND_Type_Adult_Splash_Yellow:
                    result = GenerateZPLForAdultAdhesive(oPatient);
                    break;
                case ZebraPrinterLib.WRISTBAND_Type_Adult_Splash_Purple:
                    result = GenerateZPLForAdultAdhesive(oPatient);
                    break;
                case ZebraPrinterLib.WRISTBAND_TYPE_Infant_Clip:
                    result = GenerateZPLForInfantClip(oPatient);
                    break;
                case ZebraPrinterLib.WRISTBAND_Type_Soft_Infant:
                    result = GenerateZPLForSoftInfant(oPatient);
                    break;
                default:
                    break;
            }
            return result;
        }

        private string GenerateZPLForSoftInfant(Patient oPatient)
        {
            StringBuilder command = new StringBuilder();
            string qrCodeContent = string.Format("{0},{1},{2},{3},{4},{5}", oPatient.MRN, oPatient.FirstName, oPatient.LastName, oPatient.Gender, oPatient.RegistrationNo, oPatient.AllergenName);
            string barcodeValue = txtMRN.Text;

            command.Append(string.Format(@"^XA"));
            command.Append(string.Format(@"^POI"));
            command.Append(string.Format(@"^FWR"));     // Set the default orientation for all command fields (FD)
            command.Append(string.Format(@"^LH0,135")); // Set the Label Home            
            //command.Append(string.Format(@"^F190,800 ^BY1,2.0,80^BCR,80,N,N,N^FD{0}^FS", barcodeValue));
            command.Append(string.Format(@"^FO230,10 ^A0,30,30^FD{0}^FS", lblPreviewLine1.Text));
            command.Append(string.Format(@"^FO190,10 ^A0,25,25^FD{0}^FS", lblPreviewLine2.Text));
            command.Append(string.Format(@"^FO160,10 ^A0,25,25^FD{0}^FS", lblPreviewLine3.Text));
            command.Append(string.Format(@"^FO130,10 ^A0,25,25^FD{0}^FS", lblPreviewLine4.Text));
            if (oPatient.IsAllergy)
            {
                command.Append(string.Format(@"^FO130,330 ^A0,25,25^FD{0}^FS", lblPatientStatus.Text));
            }
            if (lblCustomAttribute.Visible)
            {
                command.Append(string.Format(@"^FO100,10 ^A0,22,22^FD{0}^FS", lblCustomAttribute.Text));
            }

            command.Append(string.Format(@"^FO70,10 ^A0,20,20^FD{0}^FS", mainForm.CompanyName));
            command.AppendLine(string.Format("^XZ"));

            return command.ToString();
        }

        #region Generate ZPL Methods

        private string GenerateZPLForAdultAdhesive(Patient oPatient)
        {
            StringBuilder command = new StringBuilder();
            string qrCodeContent = string.Format("{0},{1},{2},{3},{4},{5}", oPatient.MRN, oPatient.FirstName, oPatient.LastName, oPatient.Gender, oPatient.RegistrationNo, oPatient.AllergenName);
            string barcodeValue = txtMRN.Text;

            command.Append(string.Format(@"^XA"));
            command.Append(string.Format(@"^POI"));
            command.Append(string.Format(@"^FWR"));     // Set the default orientation for all command fields (FD)
            command.Append(string.Format(@"^LH0,236")); // Set the Label Home
            if (Settings.Default.BarcodeType == Enumeration.BarcodeType.QRCode.ToString())
                command.Append(string.Format(@"^FO60,160 ^BQN,2,6,M^FDMA{0}^FS", qrCodeContent));
            else
                command.Append(string.Format(@"^FO80,160 ^BY1,2.0,180^BCN,180,Y,N,N^FD{0}^FS", barcodeValue));

            command.Append(string.Format(@"^FO250,400 ^A0,38,38^FD{0}^FS", lblPreviewLine1.Text));
            command.Append(string.Format(@"^FO190,400 ^A0,33,33^FD{0}^FS", lblPreviewLine2.Text));
            command.Append(string.Format(@"^FO150,400 ^A0,33,33^FD{0}^FS", lblPreviewLine3.Text));
            command.Append(string.Format(@"^FO110,400 ^A0,33,33^FD{0}^FS", lblPreviewLine4.Text));
            if (oPatient.IsAllergy)
                command.Append(string.Format(@"^FO110,850 ^A0,33,33^FD{0}^FS", lblPatientStatus.Text));
            if (lblCustomAttribute.Visible)
                command.Append(string.Format(@"^FO60,400 ^A0,31,31^FD{0}^FS", lblCustomAttribute.Text));

            //command.Append(string.Format(@"^FO60,380 ^A0,31,31^FD{0}^FS", lblCustomAttribute.Text));

            command.Append(string.Format(@"^FO30,400 ^A0,26,26^FD{0}^FS", mainForm.CompanyName));
            command.AppendLine(string.Format("^XZ"));

            return command.ToString();
        }

        private string GenerateZPLForAdultClip(Patient oPatient)
        {
            StringBuilder command = new StringBuilder();
            string qrCodeContent = string.Format("{0},{1},{2},{3},{4},{5}", oPatient.MRN, oPatient.FirstName, oPatient.LastName, oPatient.Gender, oPatient.RegistrationNo, oPatient.AllergenName);
            string barcodeValue = txtMRN.Text;

            command.Append(string.Format(@"^XA"));
            command.Append(string.Format(@"^POI"));
            command.Append(string.Format(@"^FWR"));     // Set the default orientation for all command fields (FD)
            command.Append(string.Format(@"^LH0,236")); // Set the Label Home
            if (Settings.Default.BarcodeType == "QRCode")
                command.Append(string.Format(@"^FO95,80 ^BQN,2,8,M^FDMA{0}^FS", qrCodeContent));
            else
                command.Append(string.Format(@"^FO45,80 ^BY2,2.9,200^BCN,200,Y,N,N^FD{0}^FS", barcodeValue));
            command.Append(string.Format(@"^FO300,370 ^A0,38,38^FD{0}^FS", lblPreviewLine1.Text));
            command.Append(string.Format(@"^FO240,370 ^A0,33,33^FD{0}^FS", lblPreviewLine2.Text));
            command.Append(string.Format(@"^FO200,370 ^A0,33,33^FD{0}^FS", lblPreviewLine3.Text));
            command.Append(string.Format(@"^FO160,370 ^A0,33,33^FD{0}^FS", lblPreviewLine4.Text));
            if (oPatient.IsAllergy)
            {
                command.Append(string.Format(@"^FO160,830 ^A0,33,33^FD{0}^FS", lblPatientStatus.Text));
            }

            if (lblCustomAttribute.Visible)
            {
                command.Append(string.Format(@"^FO110,370 ^A0,33,33^FD{0}^FS", lblCustomAttribute.Text));
            }
            command.Append(string.Format(@"^FO30,370 ^A0,26,26^FD{0}^FS", mainForm.CompanyName));
            command.AppendLine(string.Format("^XZ"));

            return command.ToString();
        }

        private string GenerateZPLForInfantClip(Patient oPatient)
        {
            StringBuilder command = new StringBuilder();
            string qrCodeContent = string.Format("{0},{1},{2},{3},{4},{5}", oPatient.MRN, oPatient.FirstName, oPatient.LastName, oPatient.Gender, oPatient.RegistrationNo, oPatient.AllergenName);
            string barcodeValue = txtMRN.Text;

            command.Append(string.Format(@"^XA"));
            command.Append(string.Format(@"^POI"));
            command.Append(string.Format(@"^FWR"));     // Set the default orientation for all command fields (FD)
            command.Append(string.Format(@"^LH0,260")); // Set the Label Home
            if (Settings.Default.BarcodeType == Enumeration.BarcodeType.QRCode.ToString())
                command.Append(string.Format(@"^FO50,80 ^BQN,2,7,M^FDMA{0}^FS", qrCodeContent));
            else
                command.Append(string.Format(@"^FO80,110 ^BY1,2.0,180^BCN,180,Y,N,N^FD{0}^FS", barcodeValue));
            command.Append(string.Format(@"^FO250,340 ^A0,38,38^FD{0}^FS", lblPreviewLine1.Text));
            command.Append(string.Format(@"^FO190,340 ^A0,33,33^FD{0}^FS", lblPreviewLine2.Text));
            command.Append(string.Format(@"^FO150,340 ^A0,33,33^FD{0}^FS", lblPreviewLine3.Text));
            command.Append(string.Format(@"^FO110,340 ^A0,33,33^FD{0}^FS", lblPreviewLine4.Text));
            if (oPatient.IsAllergy)
            {
                command.Append(string.Format(@"^FO110,800 ^A0,33,33^FD{0}^FS", lblPatientStatus.Text));
            }
            if (lblCustomAttribute.Visible)
            {
                command.Append(string.Format(@"^FO60,340 ^A0,31,31^FD{0}^FS", lblCustomAttribute.Text));
            }

            command.Append(string.Format(@"^FO30,340 ^A0,26,26^FD{0}^FS", mainForm.CompanyName));
            command.AppendLine(string.Format("^XZ"));

            return command.ToString();
        }
        #endregion

        private void UpdatePatientList(Patient patient)
        {
            //List<Patient> tmpList = new List<Patient>();
            //tmpList = ApplicationParameter.ItemList;
            //tmpList.Add(patient);
            //ApplicationParameter.ItemList = tmpList;

            //RefreshData(patient);
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
    }
}
