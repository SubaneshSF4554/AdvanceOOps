using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery
{
    public class OrderDetails
    {
        public static int s_orderID=4000;
        public string OrderID;
        public string BookingID{get;set;}
        public string ProductID{get;set;}
        public int PurchaseCount{get;set;}
        public double PriceOfOrder{get;set;}
        public OrderDetails()
        {
            
        }
        public OrderDetails(string bookingID,string productID,int purchaseCount,int priceOfOrder)
        {
            s_orderID++;
            OrderID="OID"+s_orderID;
            BookingID=bookingID;
            ProductID=productID;
            PurchaseCount=purchaseCount;
            PriceOfOrder=priceOfOrder;
        }
         public OrderDetails(string str4)
        {
            string[] val=str4.Split(",");
            s_orderID=int.Parse(val[0].Remove(0,3));
            OrderID=val[0];
            BookingID=val[1];
            ProductID=val[2];
            PurchaseCount=int.Parse(val[3]);
            PriceOfOrder=int.Parse(val[4]);
        }
    }
}