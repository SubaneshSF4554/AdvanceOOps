using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery
{
    public enum BookingStatus{Default,Initiated,Booked,Cancelled}
    public class BookingDetails
    {
        public static int s_bookingID=3000;
        public string BookingID;
        public string CustomerID{get;set;}
        public double TotalPrice{get;set;}
        public DateTime DateOfBooking{get;set;}
        public BookingStatus Status{get;set;}
        public BookingDetails(string customerID,int totalPrice,DateTime dateOfBooking,BookingStatus status)
        {
            s_bookingID++;
            BookingID="BID"+s_bookingID;
            CustomerID=customerID;
            TotalPrice=totalPrice;
            DateOfBooking=dateOfBooking;
            Status=status;
            
        }
         public BookingDetails(string str3)
        {
            string[] values=str3.Split(",");
            s_bookingID=int.Parse(values[0].Remove(0,3));
            BookingID=values[0];
            CustomerID=values[1];
            TotalPrice=int.Parse(values[2]);
            DateOfBooking=DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            Status=Enum.Parse<BookingStatus>(values[4],true);
            
        }
        public BookingDetails(string customerID,double totalPrice,BookingStatus status)
        {
            CustomerID=customerID;
            TotalPrice=totalPrice;
            Status=status;
        }

    }
}