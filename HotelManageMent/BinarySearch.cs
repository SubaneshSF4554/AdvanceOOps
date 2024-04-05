using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManageMent
{
    public class BinarySearch
    {
        public static UserDetails UserBinary(CustomList<UserDetails> custom,string searchID)
        {
            int left=0;
            int right=Operation.userList.Count-1;
            while(left<=right)
            {
                int midd=left+(right-left)/2;
                if(Operation.userList[midd].UserID.CompareTo(searchID)==0)
                {
                    return Operation.userList[midd];
                }
                else if(Operation.userList[midd].UserID.CompareTo(searchID)==-1)
                {
                    left=midd+1;
                }
                else{
                    right=midd-1;
                }
            }
            return null;
        }
    }
}