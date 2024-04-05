using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCard
{
    public interface IBalance
    {
        public static int _balance;
        public void WalletRecharge(double amount);
        public void DeductBalance(double amount);
        
    }
}