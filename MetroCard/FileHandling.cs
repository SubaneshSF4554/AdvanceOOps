using System;
using System.IO;

namespace MetroCard
{
    public class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("CardFolder"))
            {
                Console.WriteLine("Folder is created ");
                Directory.CreateDirectory("CardFolder");
            }
            if(!File.Exists("CardFolder/UserInfo.csv"))
            {
                Console.WriteLine("User File is created");
                File.Create("CardFolder/UserInfo.csv").Close();
            }
            if(!File.Exists("CardFolder/TravelInfo.csv"))
            {
                Console.WriteLine("Travel File is created");
                File.Create("CardFolder/TravelInfo.csv").Close();
            }
            if(!File.Exists("CardFolder/TicketInfo.csv"))
            {
                Console.WriteLine("Ticket File is created");
                File.Create("CardFolder/TicketInfo.csv").Close();
            }
            
        }
        public static void Writecsv()
        {
            string[] str1=new string[Operations.userList.Count];
            for(int i=0;i<Operations.userList.Count;i++)
            {
                str1[i]=Operations.userList[i].CardNumber+","+Operations.userList[i].UserName+","+Operations.userList[i].PhoneNum+","+Operations.userList[i].Balance;
            }
            File.WriteAllLines("CardFolder/UserInfo.csv",str1);

            string[] str2=new string[Operations.travelList.Count];
            for(int i=0;i<Operations.travelList.Count;i++)
            {
                str2[i]=Operations.travelList[i].TravelID+","+Operations.travelList[i].CardNumber+","+Operations.travelList[i].FromLocation+","+Operations.travelList[i].ToLoction+","+Operations.travelList[i].Date.ToString("dd/MM/yyyy")+","+Operations.travelList[i].TravelCost;
            }
            File.WriteAllLines("CardFolder/TravelInfo.csv",str2);

            string[] str3=new string[Operations.ticketList.Count];
            for(int i=0;i<Operations.ticketList.Count;i++)
            {
                str3[i]=Operations.ticketList[i].TicketID+","+Operations.ticketList[i].FromLocation+","+Operations.ticketList[i].ToLoction+","+Operations.ticketList[i].TicketPrice;
            }
            File.WriteAllLines("CardFolder/TicketInfo.csv",str3);
        }
        public static void Readcsv()
        {
            string[] str1=File.ReadAllLines("CardFolder/UserInfo.csv");
            foreach(string user in str1)
            {
                UserDetails userObj=new UserDetails(user);
                Operations.userList.Add(userObj); 
            }
            string[] str2=File.ReadAllLines("CardFolder/TravelInfo.csv");
            foreach(string travel in str2)
            {
                TravelDetails travelObj=new TravelDetails(travel);
                Operations.travelList.Add(travelObj);
            }
            string[] str3=File.ReadAllLines("CardFolder/TicketInfo.csv");
            foreach(string ticket in str3)
            {
                TicketFairDetails ticketObj=new TicketFairDetails(ticket);
                Operations.ticketList.Add(ticketObj);
            }
        }
    }
}