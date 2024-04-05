using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery
{
    public class BinarySearch
    {
        public static CustomerDetails Binary(CustomList<CustomerDetails> custom,string serachID)
        {
            int left=0;
            int right=Operations.cutomerList.Count-1;
            while(left<=right)
            {
                int mid=left+(right-left)/2;
                if(Operations.cutomerList[mid].CustomerID.CompareTo(serachID)==0)
                {

                    return Operations.cutomerList[mid];
                }
                else if(Operations.cutomerList[mid].CustomerID.CompareTo(serachID)==-1) 
                {
                    left=mid+1;
                }
                else{
                    right=mid-1;
                }
            }
            return null;
        }
    }
}