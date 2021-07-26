//Programmer: Erica Slotkin (eslotkin@cnm.edu)

//Filename: Program.cs

using System;
using System.Collections.Generic;
using System.Linq; //ES: syntax error - added to use .Count at line 82 and 84

namespace TShirtOrders
{
    class Program
    {
        private const string CompanyName = "Super Shirt Ordermatic 3000";
        private const string CompanySlogan = "The best shirt ordering system in the multiverse!";

        static void Main(string[] args)
        {
            Header();
            char option;
            List<TShirtOrder> orders = new List<TShirtOrder>();

            do
            {
                DisplayShirtOrders(orders);
                string userInput = GetStringFromUser("(A)dd shirt (R)emove shirt (T)otal (E)xit: ");
                option = userInput.Trim().ToUpper().ToCharArray()[0];  //ES: logic error - required casting type string "userInput" to type char "option"
                switch (option)
                {
                    case 'A':
                        AddShirtOrder(orders);
                        break;
                    case 'R':
                        RemoveShirtOrder(orders);
                        break;
                    case 'T':
                        DisplayTotal(orders);
                        break;
                }
            } while (option != 'E');
            Console.WriteLine("Thank you for using " + CompanyName);
        }

        private static void DisplayTotal(List<TShirtOrder> orders)
        {
            
            decimal total = 0;

            for (int i = 0; i < orders.Count(); ++i) //ES: rewrote loop to use i in line 50. I couldn't get it to work with a foreach loop
            {
                total += orders[i].Price; //ES: added i 'index' of orders to get each order price to add
            }
            Console.WriteLine("Total price of order is: " + total);
        }
        //ES: I don't get it, I feel like the below method should work...but it doesn't in my program???
        private static void RemoveShirtOrder(List<TShirtOrder> orders)
        {
            int index = GetIntFromUser("Enter index of shirt order to remove: ");
            if (GetBoolFromUser("Are you sure you want to delete this order?"))
            {
                orders.Remove(orders[index]);  //ES: syntax error - needed to pass the index into the actual list to access a value
            }
        } 

        private static void AddShirtOrder(List<TShirtOrder> orders)
        {
            TShirtOrder order = new TShirtOrder();
            order.FirstName = GetStringFromUser("Please enter your first name: ");
            order.LastName = GetStringFromUser("Please enter your last name: ");
            order.IsLocalPickup = GetBoolFromUser("Local pickup");
            if (!order.IsLocalPickup)
            {
                order.Address = GetStringFromUser("Address: ");
            }
            order.PrintAreaInSqIn = (decimal)GetDoubleFromUser("Please enter area of your design in square inches: ");  //ES: syntax error - required casting into decimal type bc PrintAreaInSqIn is a deciaml type
            order.NumColors = GetIntFromUser("Please enter number of colors: ");
            order.NumShirts = GetIntFromUser("Please enter the number of shirts: ");
            Console.WriteLine(order.ToString());
            orders.Add(order);
        }

        private static void DisplayShirtOrders(List<TShirtOrder> orders)
        {
            Console.WriteLine();
            Console.WriteLine("Current shirts orders:");
            if (orders.Count() > 0)
            {
                for (int i = 0; i < orders.Count(); ++i) 
                {
                    Console.WriteLine((i + 1) + ": " + orders[i].ToString());  //ES: syntax error - added index of order
                }
            }
            else
            {
                Console.WriteLine("Currently no shirts orders.");
            }
            Console.WriteLine();
        }

        private static void Header()
        {
            Console.WriteLine("Welcome to " + CompanyName + "!");
            Console.WriteLine(CompanySlogan);
            Console.WriteLine();
        }

        private static bool GetBoolFromUser(string prompt)
        {
            Console.Write(prompt + " (y/n)? ");
            return Console.ReadLine().ToLower()[0] == 'y';
        }

        private static int GetIntFromUser(string prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine());
        }

        private static double GetDoubleFromUser(string prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine());
        }

        private static string GetStringFromUser(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
