using System;
using System.IO;

namespace OnlineGrocery
{
    public class FileHandling
    {
        public static void Create()
        {
        if(!Directory.Exists("StoreDetails")){
            Console.WriteLine("Created the folder");
            Directory.CreateDirectory("StoreDetails");
        }
       
        if(!File.Exists("StoreDetails/customerInfo.csv"))
        {
            Console.WriteLine("product file is created...");
            File.Create("StoreDetails/customerInfo.csv").Close();
        }
        if(!File.Exists("StoreDetails/productInfo.csv"))
        {
            Console.WriteLine("product file is created...");
            File.Create("StoreDetails/productInfo.csv").Close();
        }
        if(!File.Exists("StoreDetails/bookingInfo.csv"))
        {
            Console.WriteLine("booking info file is created...");
            File.Create("StoreDetails/bookingInfo.csv").Close();
        }
         if(!File.Exists("StoreDetails/orderInfo.csv"))
        {
            Console.WriteLine("order file is created...");
            File.Create("StoreDetails/orderInfo.csv").Close();
        }     

        }
        public static void Writecsv()
        {
            //for customer list
            string[] str1=new string[Operations.cutomerList.Count];
            for(int i=0;i<Operations.cutomerList.Count;i++)
            {
                str1[i]=Operations.cutomerList[i].CustomerID+","+Operations.cutomerList[i].Balance+","+Operations.cutomerList[i].Name+","+Operations.cutomerList[i].FatherName+","+Operations.cutomerList[i].Gender+","+Operations.cutomerList[i].MobNo+","+Operations.cutomerList[i].DOB.ToString("dd/MM/yyyy")+","+Operations.cutomerList[i].MailID;

            }
            File.WriteAllLines("StoreDetails/customerInfo.csv",str1);
            //for product
            string[] str2=new string[Operations.productList.Count];
            for(int i=0;i<Operations.productList.Count;i++)
            {
                str2[i]=Operations.productList[i].ProductID+","+Operations.productList[i].ProductName+","+Operations.productList[i].QuantityAvailable+","+Operations.productList[i].PricePerQuantity;

            }
            File.WriteAllLines("StoreDetails/productInfo.csv",str2);
            //for booking
            string[] str3=new string[Operations.bookingList.Count];
            for(int i=0;i<Operations.bookingList.Count;i++)
            {
                str3[i]=Operations.bookingList[i].BookingID+","+Operations.bookingList[i].CustomerID+","+Operations.bookingList[i].TotalPrice+","+Operations.bookingList[i].DateOfBooking.ToString("dd/MM/yyyy")+","+Operations.bookingList[i].Status;
            }
            File.WriteAllLines("StoreDetails/bookingInfo.csv",str3);
            //for order informations
            string[] str4=new string[Operations.orderList.Count];
            for(int i=0;i<Operations.orderList.Count;i++)
            {
               str4[i]=Operations.orderList[i].OrderID+","+Operations.orderList[i].BookingID+","+Operations.orderList[i].ProductID+","+Operations.orderList[i].PurchaseCount+","+Operations.orderList[i].PriceOfOrder;
            }
            File.WriteAllLines("StoreDetails/orderInfo.csv",str4);
        }
        public static void Readcsv()
        {
            string[] customer=File.ReadAllLines("StoreDetails/customerInfo.csv");
            foreach(string str1 in customer)
            {
                CustomerDetails customerObj=new CustomerDetails(str1);
                Operations.cutomerList.Add(customerObj);
            }

            string[] product=File.ReadAllLines("StoreDetails/productInfo.csv");
            foreach(string str2 in product)
            {
                ProductDetails productObj=new ProductDetails(str2);
                Operations.productList.Add(productObj);
            }

            string[] booking=File.ReadAllLines("StoreDetails/bookingInfo.csv");
            foreach(string str3 in booking)
            {
                BookingDetails bookingObj=new BookingDetails(str3);
                Operations.bookingList.Add(bookingObj);
            }

            string[] orders=File.ReadAllLines("StoreDetails/orderInfo.csv");
            foreach(string str4 in orders)
            {
                OrderDetails orderObj=new OrderDetails(str4);
                Operations.orderList.Add(orderObj);
            }
        }
    }
}