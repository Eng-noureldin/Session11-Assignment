using System;
using System.Collections.Generic;
using Assignment08.Section01;
using Assignment08.Section02;

namespace Assignment08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // DEMO: Section 01 - Book Library Engine
            
            Console.WriteLine("========================================");
            Console.WriteLine("        SECTION 01: BOOK LIBRARY        ");
            Console.WriteLine("========================================");

            List<Book> books = new List<Book>
            {
                new Book("978-0131103627", "The C Programming Language", new string[] { "Brian Kernighan", "Dennis Ritchie" }, new DateTime(1978, 2, 22), 49.99m),
                new Book("978-0321714114", "C++ Primer", new string[] { "Stanley Lippman", "Josée Lajoie" }, new DateTime(2012, 8, 16), 59.99m)
            };

            // a. User-defined delegate
            Console.WriteLine("\n--- a. User-Defined Delegate (GetTitle) ---");
            BookDelegate titleDelegate = BookFunctions.GetTitle;
            LibraryEngine.ProcessBooks(books, titleDelegate);

            // b. Built-in Func<> delegate
            Console.WriteLine("\n--- b. Built-In Func<> Delegate (GetPrice) ---");
            Func<Book, string> priceFunc = BookFunctions.GetPrice;
            LibraryEngine.ProcessBooks(books, priceFunc);

            // c. Anonymous Method (GetISBN)
            Console.WriteLine("\n--- c. Anonymous Method (GetISBN) ---");
            Func<Book, string> isbnAnonymous = delegate(Book b)
            {
                return b?.ISBN ?? "N/A";
            };
            LibraryEngine.ProcessBooks(books, isbnAnonymous);

            // d. Lambda Expression (GetPublicationDate)
            Console.WriteLine("\n--- d. Lambda Expression (GetPublicationDate) ---");
            LibraryEngine.ProcessBooks(books, b => b.PublicationDate.ToShortDateString());


            
            // DEMO: Section 02 - Order Processing System
            
            Console.WriteLine("\n========================================");
            Console.WriteLine("     SECTION 02: ORDER PROCESSING       ");
            Console.WriteLine("========================================");

            OrderService orderService = new OrderService();
            Order testOrder = new Order(101, "Alice Smith", 150.00m, 3);

            // Part 3: Predicate<Order> Validations
            Console.WriteLine("\n--- Part 3: Predicate Validations ---");
            bool isValidQuantity = orderService.ValidateOrder(testOrder, o => o.Quantity > 0);
            bool isValidPrice = orderService.ValidateOrder(testOrder, o => o.Price > 0);
            bool hasCustomerName = orderService.ValidateOrder(testOrder, o => !string.IsNullOrWhiteSpace(o.CustomerName));

            Console.WriteLine($"Quantity > 0: {isValidQuantity}");
            Console.WriteLine($"Price > 0: {isValidPrice}");
            Console.WriteLine($"Has Customer Name: {hasCustomerName}");

            // Part 1 & 2 & Bonus: Dynamic Pricing Strategies using Func<Order, decimal>
            Console.WriteLine("\n--- Part 2 & Bonus: Pricing Strategies ---");
            Func<Order, decimal> normalPrice = o => o.Price * o.Quantity;
            Func<Order, decimal> discount10 = o => (o.Price * o.Quantity) * 0.90m;
            Func<Order, decimal> discount20 = o => (o.Price * o.Quantity) * 0.80m;
            Func<Order, decimal> vipDiscount = o => (o.Price * o.Quantity) * 0.70m;

            Console.WriteLine($"Normal Price: {orderService.CalculateOrderPrice(testOrder, normalPrice):C}");
            Console.WriteLine($"10% Discount: {orderService.CalculateOrderPrice(testOrder, discount10):C}");
            Console.WriteLine($"20% Discount: {orderService.CalculateOrderPrice(testOrder, discount20):C}");
            Console.WriteLine($"VIP Discount (30% off): {orderService.CalculateOrderPrice(testOrder, vipDiscount):C}");

            // Part 4: Action<Order> Execution
            Console.WriteLine("\n--- Part 4: Action Executions ---");
            Action<Order> printInfo = o => Console.WriteLine($"[Action] Order #{o.Id} for {o.CustomerName}");
            Action<Order> sendConfirmation = o => Console.WriteLine($"[Action] Sending confirmation email to {o.CustomerName}...");
            
            orderService.ExecuteAction(testOrder, printInfo);
            orderService.ExecuteAction(testOrder, sendConfirmation);

            // Part 5 & 6: Events & Multicast Subscription / Unsubscription
            Console.WriteLine("\n--- Part 5 & 6: Events & Multicast Handlers ---");

            // Event Handler Definitions
            Action<Order> printHandler = o => Console.WriteLine($"[Handler 1] Order #{o.Id} printed.");
            Action<Order> emailHandler = o => Console.WriteLine($"[Handler 2] Email sent for Order #{o.Id}.");
            Action<Order> auditHandler = o => Console.WriteLine($"[Handler 3] Order #{o.Id} audited in logs.");

            // Subscribing Handlers
            orderService.OrderProcessed += printHandler;
            orderService.OrderProcessed += emailHandler;
            orderService.OrderProcessed += auditHandler;

            Console.WriteLine("\n1. Invoking ProcessOrder (3 Handlers Subscribed):");
            orderService.ProcessOrder(testOrder);

            // Unsubscribing Handler 1
            orderService.OrderProcessed -= printHandler;

            Console.WriteLine("\n2. Invoking ProcessOrder after Unsubscribing Handler 1 (2 Handlers Subscribed):");
            orderService.ProcessOrder(testOrder);
        }
    }
}