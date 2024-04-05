using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManageMent
{
    public enum RoomType{select,Standard,Delux,Suit}
    public class RoomDetails
    {
        private static int s_roomID=100;
        public string RoomID;
        public RoomType RoomType{get;set;}
        public int NumberOfBeds{get;set;}
        public double PricePerDay{get;set;}
        public RoomDetails(RoomType roomType,int numberOfBeds,double pricePerDay)
        {
            s_roomID++;
            RoomID="RID"+s_roomID;
            RoomType=roomType;
            NumberOfBeds=numberOfBeds;
            PricePerDay=pricePerDay;
            
        }
        public RoomDetails(string room)
        {
            string[] value=room.Split(",");
            s_roomID=int.Parse(value[0].Remove(0,3));
            RoomID=value[0];
            RoomType=Enum.Parse<RoomType>(value[1],true);
            NumberOfBeds=int.Parse(value[2]);
            PricePerDay=double.Parse(value[3]);
            
        }

    }
}