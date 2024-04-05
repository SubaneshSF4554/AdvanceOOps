using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManageMent
{
   // public enum BookingStatus{select,Initiated,Booked,Cancelled}
    public class RoomSelection
    {
        private static int s_selectionID=1000;
        public string SelectionID;
        private DateTime date1;
        private DateTime date2;
        private double noOfDays;
        private BookStatus initiated;

        public string BookingID{get;set;}
        public string RoomID{get;set;}
       
        public DateTime StayingDateFrom{get;set;}
        public DateTime StayingDateTo{get;set;}
        public double Price{get;set;}
        public double NumberOfDays{get;set;}
        public BookStatus RoomBookingStatus{get;set;}
        public RoomSelection(string bookingID,string roomID,DateTime stayingDateFrom,DateTime stayingDateTo,double price,double numberOfDays,BookStatus roomStatus)
        {
            s_selectionID++;
            SelectionID="SID"+s_selectionID;
            RoomID=roomID;
            BookingID=bookingID;
            StayingDateFrom=stayingDateFrom;
            StayingDateTo=stayingDateTo;
            Price=price;
            NumberOfDays=numberOfDays;
            RoomBookingStatus=roomStatus;
        }
        public RoomSelection(string roomSelect)
        {
            string[] value=roomSelect.Split(",");
            s_selectionID=int.Parse(value[0].Remove(0,3));
            SelectionID=value[0];
            BookingID=value[1];
            RoomID=value[2];
            StayingDateFrom=DateTime.ParseExact(value[3],"dd/MM/yyyy",null);
            StayingDateTo=DateTime.ParseExact(value[4],"dd/MM/yyyy",null);
            Price=double.Parse(value[5]);
            NumberOfDays=double.Parse(value[6]);
            RoomBookingStatus=Enum.Parse<BookStatus>(value[7],true);
        }

        public RoomSelection(string roomSelect, DateTime date1, DateTime date2, double noOfDays, BookStatus initiated) : this(roomSelect)
        {
            this.date1 = date1;
            this.date2 = date2;
            this.noOfDays = noOfDays;
            this.initiated = initiated;
        }
    }
}