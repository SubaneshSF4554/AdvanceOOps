using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCard
{
    public class TicketFairDetails
    {
        public static int s_ticketID=100;
        public string TicketID;
        public string FromLocation{get;set;}
        public string ToLoction{get;set;}
        public int TicketPrice{get;set;}
        public TicketFairDetails(string fromLocation,string toLocation,int ticketPrice)
        {
            s_ticketID++;
            TicketID="MR"+s_ticketID;
            FromLocation=fromLocation;
            ToLoction=toLocation;
            TicketPrice=ticketPrice;
        }
        public TicketFairDetails(string ticket)
        {
            string[] value=ticket.Split(",");
            s_ticketID=int.Parse(value[0].Remove(0,2));
            TicketID=value[0];
            FromLocation=value[1];
            ToLoction=value[2];
            TicketPrice=int.Parse(value[3]);
        }
    }
}