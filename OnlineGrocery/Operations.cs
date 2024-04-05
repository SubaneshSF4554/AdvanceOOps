using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OnlineGrocery
{
    public class Operations
    {
        public static CustomList<CustomerDetails> cutomerList = new CustomList<CustomerDetails>();
        static CustomerDetails currentCustomer;
        public static CustomList<ProductDetails> productList = new CustomList<ProductDetails>();
        public static CustomList<BookingDetails> bookingList = new CustomList<BookingDetails>();
        public static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();


        public static void DefaultValues()
        {
            cutomerList.Add(new CustomerDetails(10000.00, "Ravi", "Ettapparajan", "Male", "9747746467", new DateTime(1999, 11, 11), "ravi@gmail.com"));
            cutomerList.Add(new CustomerDetails(15000, "Baskaran", "Sethurajan", "Male", "8475757577", new DateTime(1999, 11, 11), "baskaran@gmail.com"));

            productList.Add(new ProductDetails("Sugar", 20, 40));
            productList.Add(new ProductDetails("Rice", 100, 50));
            productList.Add(new ProductDetails("Milk", 10, 40));
            productList.Add(new ProductDetails("Coffee", 10, 10));
            productList.Add(new ProductDetails("Tea", 10, 10));
            productList.Add(new ProductDetails("MasalaPowder", 10, 20));
            productList.Add(new ProductDetails("Salt", 10, 10));
            productList.Add(new ProductDetails("TurmericPowder", 10, 25));
            productList.Add(new ProductDetails("ChilliPowder", 10, 20));
            productList.Add(new ProductDetails("GroundnutOil", 10, 140));

            bookingList.Add(new BookingDetails("CID1001", 220, new DateTime(2022, 07, 26), BookingStatus.Booked));
            bookingList.Add(new BookingDetails("CID1002", 400, new DateTime(2022, 07, 26), BookingStatus.Booked));
            bookingList.Add(new BookingDetails("CID1001", 280, new DateTime(2022, 07, 26), BookingStatus.Cancelled));
            bookingList.Add(new BookingDetails("CID1002", 0, new DateTime(2022, 07, 26), BookingStatus.Initiated));

            orderList.Add(new OrderDetails("BID3001", "PID2001", 2, 80));
            orderList.Add(new OrderDetails("BID3001", "PID2002", 2, 100));
            orderList.Add(new OrderDetails("BID3001", "PID2003", 1, 40));
            orderList.Add(new OrderDetails("BID3002", "PID2001", 1, 40));
            orderList.Add(new OrderDetails("BID3002", "PID2002", 4, 200));
            orderList.Add(new OrderDetails("BID3002", "PID2010", 1, 140));
            orderList.Add(new OrderDetails("BID3002", "PID2009", 1, 20));
            orderList.Add(new OrderDetails("BID3003", "PID2002", 2, 100));
            orderList.Add(new OrderDetails("BID3003", "PID2008", 4, 100));
            orderList.Add(new OrderDetails("BID3003", "PID2001", 2, 80));
        }
        public static void Display()
        {
            //for customer
            foreach (CustomerDetails customer in cutomerList)
            {
                Console.WriteLine($"Customer id : {customer.CustomerID}\nWalletBalance : {customer.Balance}\nName : {customer.Name}\nFatherNAme : {customer.FatherName}\nGender : {customer.Gender}\nMobileNumber : {customer.MobNo}\nDateOfBirth : {customer.DOB.ToString("dd/MM/yyyy")}\nMailID : {customer.MailID}\n");
            }
            //for product
            foreach (ProductDetails product in productList)
            {
                Console.WriteLine($"ProductID : {product.ProductID}\nProductName : {product.ProductName}\nQuantityavailable : {product.QuantityAvailable}\nPricePerQuantity : {product.PricePerQuantity}\n");
            }
            //for Booking details
            foreach (BookingDetails booking in bookingList)
            {
                Console.WriteLine($"Booking ID : {booking.BookingID}\nCustomer ID : {booking.CustomerID}\nTotal Price : {booking.TotalPrice}\nDateOfBooking : {booking.DateOfBooking.ToString("dd/MM/yyyy")}\nBooking status : {booking.Status}\n");
            }
            //for Order
            foreach (OrderDetails order in orderList)
            {
                Console.WriteLine($"Order ID : {order.OrderID}\nBooking ID : {order.BookingID}\nProductID : {order.ProductID}\nPurchaseCount : {order.PurchaseCount}\nPriceOfOrder : {order.PriceOfOrder}\n");
            }
        }
        public static void MainMenu()
        {
            string option;
            do
            {
                Console.WriteLine("Choose any one option :\n1)Customer registration\n2)Customer LogIn\n3)Exit");
                int opinion = int.Parse(Console.ReadLine());
                switch (opinion)
                {
                    case 1:
                        CustomerRegistration();
                        break;
                    case 2:
                        CustomerLogIn();
                        break;
                    case 3:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Enter the valid number ");
                        break;
                }
                Console.WriteLine("If you want to again access the menu : ");
                option = Console.ReadLine().ToLower();
            } while (option == "yes");
        }

        public static void CustomerRegistration()
        {
            Console.Write("Enter the wallet Balance : ");
            double balance = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Enter the name of the customer : ");
            string name = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter the customers father name : ");
            string fathername = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter the gender of the customer : ");
            string gender = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter the mobile number of the customer : ");
            string mobNum = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter the date of birth of the customer : ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.WriteLine();

            Console.Write("Enter the mailID of the customer : ");
            string mailID = Console.ReadLine();
            Console.WriteLine();

            CustomerDetails customer = new CustomerDetails(balance, name, fathername, gender, mobNum, dob, mailID);
            cutomerList.Add(customer);
            Console.Write($"Customer ID of the Customer is : {customer.CustomerID}");
            Console.WriteLine();
        }
        public static void CustomerLogIn()
        {
            Console.WriteLine("Enter the Customer id for checking : ");
            string custID = Console.ReadLine();
            bool flag = false;
            CustomerDetails customer =BinarySearch.Binary(cutomerList,custID);
                if (customer!=null)
                {
                    flag = true;
                    currentCustomer = customer;
                    SubMenu();
                }
            
            
            if (!flag)
            {
                Console.WriteLine("Enter the valid ID");
            }

        }
        public static void SubMenu()
        {
            string opinion;
            do
            {
                Console.WriteLine("Choose any one option from the below list : \na)Show customer details\nb)show product details\nc)Wallet recharge\nd)Take order\ne)Modify order quantity\nf)Cancel order\ng)Order history\nh)show balance\ni)Exit");
                char ch = Convert.ToChar(Console.ReadLine());
                switch (ch)
                {
                    case 'a':
                        ShowCustomerDetails();
                        break;
                    case 'b':
                        ShowProductDetails();
                        break;
                    case 'c':
                        Console.WriteLine("How much of amount you will recharged : ");
                        double amount = double.Parse(Console.ReadLine());
                        currentCustomer.WalletRecharge(amount);
                        break;
                    case 'd':
                        TakeOrder();
                        break;
                    case 'e':
                        ModifyOrderQuantity();
                        break;
                    case 'f':
                        CancelOrder();
                        break;
                    case 'g':
                        OrderHistory();
                        break;
                    case 'h':
                        Console.WriteLine(currentCustomer.Balance);
                        break;
                    case 'i':
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Enter a valid input ");
                        break;
                }
                Console.WriteLine("You want to again access the submenu : ");
                opinion = Console.ReadLine().ToLower();
            } while (opinion == "yes");
        }
        public static void ShowCustomerDetails()
        {
            foreach (CustomerDetails customer in cutomerList)
            {
                if (currentCustomer.CustomerID.Equals(customer.CustomerID))
                {
                    Console.WriteLine($"Customer id : {customer.CustomerID}\nbalance : {customer.Balance}\nName : {customer.Name}\nFatherName : {customer.FatherName}\nGender : {customer.Gender}\nMobno : {customer.MobNo}\nDoB : {customer.DOB.ToString("dd/MM/yyyy")}\nEmailID : {customer.MailID}");
                }
            }
        }
        public static void ShowProductDetails()
        {
            foreach (ProductDetails product in productList)
            {
                Console.WriteLine($"ProductID : {product.ProductID}\nProductName : {product.ProductName}\nQuantityavailable : {product.QuantityAvailable}\nPricePerQuantity : {product.PricePerQuantity}\n");
            }
        }

        public static void TakeOrder()
        {
            //ask user to purchase or not
            Console.WriteLine("ask He want to purchase ..?");
            string ans = Console.ReadLine().ToLower();
            double totalAmount = 0;
            if (ans == "yes")
            {

                BookingDetails bookObj = new BookingDetails(currentCustomer.CustomerID, totalAmount, BookingStatus.Initiated);
                List<OrderDetails> tempOrderList = new List<OrderDetails>();
                ShowProductDetails();
                Console.WriteLine("Select any product ID : ");
                string pID = Console.ReadLine();
                bool temp = false;
                foreach (ProductDetails product in productList)
                {
                    if (pID.Equals(product.ProductID))
                    {
                       // Console.WriteLine(pID + " " + product.ProductID);
                        temp = true;
                        Console.WriteLine("Ask the purchase quantity to the user : ");
                        int quantity = int.Parse(Console.ReadLine());
                        if (quantity <= product.QuantityAvailable)
                        {
                            OrderDetails orderObj = new OrderDetails(bookObj.BookingID, product.ProductID, quantity, product.PricePerQuantity);
                            tempOrderList.Add(orderObj);
                            int purchasecount = quantity;
                            totalAmount = quantity * product.PricePerQuantity;
                            currentCustomer.DeductBalance(totalAmount);
                            ShowBalance();
                            Console.WriteLine("Product successfully added to the cart");
                            // break;


                        }
                        string answer = "", answer1 = "";
                        do
                        {
                            Console.WriteLine("DO you want to purchase another product : ");
                            answer = Console.ReadLine();
                            if (answer == "yes")
                            {
                                ShowProductDetails();
                                Console.WriteLine("Select any product ID : ");
                                string prID = Console.ReadLine();
                                bool temp1 = false;
                                foreach (ProductDetails product1 in productList)
                                {
                                    if (pID.Equals(product.ProductID))
                                    {
                                        temp1 = true;
                                        Console.WriteLine("Ask the purchase quantity to the user : ");
                                        int quantity1 = int.Parse(Console.ReadLine());
                                        if (quantity1 <= product.QuantityAvailable)
                                        {
                                            OrderDetails orderObj = new OrderDetails(bookObj.BookingID, product.ProductID, quantity, product.PricePerQuantity);
                                            tempOrderList.Add(orderObj);
                                            int purchasecount = quantity;
                                            totalAmount = quantity * product.PricePerQuantity;
                                            currentCustomer.DeductBalance(totalAmount);
                                            ShowBalance();
                                            Console.WriteLine("Product successfully added to the cart");
                                            break;

                                        }
                                    }
                                }
                            }

                        } while (answer == "yes");



                        if (!temp)
                        {
                            Console.WriteLine("Invalid product ID");
                        }

                        Console.WriteLine("Do you want to confrim the order ??");
                        string inp = Console.ReadLine().ToLower();
                        if (inp == "yes")
                        {
                            if (currentCustomer.Balance > totalAmount)
                            {
                                Console.WriteLine("Yes he has balance");
                                double remainingBalance = currentCustomer.Balance - totalAmount;


                            }
                            else
                            {
                                Console.WriteLine("Insufficient account balance");
                                Console.WriteLine("Enter the amount for recharge");
                                double rs = double.Parse(Console.ReadLine());


                                currentCustomer.WalletRecharge(rs);
                            }

                        }

                    }
                }
            }
        }


        public static void ModifyOrderQuantity()
        {
            bool temp = false;
            foreach (BookingDetails book12 in bookingList)
            {
                if (currentCustomer.CustomerID.Equals(book12.CustomerID) && book12.Status == BookingStatus.Booked)
                {
                    Console.WriteLine($"Customer id : {book12.CustomerID} || Totalprice : {book12.TotalPrice} || DateOfBooking : {book12.DateOfBooking} || Bookingstatus : {book12.Status}");
                    temp = true;
                }
            
                if (temp)
                {
                    bool temp1=false;
                    Console.WriteLine("Enter any order id : ");
                    string searchID = Console.ReadLine();
                    foreach(OrderDetails orders1 in orderList)
                    {
                        if(searchID.Equals(orders1.OrderID))
                        {
                            temp1=true;
                            Console.WriteLine(searchID+"    "+orders1.OrderID);
                            Console.WriteLine($"Booking ID : {orders1.BookingID}|| productID : {orders1.ProductID}||purchase count : {orders1.PurchaseCount}||Price of order : {orders1.PriceOfOrder}");
                            
                        }
                        if(temp1)
                        {
                            Console.WriteLine("Enter the new quantity of the product : ");
                            int newQuantity=int.Parse(Console.ReadLine());
                            double total=newQuantity*orders1.PriceOfOrder;
                            book12.TotalPrice=newQuantity;
                            Console.WriteLine("Order modified successfully");
                            break;
                        }
                        break;

                    }

                
            }
            break;
            }
        }
        public static void CancelOrder()
        {
            foreach (BookingDetails bookings in bookingList)
            {
                if (currentCustomer.CustomerID.Equals(bookings.CustomerID) && bookings.Status == BookingStatus.Booked)
                {
                    Console.WriteLine("User to pic the Booking id : ");
                    string bookIDsearch = Console.ReadLine();
                    if (bookIDsearch.Equals(bookings.BookingID))
                    {
                        bookings.Status = BookingStatus.Cancelled;

                        double refund = currentCustomer.Balance + bookings.TotalPrice;
                        currentCustomer.WalletRecharge(refund);
                        ShowBalance();
                        OrderDetails obj = new OrderDetails();
                        obj.PurchaseCount++;
                        Console.WriteLine("Sucessfully cancelled");
                        break;


                    }
                    else
                    {
                        Console.WriteLine("Enter a valid book id");
                    }
                }else
                {
                    Console.WriteLine("invalid id");
                }
            }
        }
        public static void OrderHistory()
        {
            Console.WriteLine("Order histriy");
        }
        public static void ShowBalance()
        {
            Console.WriteLine("SHowBalance");
        }
    }
}