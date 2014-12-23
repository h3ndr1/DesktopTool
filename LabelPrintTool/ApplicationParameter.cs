using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeX.Data.Model;

namespace CodeX.DesktopTool.Print
{
    public static class ApplicationParameter
    {
        public static bool IsUsingPrinterLabel = false;

        public static List<Patient> PatientList = new List<Patient>();
        public static List<vItemProduct> ItemList = new List<vItemProduct>(); 
        public static Patient LastEntryPatient; //last entry or printed patient
    }
}
