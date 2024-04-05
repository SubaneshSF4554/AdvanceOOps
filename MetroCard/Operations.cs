using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCard
{
    public class Operations
    {
        public static CustomList<UserDetails> userList = new CustomList<UserDetails>();
        static UserDetails currentUser;
        public static CustomList<TravelDetails> travelList = new CustomList<TravelDetails>();
        public static CustomList<TicketFairDetails> ticketList = new CustomList<TicketFairDetails>();
        public static void Default()
        {
            userList.Add(new UserDetails("Ravi", "9898989898", 1000.00));
            userList.Add(new UserDetails("Baskaran", "8776655443", 1000.00));

            travelList.Add(new TravelDetails("CMRL101", "Airport", "Egmore", new DateTime(2022, 10, 10), 55));
            travelList.Add(new TravelDetails("CMRL101", "Egmore", "Koyembedu", new DateTime(2022, 10, 10), 32));
            travelList.Add(new TravelDetails("CMRL102", "Alandur", "Koyembedu", new DateTime(2022, 11, 10), 25));
            travelList.Add(new TravelDetails("CMRL102", "Egmore", "Thirumangalam", new DateTime(2022, 11, 10), 25));

            ticketList.Add(new TicketFairDetails("Airport", "Egmore", 55));
            ticketList.Add(new TicketFairDetails("Airport", "Koyembedu", 25));
            ticketList.Add(new TicketFairDetails("Alandur", "Koyembedu", 25));
            ticketList.Add(new TicketFairDetails("Koyembedu", "Egmore", 32));
            ticketList.Add(new TicketFairDetails("Vadapalani", "Egmore", 45));
            ticketList.Add(new TicketFairDetails("Arumbakkam", "Egmore", 25));
            ticketList.Add(new TicketFairDetails("Vadapalani", "Koyembedu", 25));
            ticketList.Add(new TicketFairDetails("Arumbakkam", "Koyembedu", 16));
        }
        public static void Display()
        {
            foreach (UserDetails user in userList)
            {
                Console.WriteLine($"CardNumber : {user.CardNumber}||UserName : {user.UserName}||Phone : {user.PhoneNum}||balance : {user.Balance}");
            }
            foreach (TravelDetails travel in travelList)
            {
                Console.WriteLine($"Travel ID : {travel.TravelID}||CardNumber : {travel.CardNumber}||FromLocation : {travel.FromLocation}||ToLocation : {travel.ToLoction}||Date : {travel.Date}||TravelCost : {travel.TravelCost}");
            }
            foreach (TicketFairDetails ticket in ticketList)
            {
                Console.WriteLine($"TicketID : {ticket.TicketID}||FromLocation : {ticket.FromLocation}||ToLocation : {ticket.ToLoction}||Fair : {ticket.TicketPrice}");
            }
        }
        public static void MainMenu()
        {
            string option = "yes";
            do
            {
                Console.WriteLine("Choose any below Option : \n1)UserRegistration \n2)LogIn \n3)Exit");
                int opinion = int.Parse(Console.ReadLine());
                switch (opinion)
                {
                    case 1:
                        UserRegistration();
                        break;
                    case 2:
                        LogIn();
                        break;
                    case 3:
                        Console.WriteLine("Exit");
                        option = "no";
                        break;
                    default:
                        Console.WriteLine("Enter a valid input ");
                        break;

                }
            } while (option == "yes");
        }
        public static void UserRegistration()
        {
            Console.Write("Enter the username : ");
            string userName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter the PhoneNumber : ");
            string mobNo = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter the balance : ");
            double balance = double.Parse(Console.ReadLine());
            Console.WriteLine();

            UserDetails user = new UserDetails(userName, mobNo, balance);
            userList.Add(user);
            Console.WriteLine($"Card Number is : {user.CardNumber}");
        }
        public static void LogIn()
        {
            Console.WriteLine("Enter the card number for the validation : ");
            string searchNumber = Console.ReadLine();
            bool flag = false;
            UserDetails user=BinarySearch.Binary(userList,searchNumber);

                if (user!=null)
                {
                    flag = true;
                    Console.WriteLine("Valid Card Number ");
                    currentUser = user;
                    SubMenu();
                }
            
            if (!flag)
            {
                Console.WriteLine("The card number you entered is not a valid one");
            }
        }
        public static void SubMenu()
        {
            string option = "yes";
            do
            {
                Console.WriteLine("Choose any option from the below list : \na)Balance check \nb)Recharge \nc)View travel Histroy \nd)travel \ne)Exit");
                char ch = Convert.ToChar(Console.ReadLine());
                switch (ch)
                {
                    case 'a':
                        ShowBalance();
                        break;
                    case 'b':
                        Console.WriteLine("How much of amount you want to recharge : ");
                        double amount = double.Parse(Console.ReadLine());
                        currentUser.WalletRecharge(amount);
                        break;
                    case 'c':
                        ViewTravelHistory();
                        break;
                    case 'd':
                        Travel();
                        break;
                    case 'e':
                        Console.WriteLine("Exit");
                        option = "no";
                        break;
                    default:
                        Console.WriteLine("Enter a valid input ");
                        break;

                }
            } while (option == "yes");
        }
        public static void ShowBalance()
        {
            Console.WriteLine(currentUser.Balance);
        }
        public static void ViewTravelHistory()
        {
            foreach (TravelDetails travel in travelList)
            {
                if (currentUser.CardNumber.Equals(travel.CardNumber))
                {
                    Console.WriteLine($"Travel ID : {travel.TravelID}||CardNumber : {travel.CardNumber}||FromLocation : {travel.FromLocation}||ToLocation : {travel.ToLoction}||Date : {travel.Date}||TravelCost : {travel.TravelCost}");
                }
            }

        }
        public static void Travel()
        {
            foreach (TicketFairDetails ticket in ticketList)
            {
                Console.WriteLine($"TicketID : {ticket.TicketID}||FromLocation : {ticket.FromLocation}||ToLocation : {ticket.ToLoction}||Fair : {ticket.TicketPrice}");
            }
            Console.WriteLine("Enter the ticket ID : ");
            string ticID = Console.ReadLine();
            bool temp = false;
            bool flag = false;
            TicketFairDetails ticket1=BinarySearch.TicketBinary(ticketList,ticID);         
                
                if (ticket1!=null)
                {
                    double checkBalance = currentUser.Balance;
                    if (checkBalance >= ticket1.TicketPrice)
                    {
                        Console.WriteLine("Yes he has sufficient balance ");
                        flag = true;

                        double deduct = ticket1.TicketPrice;
                        currentUser.DeductBalance(deduct);
                        TravelDetails travel1 = new TravelDetails(currentUser.CardNumber, ticket1.FromLocation, ticket1.ToLoction, DateTime.Now, ticket1.TicketPrice);
                        travelList.Add(travel1);


                    }
                }
                

            

            if (!temp)
            {
                Console.WriteLine("Invalid ID");
            }
            if (!flag)
                {
                    Console.WriteLine("Want to recharge : ");
                    string wish = Console.ReadLine();
                    if (wish == "yes")
                    {
                        Console.WriteLine("How much of amount you want to recharge : ");
                        double amount = double.Parse(Console.ReadLine());
                        currentUser.WalletRecharge(amount);
                    }

                }

        }
    }
}