using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery
{
    public interface IBalance
    {
        
        public double Balance{get;}
        public void WalletRecharge(double recharge);
        public void DeductBalance(double deductbalance);
    }
}