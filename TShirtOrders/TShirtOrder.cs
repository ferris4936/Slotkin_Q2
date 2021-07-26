//Programmer: Erica Slotkin (eslotkin@cnm.edu)

//Filename: TShirtOrder.cs

using System;
using System.Collections.Generic; //ES: required to use List

namespace TShirtOrders
{
    /// <summary>
    /// TShirtOrder
    /// Provides a model of a shirt order.
    /// </summary>
    public class TShirtOrder
    {
        private decimal printAreaInSqIn;
        private int numColors;
        private int numShirts;

        public TShirtOrder(string firstName, string lastName, string address, 
            bool isLocalPickup, decimal printAreaInSqIn, int numberOfColors, int numberOfShirts)  //ES: improper initialization in the arguments
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.IsLocalPickup = isLocalPickup;
            this.printAreaInSqIn = printAreaInSqIn;
            this.numColors = numberOfColors; //ES: logic error - corrected passed in varible name, otherwise they are the same variable
            this.numShirts = numberOfShirts; //ES: logic error - corrected passed in varible name, otherwise they are the same variable  

            Calc(); 
        }

        //ES: logic error - chained constructor to initialize properly, gave printAreaInSqIn a default value as well
        public TShirtOrder() : this("", "", "", true, 0, 1, 1) { } 

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public bool IsLocalPickup { get; set; }

        public decimal PrintAreaInSqIn
        {
            get { return printAreaInSqIn; }
            set { printAreaInSqIn = value; Calc(); }
        }

        public int NumColors
        {
            get { return numColors; } //ES: logic error - must use field variable, otherwise using NumColors to define itself as itself
            set { numColors = value; Calc(); } //ES: logic error - must use field variable, otherwise using NumColors to define itself as itslef
        }

        public int NumShirts
        {
            get { return numShirts; }
            set { numShirts = value; Calc(); }
        }

        public decimal Price { get; private set; } 

        private void Calc()
        {
            Price = numShirts * ((numColors * 2.25M) + (printAreaInSqIn * .05M));  //ES: added () for order of operations just in case!!
        }

        public override string ToString() //ES: logic error - required the addition of keyword 'override'
        {
            return 
                FirstName + " " 
                + LastName + " "
                + " Price: " + Price.ToString("c"); 
        }
    }
}
