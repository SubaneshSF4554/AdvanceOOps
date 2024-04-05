using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManageMent
{
    public class UserDetails:PersonalDetails,IWalletManager
    {
        private static int s_userID=1000;
        public string UserID;
        private double _walletBalance;
        public double WalletBalance{get{return _walletBalance;}}
        public UserDetails(string userName,string mobileNumber,string aadharNumber,string address,FoodType foodType,Gender gender,double balance)
        :base(userName,mobileNumber,aadharNumber,address,foodType,gender)
        {
            s_userID++;
            UserID="SF"+s_userID;
            _walletBalance=balance;
        }
        public UserDetails(string user)
        {
            string[] value=user.Split(",");
            s_userID=int.Parse(value[0].Remove(0,2));
            UserID=value[0];
            UserName=value[1];
            MobileNumber=value[2];
            AadharNumber=value[3];
            Address=value[4];
            FoodType=Enum.Parse<FoodType>(value[5],true);
            Gender=Enum.Parse<Gender>(value[6],true);
            _walletBalance=double.Parse(value[7]);
        }
        public  void WalletRecharge(double amount)
        {
             _walletBalance+=amount;
             Console.WriteLine("Now your balance is : "+_walletBalance);
        }
        public  void DeductBalance(double amount)
        {
            _walletBalance-=amount;
            Console.WriteLine("Now your balance is : "+_walletBalance);


        }

    }
}