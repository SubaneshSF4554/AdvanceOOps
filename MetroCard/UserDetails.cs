using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCard
{
    public class UserDetails:PersonalDetails,IBalance
    {
        public static int _cardNumber=100;
        public string CardNumber{get;set;}
        private double _balance;
        public double Balance{get{return _balance;}}
        public UserDetails(string userName,string mobNo,double balance):base(userName,mobNo)
        {
            _cardNumber++;
            CardNumber="CMRL"+_cardNumber;
            _balance=balance;

        }
        public UserDetails(string user){
            string[] value=user.Split(",");
            _cardNumber=int.Parse(value[0].Remove(0,4));
            CardNumber=value[0];
            UserName=value[1];
            PhoneNum=value[2];
            _balance=double.Parse(value[3]);

        }

        public void DeductBalance(double amount)
        {
            _balance-=amount;
            Console.WriteLine(_balance);

        } 

        public void WalletRecharge(double amount)
        {
            _balance+=amount;
            Console.WriteLine(_balance);
            
        }
    }
}