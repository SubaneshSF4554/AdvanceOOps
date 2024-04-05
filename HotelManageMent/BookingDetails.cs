using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManageMent
{
    public enum BookStatus{select,Initiated,Booked,Cancelled}
    public class BookingDetails
    {
        private static int s_bookingID=100;
        public string BookingID;
        public string UserID{get;set;}
        public double TotalPrice{get;set;}
        public DateTime DateOfBooking{get;set;}
        public BookStatus Status{get;set;}
        public BookingDetails(string userID,double totalPrice,DateTime dateOfBooking,BookStatus status)
        {
            s_bookingID++;
            BookingID="BID"+s_bookingID;
            UserID=userID;
            TotalPrice=totalPrice;
            DateOfBooking=dateOfBooking;
            Status=status;
        }
        public BookingDetails(string booking)
        {
            string[] value=booking.Split(",");
            s_bookingID=int.Parse(value[0].Remove(0,3));
            BookingID=value[0];
            UserID=value[1];
            TotalPrice=double.Parse(value[2]);
            DateOfBooking=DateTime.ParseExact(value[3],"dd/MM/yyyy",null);
            Status=Enum.Parse<BookStatus>(value[4],true);
        }

    }
}