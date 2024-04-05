using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManageMent
{
    public enum FoodType{Select,Veg,NonVeg}
    public enum Gender{select,Male,Female,Transgender}
    public class PersonalDetails
    {
        public string UserName{get;set;}
        public string MobileNumber{get;set;}
        public string AadharNumber{get;set;}
        public string Address{get;set;}
        public FoodType FoodType{get;set;}
        public Gender Gender{get;set;}
        public PersonalDetails(string userName,string mobileNumber,string aadharNumber,string address,FoodType foodType,Gender gender)
        {
            UserName=userName;
            MobileNumber=mobileNumber;
            AadharNumber=aadharNumber;
            Address=address;
            FoodType=foodType;
            Gender=gender;
        }
        public PersonalDetails()
        {
            
        }

    }
}