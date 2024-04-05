using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery
{
    public class ProductDetails
    {
        public static int s_productID=2000;
        public string ProductID;
        public string ProductName{get;set;}
        public int QuantityAvailable{get;set;}
        public int PricePerQuantity{get;set;}
        public ProductDetails(string productName,int quantityAvailable,int priceperQuantity)
        {
            s_productID++;
            ProductID="PID"+s_productID;
            ProductName=productName;
            QuantityAvailable=quantityAvailable;
            PricePerQuantity=priceperQuantity;
        }
        
        public ProductDetails(string str2)
        {
            string[] val=str2.Split(",");
            s_productID=int.Parse(val[0].Remove(0,3));
            ProductID=val[0];
            ProductName=val[1];
            QuantityAvailable=int.Parse(val[2]);
            PricePerQuantity=int.Parse(val[3]);
        }
    }
}