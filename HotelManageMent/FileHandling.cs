using System;
using System.IO;

namespace HotelManageMent
{
    public class FileHandling
    {
        public static void Create()
        {
            if (!Directory.Exists("HotelFolder"))
            {
                Console.WriteLine("Foldere is created");
                Directory.CreateDirectory("HotelFolder");
            }
            else
            {
                Console.WriteLine("Hotel folder is already exists");
            }

            //userinfo
            if(!File.Exists("HotelFolder/UserInfo.csv"))
            {
                Console.WriteLine("UserInfo file is created");
                File.Create("HotelFolder/UserInfo.csv").Close();
            }
            else
            {
                 Console.WriteLine("UserInfo file is already exists");
            }

             //roominfo
             if(!File.Exists("HotelFolder/RoomInfo.csv"))
            {
                Console.WriteLine("RoomInfo file is created");
                File.Create("HotelFolder/RoomInfo.csv").Close();
            }
            else
            {
                 Console.WriteLine("RoomInfo file is already exists");
            }

             //room selection info
             if(!File.Exists("HotelFolder/RoomSelectionInfo.csv"))
            {
                Console.WriteLine("RoomSelectionInfo file is created");
                File.Create("HotelFolder/RoomSelectionInfo.csv").Close();
            }
            else
            {
                 Console.WriteLine("RoomSelectionInfo file is already exists");
            }
            
              //Booking info
             if(!File.Exists("HotelFolder/BookingInfo.csv"))
            {
                Console.WriteLine("BookingInfo file is created");
                File.Create("HotelFolder/BookingInfo.csv").Close();
            }
            else
            {
                 Console.WriteLine("BookingInfo file is already exists");
            }
        }
        public static void Writecsv()
        {

            //userinfo
            string[] str1=new string[Operation.userList.Count];
            for(int i=0;i<Operation.userList.Count;i++)
            {
                str1[i]=Operation.userList[i].UserID+","+Operation.userList[i].UserName+","+Operation.userList[i].MobileNumber+","+Operation.userList[i].AadharNumber+","+Operation.userList[i].Address+","+Operation.userList[i].FoodType+","+Operation.userList[i].Gender+","+Operation.userList[i].WalletBalance;
            }
            File.WriteAllLines("HotelFolder/UserInfo.csv",str1);

            //Roominfo
            string[] str2=new string[Operation.roomList.Count];
            for(int i=0;i<Operation.roomList.Count;i++)
            {
                str2[i]=Operation.roomList[i].RoomID+","+Operation.roomList[i].RoomType+","+Operation.roomList[i].NumberOfBeds+","+Operation.roomList[i].PricePerDay;
            }
            File.WriteAllLines("HotelFolder/RoomInfo.csv",str2);

            //room selection info
            string[] str3=new string[Operation.selectionList.Count];
            for(int i=0;i<Operation.selectionList.Count;i++)
            {
                str3[i]=Operation.selectionList[i].SelectionID+","+Operation.selectionList[i].BookingID+","+Operation.selectionList[i].RoomID+","+Operation.selectionList[i].StayingDateFrom.ToString("dd/MM/yyyy")+","+Operation.selectionList[i].StayingDateTo.ToString("dd/MM/yyyy")+","+Operation.selectionList[i].Price+","+Operation.selectionList[i].NumberOfDays+","+Operation.selectionList[i].RoomBookingStatus;
            }
            File.WriteAllLines("HotelFolder/RoomSelectionInfo.csv",str3);

            //Booking info
            string[] str4=new string[Operation.bookingList.Count];
            for(int i=0;i<Operation.bookingList.Count;i++)
            {
                str4[i]=Operation.bookingList[i].BookingID+","+Operation.bookingList[i].UserID+","+Operation.bookingList[i].TotalPrice+","+Operation.bookingList[i].DateOfBooking.ToString("dd/MM/yyyy")+","+Operation.bookingList[i].Status;
            }
            File.WriteAllLines("HotelFolder/BookingInfo.csv",str4);
        }

        public static void Readcsv()
        {
            //userinfo
            string[] str1=File.ReadAllLines("HotelFolder/UserInfo.csv");
            foreach(string user in str1)
            {
                UserDetails userObj=new UserDetails(user);
                Operation.userList.Add(userObj);
            }

            //room info
            string[] str2=File.ReadAllLines("HotelFolder/RoomInfo.csv");
            foreach(string room in str2)
            {
                RoomDetails roomObj=new RoomDetails(room);
                Operation.roomList.Add(roomObj);
            }

            //Room selection info
            string[] str3=File.ReadAllLines("HotelFolder/RoomSelectionInfo.csv");
            foreach(string roomSelect in str3)
            {
                RoomSelection selectObj=new RoomSelection(roomSelect);
                Operation.selectionList.Add(selectObj);
            }

            //Booking info
            string[] str4=File.ReadAllLines("HotelFolder/BookingInfo.csv");
            foreach(string booking in str4)
            {
                BookingDetails bookingObj=new BookingDetails(booking);
                Operation.bookingList.Add(bookingObj);
            }
        }
    }
}