
namespace FincoraConsoleAppDemo.GraphicsUI
{
    public class InstructionsOutput
    {
        public static void IntroductionMessage()
        {
            Console.WriteLine("Welcome to Insurance Policy Manager.\n");  
        }


        public static void PossibleGeneralCommands()
        {
            Console.WriteLine("After selecting one option, you will be redirected to choose the category of your selection. " +
                               "Your options are:\nadd, list, update, quit\n");
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
            Console.WriteLine("Provide the Name, Surname, Nationality and Phone Number of client, use \",\" as delimiter:");
        }


        public static void ToCreateVehicle()
        {
            Console.WriteLine("Provide the Evidence Number, Brand, Model, Year of manufacture and price in \u20AC, use \",\" as delimiter:");
        }


        public static void SelectRowNumberCr(string model) 
        {
            Console.WriteLine($"\nSelect the number of the {model} to whom you want to assign the new contract:");
        }


        public static void AddingOptMessage()
        {
            Console.WriteLine("What entity would you like to add ?\n" +
                               "Type:\n\t\"comp\" for insurance company\n\t\"type\" for insurance type\n\t" +
                                "\"cont\" for contract\n\t\"c\" to cancel adding operation");
        }


        public static void ListingOptMessage()
        {
            Console.WriteLine("What type of entities would you like to list ?\n" +
                               "Type:\n\t\"comp\" for insurance companies\n\t\"type\" for insurance types\n\t" +
                                "\"cont\" for contracts\n\t\"veh\" for vehicles\n\t\"cli\" for clients" +
                                 "\n\t\"c\" to cancel listing operation");
        }


        public static void UpdatingOptMessage()
        {
            Console.WriteLine("What entity would you like to update ?\n" +
                               "Type:\n\t\"cli\" for updating client info\n\t\"comp\" for updating insurance company info\n\t" +
                                "\"veh\" for updating vehicle stats\n\t\"cont\" for updating contract status\n\t\"type\" for updating insurance type name" +
                                 "\n\t\"c\" to cancel listing operation");
        }
    }
}
