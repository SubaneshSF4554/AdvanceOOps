using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManageMent
{
    public class Operation
    {
        //create a list for the relevant classes
        public static CustomList<UserDetails> userList = new CustomList<UserDetails>();
        static UserDetails currentUser;
        public static CustomList<RoomDetails> roomList = new CustomList<RoomDetails>();
        public static CustomList<RoomSelection> selectionList = new CustomList<RoomSelection>();
        static RoomSelection currentSelection;
        public static CustomList<BookingDetails> bookingList = new CustomList<BookingDetails>();
        static BookingDetails currentBooking;

        //default method
        public static void DefaultValues()
        {
            //User details
            userList.Add(new UserDetails("Ravichandran", "995775777", "347777378383", "Chennai", FoodType.Veg, Gender.Male, 5000.00));
            userList.Add(new UserDetails("Baskaran", "448844848", "4747774774477", "Chennai", FoodType.NonVeg, Gender.Male, 6000.00));

            //room details
            roomList.Add(new RoomDetails(RoomType.Standard, 2, 500.00));
            roomList.Add(new RoomDetails(RoomType.Standard, 4, 700.00));
            roomList.Add(new RoomDetails(RoomType.Standard, 2, 500.00));
            roomList.Add(new RoomDetails(RoomType.Standard, 2, 500.00));
            roomList.Add(new RoomDetails(RoomType.Standard, 2, 500.00));
            roomList.Add(new RoomDetails(RoomType.Delux, 2, 1000.00));
            roomList.Add(new RoomDetails(RoomType.Delux, 2, 1000.00));
            roomList.Add(new RoomDetails(RoomType.Delux, 4, 1400.00));
            roomList.Add(new RoomDetails(RoomType.Delux, 4, 1400.00));
            roomList.Add(new RoomDetails(RoomType.Suit, 2, 2000.00));
            roomList.Add(new RoomDetails(RoomType.Suit, 2, 2000.00));
            roomList.Add(new RoomDetails(RoomType.Suit, 2, 2000.00));
            roomList.Add(new RoomDetails(RoomType.Suit, 4, 2000.00));

            //room selection
            selectionList.Add(new RoomSelection("BID101", "RID101", new DateTime(2022, 11, 11, 06, 00, 00), new DateTime(2022, 11, 12, 2, 00, 00), 750.00, 1.5, BookStatus.Booked));
            selectionList.Add(new RoomSelection("BID101", "RID102", new DateTime(2022, 11, 11, 10, 00, 00), new DateTime(2022, 11, 12, 9, 00, 00), 700.00, 1.0, BookStatus.Booked));
            selectionList.Add(new RoomSelection("BID102", "RID103", new DateTime(2022, 11, 12, 9, 00, 00), new DateTime(2022, 11, 13, 09, 00, 00), 500.00, 1.0, BookStatus.Cancelled));
            selectionList.Add(new RoomSelection("BID102", "RID106", new DateTime(2022, 11, 12, 06, 00, 00), new DateTime(2022, 11, 13, 12, 30, 00), 1500.00, 1.5, BookStatus.Cancelled));

            //bookingdetails
            bookingList.Add(new BookingDetails("SF1001", 1450.00, new DateTime(2022, 11, 10), BookStatus.Booked));
            bookingList.Add(new BookingDetails("SF1002", 2000.00, new DateTime(2022, 11, 10), BookStatus.Cancelled));
        }

        //Display method
        public static void Display()
        {
            //user
            foreach (UserDetails user in userList)
            {
                Console.WriteLine($"UserID : {user.UserID}||UserName : {user.UserName}||MobileNumber : {user.MobileNumber}AadharNumber : {user.AadharNumber}||Address : {user.Address}||FoodType :{user.FoodType}||Gender : {user.Gender}||WalletBalance : {user.WalletBalance}");
            }
            Console.WriteLine();

            //Roomdetails
            foreach (RoomDetails room in roomList)
            {
                Console.WriteLine($"RoomID : {room.RoomID}||RoomType : {room.RoomType}||Numberofbeds : {room.NumberOfBeds}||PricePerDay : {room.PricePerDay}");
            }
            Console.WriteLine();

            //Room selection
            foreach (RoomSelection roomselect in selectionList)
            {
                Console.WriteLine($"Selection ID : {roomselect.SelectionID}||BookingID : {roomselect.BookingID}||RoomID : {roomselect.RoomID}||StayingDateFrom : {roomselect.StayingDateFrom.ToString("dd/MM/yyyy hh:mm:ss")}||StayingDateTo : {roomselect.StayingDateTo.ToString("dd/MM/yyyy hh:mm:ss")}||Price : {roomselect.Price}||NumberOfdays : {roomselect.NumberOfDays}||BookingStatus : {roomselect.RoomBookingStatus}");
            }
            Console.WriteLine();


            foreach (BookingDetails booking in bookingList)
            {
                Console.WriteLine($"BookingID : {booking.BookingID}||UserID : {booking.UserID}||TotalPrice : {booking.TotalPrice}||DateOfBooking : {booking.DateOfBooking.ToString("dd/MM/yyyy")}||BookingStatus : {booking.Status}");
            }
            Console.WriteLine();

        }
        public static void MainMenu()
        {
            string option = "yes";
            do
            {
                Console.WriteLine("--------------------MainMenu------------------");
                Console.WriteLine("Choose any one option from the list : \n1)UserRegistration \n2)LogIn \n3)Exit");
                int selectNumber = int.Parse(Console.ReadLine());
                switch (selectNumber)
                {
                    case 1:
                        UserRegistration();
                        break;
                    case 2:
                        LogIn();
                        break;
                    case 3:
                        Console.WriteLine("Exit ....Thank you for visiting");
                        option = "no";
                        break;
                    default:
                        Console.WriteLine("Enter a valid input");
                        break;

                }

            } while (option == "yes");
        }

        public static void UserRegistration()
        {
            Console.Write("Enter the user name : ");
            string userName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter the mobile number : ");
            string mobileNum = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter the aadhar Number : ");
            string aadharNum = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Address of the user : ");
            string address = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter the type of food : ");
            FoodType foodType = Enum.Parse<FoodType>(Console.ReadLine(), true);
            Console.WriteLine();

            Console.Write("Enter the gender of the user : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.WriteLine();

            Console.Write("Enter the balance amount : ");
            double balance = double.Parse(Console.ReadLine());
            Console.WriteLine();

            UserDetails user = new UserDetails(userName, mobileNum, aadharNum, address, foodType, gender, balance);
            userList.Add(user);

            Console.WriteLine($"UserID is : {user.UserID}");
        }
        public static void LogIn()
        {
            Console.WriteLine("Enter the user ID for Login : ");
            string searchLoginID = Console.ReadLine();
            UserDetails users = BinarySearch.UserBinary(userList, searchLoginID);

            if (users != null)
            {
                Console.WriteLine("ValidUserID");
                currentUser = users;
                SubMenu();
            }
            else
            {
                Console.WriteLine("Invalid User ID");
            }


        }
        public static void SubMenu()
        {
            string option = "yes";
            do
            {
                Console.WriteLine("--------------------Welcome to submenu----------------");
                Console.WriteLine("Choose any Option : \na)View Customer Profile \nb)Book Room \nc)Modify booking \nd)Cancel booking \ne)Booking history \nf)Wallet recharge \ng)show walletbalance \nh)Exit");
                char chSelect = Convert.ToChar(Console.ReadLine());
                switch (chSelect)
                {
                    case 'a':
                        ViewCustomerProfile();
                        break;
                    case 'b':
                        BookRoom();
                        break;
                    case 'c':
                        ModifyBooking();
                        break;
                    case 'd':
                        CancelBooking();
                        break;
                    case 'e':
                        BookingHistory();
                        break;
                    case 'f':
                        Console.WriteLine("How much of amount you want to recharge : ");
                        double rechargeAmount = double.Parse(Console.ReadLine());
                        currentUser.WalletRecharge(rechargeAmount);
                        break;
                    case 'g':
                        Showbalance();
                        break;
                    case 'h':
                        Console.WriteLine("Exit");
                        option = "no";
                        break;
                    default:
                        Console.WriteLine("Enter a valid input ");
                        break;

                }
            } while (option == "yes");
        }
        public static void ViewCustomerProfile()
        {
            foreach (UserDetails user in userList)
            {
                if (currentUser.UserID.Equals(user.UserID))
                {
                    Console.WriteLine($"UserID : {user.UserID}\nUserName : {user.UserName}\nMobileNumber : {user.MobileNumber}\nAadharNumber : {user.AadharNumber}\nAddress : {user.Address}\nFoodType :{user.FoodType}\nGender : {user.Gender}\nWalletBalance : {user.WalletBalance}");
                }
            }

        }
        public static void BookRoom()
        {
            double totalPrice = 0;
            //create a temporary object for bookings
            BookingDetails tempBookingObj = new BookingDetails(currentUser.UserID, totalPrice, DateTime.Now, BookStatus.Initiated);
            //create a temporary list for selection for booking completion
            List<RoomSelection> tempSelectionList = new List<RoomSelection>();
            //show the list of available roomtypes
            //traverse roomsdetail
            foreach (RoomDetails room in roomList)
            {
                Console.WriteLine($"RoomID : {room.RoomID}||RoomType : {room.RoomType}||Numberofbeds : {room.NumberOfBeds}||PricePerDay : {room.PricePerDay}");
            }
            //ask stay and releave date and time 
            Console.WriteLine("Enter the Staying from date : ");
            DateTime date1 = DateTime.ParseExact(Console.ReadLine(), ("dd/MM/yyyy hh:mm:ss"), null);
            Console.WriteLine("Enter the Staying To date : ");
            DateTime date2 = DateTime.ParseExact(Console.ReadLine(), ("dd/MM/yyyy hh:mm:ss"), null);
            //ask userid and no.of days
            Console.WriteLine("Enter the RoomID for validation : ");
            string searchRoomID = Console.ReadLine();
            Console.WriteLine("No of days staying : ");
            double noOfDays = double.Parse(Console.ReadLine());
            bool temp = false;
            foreach (RoomSelection select in selectionList)
            {
                if (select.RoomID.Equals(searchRoomID) && select.RoomBookingStatus == BookStatus.Initiated)
                {
                    RoomSelection roomObj = new RoomSelection(select.RoomID, date1, date2, noOfDays, BookStatus.Initiated);
                    tempSelectionList.Add(roomObj);
                    temp = true;
                }
            }
            if (!temp)
            {
                Console.WriteLine("Unavailable room ");
            }
            string userWish;
            do
            {
                foreach (RoomDetails room in roomList)
                {
                    Console.WriteLine($"RoomID : {room.RoomID}||RoomType : {room.RoomType}||Numberofbeds : {room.NumberOfBeds}||PricePerDay : {room.PricePerDay}");
                }
                //ask stay and releave date and time 
                Console.WriteLine("Enter the Staying from date : ");
                DateTime date11 = DateTime.ParseExact(Console.ReadLine(), ("dd/MM/yyyy hh:mm:ss"), null);
                Console.WriteLine("Enter the Staying To date : ");
                DateTime date22 = DateTime.ParseExact(Console.ReadLine(), ("dd/MM/yyyy hh:mm:ss"), null);
                //ask userid and no.of days
                Console.WriteLine("Enter the RoomID for validation : ");
                string searchRoomID2 = Console.ReadLine();
                Console.WriteLine("No of days staying : ");
                double noOfDays1 = double.Parse(Console.ReadLine());
                bool flag = false;
                foreach (RoomSelection select in selectionList)
                {
                    if (select.RoomID.Equals(searchRoomID2) && select.RoomBookingStatus == BookStatus.Initiated)
                    {
                        currentSelection = select;
                        RoomSelection roomObj = new RoomSelection(select.RoomID, date11, date22, noOfDays1, BookStatus.Initiated);
                        tempSelectionList.Add(roomObj);
                        flag = true;
                    }
                }
                if (!flag)
                {
                    Console.WriteLine("Unavailable room");
                }
                Console.WriteLine("Are you want to book another room : ");
                userWish = Console.ReadLine().ToLower();

            } while (userWish == "yes");
            //check the user has enough balance
            if (currentUser.WalletBalance >= currentSelection.Price)
            {
                Console.WriteLine("User have sufficient balance");
                bookingList.Add(tempBookingObj);
                Console.WriteLine("Room successfully booked...");
                Console.WriteLine($"Your booking ID is : BID101");
            }
            else
            {
                Console.WriteLine("Are you want to recharge ...?? : ");
                string ans = Console.ReadLine().ToLower();
                if (ans == "yes")
                {
                    Console.WriteLine("How much of amount you want to recharge : ");
                    double amount = double.Parse(Console.ReadLine());
                    currentUser.WalletRecharge(amount);
                }

            }


        }
        public static void ModifyBooking()
        {
            bool flag=true;
            foreach(BookingDetails books in bookingList)
            {
                if(currentUser.UserID.Equals(books.UserID))
                {
                    flag=false;
                    Console.WriteLine("valid User ID");
                    Console.WriteLine("Enter the booking ID for validating : ");
                    string validateID=Console.ReadLine();
                    
                    if(validateID.Equals(books.BookingID)&&books.Status==BookStatus.Booked)
                    {
                          Console.WriteLine("Validating ID");
                          foreach(RoomSelection select in selectionList)
                          {
                            if(select.BookingID.Equals(books.BookingID)&&select.RoomBookingStatus==BookStatus.Booked)
                            {
                                 //Console.WriteLine("Success");
                                 Console.WriteLine($"Selection ID : {select.SelectionID}||BookingID : {select.BookingID}||RoomID : {select.RoomID}||StayingDateFrom : {select.StayingDateFrom.ToString("dd/MM/yyyy hh:mm:ss")}||StayingDateTo : {select.StayingDateTo.ToString("dd/MM/yyyy hh:mm:ss")}||Price : {select.Price}||NumberOfdays : {select.NumberOfDays}||BookingStatus : {select.RoomBookingStatus}");
                                 Console.WriteLine("Enter the selection id for validation : ");
                                 string selectID=Console.ReadLine();
                                 if(selectID.Equals(select.SelectionID))
                                 {
                                       Console.WriteLine("Choose any one : \n1)Cancel selected room \n2)Add new room");
                                       int selectNum=int.Parse(Console.ReadLine());
                                       switch(selectNum)
                                       {
                                        case 1:
                                            currentUser.WalletRecharge(select.Price);
                                            select.RoomBookingStatus=BookStatus.Cancelled;
                                            Console.WriteLine("Selected Room Cancelled from your booking");
                                            break;
                                        case 2:
                                            
                                            break;
                                        default:
                                           Console.WriteLine("Enter a valid Input");
                                           break;
                                       }
                                 }
                            }
                            
                          }
                    }
                    else{
                        Console.WriteLine("Invalid booking ID");
                    }
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid User ID");
            }

        }
        public static void CancelBooking()
        {
            //current users booking
            bool temp = true;
            foreach (BookingDetails bookings in bookingList)
            {
                if (currentUser.UserID.Equals(bookings.UserID) && bookings.Status == BookStatus.Booked)
                {
                    //ask user booking id
                    Console.WriteLine("Enter the booking ID for validation : ");
                    string searchBookingID = Console.ReadLine();

                    if (searchBookingID.Equals(bookings.BookingID))
                    {
                        bookings.Status = BookStatus.Cancelled;
                        temp = false;
                        currentUser.WalletRecharge(bookings.TotalPrice);
                        Console.WriteLine("Booking cancelled successfully");
                    }
                    if (temp)
                    {
                        Console.WriteLine("Invalid book ID");
                    }

                }
            }

        }
        public static void BookingHistory()
        {
            bool temp = false;
            foreach (BookingDetails booking in bookingList)
            {
                if (currentUser.UserID.Equals(booking.UserID))
                {
                    Console.WriteLine("Valid User");
                    temp = true;
                    Console.WriteLine("Enter the booking ID : ");
                    string bookIDSearch = Console.ReadLine();
                    bool flag = false;
                    foreach (RoomSelection select in selectionList)
                    {
                        if (bookIDSearch.Equals(select.BookingID))
                        {
                            Console.WriteLine("Valid book ID");
                            flag = true;
                            Console.WriteLine($"selectionID : {select.SelectionID}||Booking Id : {select.BookingID}||RoomID : {select.RoomID}||Staying date from : {select.StayingDateFrom.ToString("dd/MM/yyyy")}||stayingDateto : {select.StayingDateTo.ToString("dd/MM/yyyy")}||price : {select.Price}||NumberOfDays : {select.NumberOfDays}||BookingStatus : {select.RoomBookingStatus}");
                        }
                        if (!flag)
                        {
                            Console.WriteLine("Invalid booking ID");
                        }
                    }

                }
            }
            if (!temp)
            {
                Console.WriteLine("Invalid user");
            }



        }
        public static void Showbalance()
        {
            Console.WriteLine(currentUser.WalletBalance);
        }
        


    }
}