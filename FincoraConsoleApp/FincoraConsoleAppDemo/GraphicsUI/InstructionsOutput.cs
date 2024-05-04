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

        public static void InvalidArgs() 
        {
            Console.WriteLine("The provided input is not correct, try again please.");
        }


        public static void ToCreateAddress() 
        {
            Console.WriteLine("Provide the Country, City, Postal Code, Street and House Number use \",\" as delimiter:");
        }


        public static void ToCreateCompany()
        {
            Console.WriteLine("Provide the Name and Phone Number of company, use \",\" as delimiter:");
        }


        public static void ToCreateInsType()
        {
            Console.WriteLine("Provide the Name of the type and indicate whether it should apply to the vehicle (y/n), use \",\" as delimiter:");
        }


        public static void ToCreateClient()
        {
            Console.WriteLine("Provide the Name, Surname, Nationality and Phone Number, use \",\" as delimiter:");
        }


        public static void ToCreateVehicle()
        {
            Console.WriteLine("Provide the Evidence Number, Brand, Model, Year of manufacture and price, use \",\" as delimiter:");
        }


        public static void SelectClient() 
        {
            Console.WriteLine("Select the number of the client to whom you want to assign the new contract:");
        }
    }
}
