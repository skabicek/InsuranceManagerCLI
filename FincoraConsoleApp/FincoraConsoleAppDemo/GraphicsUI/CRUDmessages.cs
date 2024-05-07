
namespace FincoraConsoleAppDemo.GraphicsUI
{
    public class CRUDmessages
    {
        public static void CreateAddressFirstly()
        {
            Console.WriteLine("You have to create the corresponding address of new added entity firstly.");
        }


        public static void CompanyCreated()
        {
            Console.WriteLine("New Insurance Company was added successfully.");
        }


        public static void AddressCreated()
        {
            Console.WriteLine("New address was added successfully.");
        }


        public static void InsuranceTypeCreated()
        {
            Console.WriteLine("New insurance type was added successfully.");
        }


        public static void ClientCreated()
        {
            Console.WriteLine("New client was added successfully.");
        }


        public static void VehicleCreated() 
        {
            Console.WriteLine("New vehicle was added successfully.");
        }


        public static void CreatingContract(int flag)
        {
            if (flag == 0) 
                Console.WriteLine("Would you like to assign new contract to the existing person or create new one ?");
            else 
                Console.WriteLine("Type \"e\" for existing, \"n\" for creating new:");
        }


        public static void ContractCreated()
        {
            Console.WriteLine("New contract was added successfully.");
        }


        public static void ChangeCertainAttr()
        {
            Console.WriteLine("Type \"-\" when you don't want to change certain attribute");
        }


        public static void SuccessfullyUpdated(string entity)
        {
            Console.WriteLine($"The {entity} was successfully updated.\n");
        }


        public static void SuccessfullyDeleted(string entity)
        {
            Console.WriteLine($"All {entity} have been deleted.");
        }


        public static void ConfirmDeleting(string entity)
        {
            if (entity.Equals("comp"))
            {
                Console.WriteLine("\nDo you want to delete companies printed above? Addresses assigned to the companies will be deleted as well.\n");
            }
            else if (entity.Equals("cli"))
            {
                Console.WriteLine("\nDo you want to delete clients printed above? Addresses assigned to the clients will be deleted as well.\n");
            }
            else
            {
                Console.WriteLine("\nDo you want to delete contracts printed above? Vehicles assigned to the contracts will be deleted as well.\n");
            }
            Console.WriteLine("Press \"y\" for yes or \"n\" for returning to the main menu:");
        }
    }
}
