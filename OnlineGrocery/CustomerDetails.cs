using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace OnlineGrocery
{
    public class CustomerDetails:PersonalDetails,IBalance
    {
        public static int s_customerID=1000;
        public string CustomerID;
        private double _Balance;
        public double Balance{get{return _Balance;}}
        public CustomerDetails(double balance,string name,string fathername,string gender,string mobno,DateTime dob,string mailID):base(name,fathername,gender,mobno,dob,mailID)
        {
           s_customerID++;
           CustomerID="CID"+s_customerID;
           _Balance=balance;
        }

        public void WalletRecharge(double recharge)
        {
            _Balance+=recharge;
            Console.WriteLine(_Balance);
        }

        public void DeductBalance(double deductbalance)
        {
            _Balance-=deductbalance;
            Console.WriteLine(_Balance);
        }
        public CustomerDetails(string str1)
        {
            string[] val=str1.Split(",");
            s_customerID=int.Parse(val[0].Remove(0,3));
           CustomerID=val[0];
           _Balance=double.Parse(val[1]);
           Name=val[2];
           FatherName=val[3];
           Gender=val[4];
           MobNo=val[5];
           DOB=DateTime.ParseExact(val[6],"dd/MM/yyyy",null);
           MailID=val[7];

        }
    }
}