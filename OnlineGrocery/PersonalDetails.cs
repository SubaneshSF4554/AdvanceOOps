using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery
{
    public class PersonalDetails
    {
        public string Name{get;set;}
        public string FatherName{get;set;}
        public string Gender{get;set;}
        public string MobNo{get;set;}
        public DateTime DOB{get;set;}
        public string MailID{get;set;}
        public PersonalDetails(string name,string fathername,string gender,string mobno,DateTime dob,string mailID)
        {
            Name=name;
            FatherName=fathername;
            Gender=gender;
            MobNo=mobno;
            DOB=dob;
            MailID=mailID;
        }
        public PersonalDetails()
        {
            
        }

    }
}
    