using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeX.DesktopTool.Print
{
    public class Patient
    {
        public string RegistrationNo { get; set; }
        public string RegistrationDate { get; set; }
        public DateTime PatientRegistrationDate
        {
            get
            {
                DateTime dateOfBirth = new DateTime(Convert.ToInt32(RegistrationDate.Substring(0, 4)), Convert.ToInt32(RegistrationDate.Substring(4, 2)), Convert.ToInt32(RegistrationDate.Substring(6, 2)));
                return dateOfBirth;
            }
        }
        public string RegistrationTime { get; set; }
        public string MRN { get; set; }
        public string PatientName 
        {
            get 
            {
                return string.Format("{0} {1}", LastName.ToUpper(), string.IsNullOrWhiteSpace(FirstName) ? string.Empty : string.Format(", {0}", FirstName));
            } 
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string GenderLabel 
        {
            get
            {
                return (Gender == "M" ? "Male" : "Female");
            }
        }
        public string DateOfBirth { get; set; }
        public string PatientDOB
        {
            get 
            {
                DateTime dateOfBirth = new DateTime(Convert.ToInt32(DateOfBirth.Substring(0,4)), Convert.ToInt32(DateOfBirth.Substring(4, 2)), Convert.ToInt32(DateOfBirth.Substring(6, 2)));
                return dateOfBirth.ToString("dd-MMM-yyyy");
            }
        }
        public DateTime DOB
        {
            get
            {
                DateTime dateOfBirth = new DateTime(Convert.ToInt32(DateOfBirth.Substring(0, 4)), Convert.ToInt32(DateOfBirth.Substring(4, 2)), Convert.ToInt32(DateOfBirth.Substring(6, 2)));
                return dateOfBirth;             
            }
        }
        public string Age { get; set; }
        public int AgeInYear { get; set; }
        public int AgeInMonth { get; set; }
        public int AgeInDay { get; set; }
        public string Physician { get; set; }
        public string WardName { get; set; }
        public string RoomNo { get; set; }
        public string BedNo { get; set; }       
        public string Location { get; set; }
        public string PatientLocation
        {
            get
            {
                string wardName = string.IsNullOrWhiteSpace(WardName) ? string.Empty : WardName;
                string roomNo = string.IsNullOrWhiteSpace(RoomNo) ? string.Empty : RoomNo;
                string bedNo = string.IsNullOrWhiteSpace(BedNo) ? string.Empty : BedNo;
                return string.Format("{0} #{1}-{2}", wardName, roomNo, bedNo);
            }
        }
        public bool IsAllergy { get; set; }
        public string AllergenName { get; set; }
        public bool IsFallenRisk { get; set; }
        public bool IsDNR { get; set; }

        public string CustomAttribute1 { get; set; }
        public string CustomAttribute2 { get; set; }
        public string CustomAttribute3 { get; set; }
        public string CustomAttribute4 { get; set; }
        public string CustomAttribute5 { get; set; }
        public string WristBandType { get; set; }
    }
}
