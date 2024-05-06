
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
    }
}
