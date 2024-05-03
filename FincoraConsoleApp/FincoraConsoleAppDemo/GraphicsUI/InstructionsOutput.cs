using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FincoraConsoleAppDemo.GraphicsUI
{
    public class InstructionsOutput
    {
        public static void IntroductionMessage()
        {
            Console.WriteLine("Welcome to Insurance Policy Manager.\n");  
        }


        public static void PossibleCommands()
        {
            Console.WriteLine("Your options are:\nadd-contract, add-inscompany, add-instype\n");
        }


        public static void InvalidInput()
        {
            Console.WriteLine("Your command is not recognized, try again please.");
        }


        public static void InvalidArgsAmount() 
        {
            Console.WriteLine("Invalid amount of arguments, try again please.");
        }


        public static void ToCreateAddress() 
        {
            Console.WriteLine("Type Country, City, Postal Code, Street and House Number use \",\" as delimiter:");
        }


        public static void ToCreateCompany()
        {
            Console.WriteLine("Type Name and Phone Number of company, use \",\" as delimiter:");
        }
    }
}
