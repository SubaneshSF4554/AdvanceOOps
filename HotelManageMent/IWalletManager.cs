using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManageMent
{
    public interface IWalletManager
    {
        double WalletBalance{get;}
        void WalletRecharge(double amount);
        void DeductBalance(double amount);
    }
}