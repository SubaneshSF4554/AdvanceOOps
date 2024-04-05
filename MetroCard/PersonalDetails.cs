using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCard
{
    public class PersonalDetails
    {
        public string UserName{get;set;}
        public string PhoneNum{get;set;}
        public PersonalDetails()
        {

        }
        public PersonalDetails(string userName,string mobNo)
        {
            UserName=userName;
            PhoneNum=mobNo;
        }
    }
}