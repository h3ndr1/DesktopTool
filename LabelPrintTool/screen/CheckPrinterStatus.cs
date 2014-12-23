using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CodeX.DesktopTool.Print
{
    public partial class CheckPrinterStatus : Form
    {
        private String[] zebraDeviceArray;
        public static bool isConnected = false;

        // Import the functions from ZUSB.dll
        #region Import the functions from ZUSB.dll
        [DllImport("ZUSB", CallingConvention = CallingConvention.Cdecl)]
        static extern int isUsbDllLoaded();

        // Attempts to connect the USB port with the current port settings.
        [DllImport("ZUSB", CallingConvention = CallingConvention.Cdecl)]
        static extern int usbConnect(byte[] data, int lengthOfData);

        //Disconnects the port connection.
        [DllImport("ZUSB", CallingConvention = CallingConvention.Cdecl)]
        private static extern int usbDisconnect();

        //Sends the number of bytes of the passed data to the connected device.
        [DllImport("ZUSB", CallingConvention = CallingConvention.Cdecl)]
        private static extern int usbSend(byte[] data, int length);

        //Attempts to receive data until Recv returns 0 bytes.
        [DllImport("ZUSB")]
        private static extern String usbRecvTillEmpty();

        //Retrieves a device information set that contains all the registered USB devices.
        [DllImport("ZUSB", CallingConvention = CallingConvention.Cdecl)]
        static extern String findUsbDevices(int vid);

        //Returns the status of USB port connection
        [DllImport("ZUSB", CallingConvention = CallingConvention.Cdecl)]
        private static extern int usbIsConnected();
        #endregion


        /****************************************************************************

        CheckPrinterStatus::getAllUsbDevices()

        Desc: This functions enumerate all registered USB device paths on particular 
         workstation.
        Input: None

        Output: Returns array of usb devices.

        *****************************************************************************/

        public static String[] getAllUsbDevices()
        {
            String devices = findUsbDevices(-1);
            return devices.Split(';'); //$NON-NLS-1$
        }

        public static String[] getAllPrinterParameters(string response)
        {
            return response.Split(';');
        }

        public CheckPrinterStatus()
        {
            InitializeComponent();
        }

        private void CheckPrinterStatus_Load(object sender, EventArgs e)
        {
            String usbString;

            // Load ZUSB.dll which provides routines to communicate with
            // zebra printer over USB channel.
            if (isUsbDllLoaded() < 0)
                return;

            //Enumerate all the zebra usb devices
            String[] allDevices = getAllUsbDevices();

            // check for specific vendor id in enumerated USB device path
            // For zebra printer Vendor id is 0A5F or 5F0A.
            List<String> zebraDeviceList = new List<String>();
            for (int i = 0; i < allDevices.Length; i++)
            {
                if ((allDevices[i].ToUpper().IndexOf("VID_0A5F") >= 0) || //$NON-NLS-1$
                     (allDevices[i].ToUpper().IndexOf("VID_5F0A") >= 0))
                { //$NON-NLS-1$
                    zebraDeviceList.Add(allDevices[i]);
                }
            }

            // Create array of zebra devices
            lstPrinter.Items.Clear();
            zebraDeviceArray = new String[zebraDeviceList.Count];
            for (int i = 0; i < zebraDeviceList.Count; i++)
            {
                usbString = (String)zebraDeviceList.ElementAt(i);                
                lstPrinter.Items.Add(usbString);
                zebraDeviceArray[i] = usbString;
            }

            if (zebraDeviceArray.Length>0)
            {
                GetWristbandCartridgeType();
            }
        }

        private void btnPrinterStatus_Click(object sender, EventArgs e)
        {
            String readResponse, errResponse, strSend;
            byte[] buffSend,  bZebraDeviceArray;
            int connectResult = -1, sendResult = -1;

            strSend = string.Format("{0}\r\n", "~HS");
            buffSend = ASCIIEncoding.UTF8.GetBytes(strSend);

            if (zebraDeviceArray.Length == 0)
            {
                MessageBox.Show("No Zebra Printer found!");
                return;
            }

            richTextBox1.Text = string.Empty;

            // Sending command one by one to all zebra devices
            // If it sent successfully than show response in response list
            // otherwise show appropriate error message.
            readResponse = "";
            errResponse = "";

            for (int i = 0; i < zebraDeviceArray.Length; i++)
            {
                connectResult = -1;
                sendResult = -1;
                if (readResponse.Length > 0)
                    readResponse = "";

                if (errResponse.Length > 0)
                    errResponse = "";
                try
                {
                    bZebraDeviceArray = ASCIIEncoding.UTF8.GetBytes(zebraDeviceArray[i]);
                    connectResult = usbConnect(bZebraDeviceArray, bZebraDeviceArray.Length);
                    if (connectResult == 0)
                    {
                        sendResult = usbSend(buffSend, buffSend.Length);
                        if (sendResult == 0)
                        {
                            readResponse = usbRecvTillEmpty();
                            readResponse = "Received from: " + zebraDeviceArray[i] + "----->" + readResponse;
                            richTextBox1.Text = readResponse;
                        }
                        else
                        {
                            errResponse = "Communication problem with device:" + zebraDeviceArray[i];
                            richTextBox1.Text = readResponse;
                        }

                    }
                    else
                    {
                        errResponse = "Communication problem with device:" + zebraDeviceArray[i];
                        richTextBox1.Text = readResponse;
                    }
                    usbDisconnect();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Exception caught: {0} \n{1}", zebraDeviceArray[i], ex.Message));
                }
            }

        }

        private void GetWristbandCartridgeType()
        {
            String readResponse, errResponse, strSend;
            byte[] buffSend, bZebraDeviceArray;
            int connectResult = -1, sendResult = -1;

            strSend = string.Format("{0}\r\n", ": ! U1 getvar \"media.cartridge.part_number\"");
            buffSend = ASCIIEncoding.UTF8.GetBytes(strSend);

            if (zebraDeviceArray.Length == 0)
            {
                MessageBox.Show("No Zebra Printer found!");
                return;
            }

            richTextBox1.Text = string.Empty;

            // Sending command one by one to all zebra devices
            // If it sent successfully than show response in response list
            // otherwise show appropriate error message.
            readResponse = "";
            errResponse = "";

            for (int i = 0; i < zebraDeviceArray.Length; i++)
            {
                connectResult = -1;
                sendResult = -1;
                if (readResponse.Length > 0)
                    readResponse = "";

                if (errResponse.Length > 0)
                    errResponse = "";
                try
                {
                    bZebraDeviceArray = ASCIIEncoding.UTF8.GetBytes(zebraDeviceArray[i]);
                    connectResult = usbConnect(bZebraDeviceArray, bZebraDeviceArray.Length);
                    if (connectResult == 0)
                    {
                        sendResult = usbSend(buffSend, buffSend.Length);
                        if (sendResult == 0)
                        {
                            readResponse = usbRecvTillEmpty();
                            //readResponse = "Received from: " + zebraDeviceArray[i] + "----->" + readResponse;
                            string partNumber = readResponse.Replace('"', ' ').Trim();
                            richTextBox1.Text = partNumber;
                            switch (partNumber)
                            {
                                case ZebraPrinterLib.CartridgeType.CARTRIDGE_Clip_Closure_Adult_PartNumber:
                                    txtCartridgeType.Text = string.Format("{0} (Part Number:{1})", "Clip Closure - Adult", partNumber);
                                    break;
                                case ZebraPrinterLib.CartridgeType.CARTRIDGE_Adhesive_Direct_Adult_PartNumber:
                                    txtCartridgeType.Text = string.Format("{0} (Part Number:{1})", "Adhesive Direct - Adult", partNumber);
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            errResponse = "Communication problem with device:" + zebraDeviceArray[i];
                            richTextBox1.Text = errResponse;
                        }

                    }
                    else
                    {
                        errResponse = "Communication problem with device:" + zebraDeviceArray[i];
                        richTextBox1.Text = errResponse;
                    }
                    usbDisconnect();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Exception caught: {0} \n{1}", zebraDeviceArray[i], ex.Message));
                }
            }

        }
    }
}
