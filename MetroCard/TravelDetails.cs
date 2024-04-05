using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCard
{
    public class TravelDetails
    {
        public static int s_travelID=100;
        public string TravelID;
        public string CardNumber{get;set;}
        public string FromLocation{get;set;}
        public string ToLoction{get;set;}
        public DateTime Date{get;set;}
        public int TravelCost{get;set;}
        public TravelDetails(string cardNumber,string fromLocation,string toLocation,DateTime date,int travelCost)
        {
            s_travelID++;
            TravelID="TID"+s_travelID;
            CardNumber=cardNumber;
            FromLocation=fromLocation;
            ToLoction=toLocation;
            Date=date;
            TravelCost=travelCost;
        }
        public TravelDetails(string travel)
        {
            string[] value=travel.Split(",");
            s_travelID=int.Parse(value[0].Remove(0,3));
            TravelID=value[0];
            CardNumber=value[1];
            FromLocation=value[2];
            ToLoction=value[3];
            Date=DateTime.ParseExact(value[4],"dd/MM/yyyy",null);
            TravelCost=int.Parse(value[5]);
        }
    }
}