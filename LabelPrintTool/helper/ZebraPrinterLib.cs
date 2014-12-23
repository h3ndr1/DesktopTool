using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CodeX.DesktopTool.Print
{
    public static class ZebraPrinterLib
    {
        public const string WRISTBAND_TYPE_Adult_Clip = "ADULT-CLIP";
        public const string WRISTBAND_TYPE_Adult_Adhesive = "ADULT-ADHESIVE";
        public const string WRISTBAND_TYPE_Infant_Clip = "INFANT-CLIP";
        public const string WRISTBAND_Type_Adult_Splash_Blue = "ADULT-Economy (Blue)";
        public const string WRISTBAND_Type_Adult_Splash_Pink = "ADULT-Economy (Pink)";
        public const string WRISTBAND_Type_Adult_Splash_Red = "ADULT-Economy (Red)";
        public const string WRISTBAND_Type_Adult_Splash_Yellow = "ADULT-Economy (Yellow)";
        public const string WRISTBAND_Type_Adult_Splash_Purple = "ADULT-Economy (Purple)";
        public const string WRISTBAND_Type_Adult_Comfort_Blue = "ADULT-Comfort (Blue)";
        public const string WRISTBAND_Type_Adult_Comfort_Pink = "ADULT-Comfort (Pink)";
        public const string WRISTBAND_Type_Soft_Infant = "Soft Infant";


        private static String[] zebraDeviceArray;
        private static List<string> zebraPrinterList = new List<string>();
        private static string wristbandType; //based on installed cartridge : ADULT/INFANT/PEDIATRIC

        public static string WristbandType
        {
            get { return ZebraPrinterLib.wristbandType; }
            set { ZebraPrinterLib.wristbandType = value; }
        }

        //private static string printerModel;

        //public static string PrinterModel
        //{
        //    get { return zebraPrinterList[0]; }
        //}

        public static List<string> ZebraPrinterList
        {
            get { return ZebraPrinterLib.zebraPrinterList; }
            set { ZebraPrinterLib.zebraPrinterList = value; }
        }

        public static bool isZebraPrinter = false;
        private static bool isConnected = false;

        public static class CartridgeType
        {
            public const string CARTRIDGE_Clip_Closure_Adult_PartNumber = "10007000";
            public const string CARTRIDGE_Clip_Closure_Infant_PartNumber = "10007003";
            public const string CARTRIDGE_Adhesive_Direct_Adult_PartNumber = "10006995-4";
            public const string CARTRIDGE_Adhesive_Direct_Adult_DNR_PartNumber = "10006995-4";
            public const string CARTRIDGE_Adhesive_Direct_Pediatric_PartNumber = "10007000";
            public const string CARTRIDGE_Adhesive_Direct_Infant_PartNumber = "10007000";
            public const string CARTRIDGE_Comfort_Adult_Blue_PartNumber = "10010951-2";
            public const string CARTRIDGE_Comfort_Adult_Pink_PartNumber = "10010951-5";
            public const string CARTRIDGE_ZBand_Splash_Adult_Blue_PartNumber = "10012717-3";
            public const string CARTRIDGE_ZBand_Splash_Adult_Pink_PartNumber = "10012717-5";
            public const string CARTRIDGE_ZBand_Splash_Adult_Red_PartNumber = "10012717-1";
            public const string CARTRIDGE_ZBand_Splash_Adult_Yellow_PartNumber = "10012717-2";
            public const string CARTRIDGE_ZBand_Splash_Adult_Purple_PartNumber = "10012717-7";
            public const string CARTRIDGE_ZBand_Soft_Infant_PartNumber = "10007746";
        }

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

        public static void LoadZebraDevicesArray()
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
            zebraDeviceArray = new String[zebraDeviceList.Count];
            List<string> list = new List<string>();
            for (int i = 0; i < zebraDeviceList.Count; i++)
            {
                usbString = (String)zebraDeviceList.ElementAt(i);
                if (usbString.ToUpper().Contains("PID_008B"))
                    list.Add("HC100 300 dpi");
                else
                    if (usbString.ToUpper().Contains("PID_0081"))
                        list.Add("GK420t"); 
                    else
                        list.Add("Unregistered Printer");
                zebraDeviceArray[i] = usbString;
            }
            zebraPrinterList = list;
            ZebraPrinterLib.isZebraPrinter = zebraPrinterList.Count > 0;
        }

        public static bool CheckPrinterIsConnected(string printerName)
        {
            bool result = false;

            foreach (string item in zebraPrinterList)
            {
                if (printerName.ToUpper().Contains(item.ToUpper()))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public static string GetWristbandCartridgeType()
        {
            String readResponse, errResponse, strSend;
            byte[] buffSend, bZebraDeviceArray;
            int connectResult = -1, sendResult = -1;
            string result = string.Empty;

            strSend = string.Format("{0}\r\n", ": ! U1 getvar \"media.cartridge.part_number\"");
            buffSend = ASCIIEncoding.UTF8.GetBytes(strSend);

            if (zebraDeviceArray.Length == 0)
            {
                result = string.Format("{0}|{1}", "error", "No Zebra Printer found!");
            }


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
                            string partNumber = readResponse.Replace('"', ' ').Trim();
                            switch (partNumber)
                            {
                                case CartridgeType.CARTRIDGE_Clip_Closure_Adult_PartNumber:
                                    wristbandType = WRISTBAND_TYPE_Adult_Clip;
                                    result = string.Format("{0} ({1})", "Clip Closure - Adult", partNumber);
                                    break;
                                case CartridgeType.CARTRIDGE_Adhesive_Direct_Adult_PartNumber:
                                    wristbandType = WRISTBAND_TYPE_Adult_Adhesive;
                                    result = string.Format("{0} ({1})", "Adhesive Direct - Adult", partNumber);
                                    break;
                                case CartridgeType.CARTRIDGE_Clip_Closure_Infant_PartNumber:
                                    wristbandType = WRISTBAND_TYPE_Infant_Clip;
                                    result = string.Format("{0} ({1})", "Clip Closure - Infant", partNumber);
                                    break;
                                case CartridgeType.CARTRIDGE_ZBand_Splash_Adult_Blue_PartNumber:
                                    wristbandType = WRISTBAND_Type_Adult_Splash_Blue;
                                    result = string.Format("{0} ({1})", "Economy (Blue) - Adult", partNumber);
                                    break;
                                case CartridgeType.CARTRIDGE_ZBand_Splash_Adult_Pink_PartNumber:
                                    wristbandType = WRISTBAND_Type_Adult_Splash_Pink;
                                    result = string.Format("{0} ({1})", "Economy (Pink) - Adult", partNumber);
                                    break;
                                case CartridgeType.CARTRIDGE_ZBand_Splash_Adult_Red_PartNumber:
                                    wristbandType = WRISTBAND_Type_Adult_Splash_Red;
                                    result = string.Format("{0} ({1})", "Economy (Red) - Adult", partNumber);
                                    break;
                                case CartridgeType.CARTRIDGE_ZBand_Splash_Adult_Yellow_PartNumber:
                                    wristbandType = WRISTBAND_Type_Adult_Splash_Yellow;
                                    result = string.Format("{0} ({1})", "Economy (Yellow) - Adult", partNumber);
                                    break;
                                case CartridgeType.CARTRIDGE_ZBand_Splash_Adult_Purple_PartNumber:
                                    wristbandType = WRISTBAND_Type_Adult_Splash_Purple;
                                    result = string.Format("{0} ({1})", "Economy (Purple) - Adult", partNumber);
                                    break;
                                case CartridgeType.CARTRIDGE_Comfort_Adult_Blue_PartNumber:
                                    wristbandType = WRISTBAND_Type_Adult_Comfort_Blue;
                                    result = string.Format("{0} ({1})", "Comfort (Blue) - Adult", partNumber);
                                    break;
                                case CartridgeType.CARTRIDGE_Comfort_Adult_Pink_PartNumber:
                                    wristbandType = WRISTBAND_Type_Adult_Comfort_Pink;
                                    result = string.Format("{0} ({1})", "Comfort (Pink) - Adult", partNumber);
                                    break;
                                case CartridgeType.CARTRIDGE_ZBand_Soft_Infant_PartNumber:
                                    wristbandType = WRISTBAND_Type_Soft_Infant;
                                    result = string.Format("{0} ({1})", "Soft Infant", partNumber);
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            errResponse = "Communication problem with device:" + zebraDeviceArray[i];
                            result = string.Format("{0}|{1}", "error", errResponse);
                        }

                    }
                    else
                    {
                        errResponse = "Communication problem with device:" + zebraDeviceArray[i];
                        result = string.Format("{0}|{1}", "error", errResponse);
                    }
                    usbDisconnect();
                }
                catch (Exception ex)
                {
                    result = string.Format("{0}|{1}", "error", string.Format("Exception caught: {0} \n{1}", zebraDeviceArray[i], ex.Message));
                    return result;
                }
            }
            return result;
        }
    }
}
