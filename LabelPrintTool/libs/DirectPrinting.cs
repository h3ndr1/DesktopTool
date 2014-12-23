using System;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace CodeX.DesktopTool.Print
{
    public class DirectPrinting
    {
        private string printerName;
        private DOCINFOW thisDocInfo;
        private IntPtr thisPrinterHandler;

        #region "Interop UnManage"

        [DllImport("winspool.drv", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern long OpenPrinter(string pPrinterName, ref IntPtr phPrinter, int pDefault);

        [DllImport("winspool.drv", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern IntPtr StartDocPrinter(IntPtr hPrinter, int Level, ref DOCINFOW pDocInfo);

        [DllImport("winspool.drv", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true)]
        public static extern long StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern long WritePrinter(IntPtr hPrinter, string data, int buf, ref int pcWritten);

        [DllImport("winspool.drv", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true)]
        public static extern long EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true)]
        public static extern long EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true)]
        public static extern long ClosePrinter(IntPtr hPrinter);

        #endregion

        #region "Public Properties"

        public string DocumentDatatype
        {
            get { return thisDocInfo.pDataType; }
        }

        public string DocumentName
        {
            get { return thisDocInfo.pDocName; }
        }

        public string DocumentOutputFile
        {
            get { return thisDocInfo.pOutputFile; }
        }

        public IntPtr PrinterHandler
        {
            get { return thisPrinterHandler; }
        }

        #endregion

        #region "Raw Printer"

        public void OpenPrinter(string printer)
        {
            OpenPrinter(printer, false);
        }

        public void OpenPrinter(string printer, bool isStartDocPrinter)
        {
            printerName = printer;
            OpenPrinter(printerName, ref thisPrinterHandler, 0);
            if (isStartDocPrinter) StartDocPrinter();
        }

        public void StartDocPrinter()
        {
            thisDocInfo.pDataType = "RAW";
            StartDocPrinter(thisPrinterHandler, 1, ref thisDocInfo);
        }

        public void StartPagePrinter()
        {
            StartPagePrinter(thisPrinterHandler);
        }

        public void EndPagePrinter()
        {
            EndPagePrinter(thisPrinterHandler);
        }

        public void EndDocPrinter()
        {
            EndDocPrinter(thisPrinterHandler);
        }

        public void ClosePrinter()
        {
            ClosePrinter(thisPrinterHandler);

            PrintDocument doc = new PrintDocument();
            PrinterSettings setting = new PrinterSettings();
            setting.PrinterName = printerName;
            doc.PrinterSettings = setting;
            doc.Print();
        }

        #endregion

        #region "Send Information"

        public void Send(string sData)
        {
            int lpcWritten = 0;
            WritePrinter(thisPrinterHandler, sData, sData.Length, ref lpcWritten);
        }

        public void SendLine(string sData)
        {
            Send(sData + "\f\r\n");
        }

        public void SendNewPage()
        {
            Send("\f");
        }

        #endregion

        public string EncryptText(string sourceText)
        {
            string result = string.Empty;
            char[] sourceTextCharList = sourceText.ToCharArray();

            foreach (char chr in sourceTextCharList)
            {
                char encryptedChar = Convert.ToChar(((int)chr) + 237);
                result += (encryptedChar);
            }
            return result;
        }

        public string DecryptText(string encryptedText)
        {
            string result = string.Empty;
            char[] encryptedTextCharList = encryptedText.ToCharArray();

            foreach (char chr in encryptedTextCharList)
            {
                char decryptedChar = Convert.ToChar(((int)chr) - 237);
                result += (decryptedChar);
            }
            return result;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DOCINFOW
    {
        [MarshalAs(UnmanagedType.LPWStr)] public string pDocName;
        [MarshalAs(UnmanagedType.LPWStr)] public string pOutputFile;
        [MarshalAs(UnmanagedType.LPWStr)] public string pDataType;
    }
}