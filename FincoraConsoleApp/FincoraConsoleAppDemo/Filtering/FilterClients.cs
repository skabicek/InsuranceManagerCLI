using FincoraConsoleAppDemo.Context;
using FincoraConsoleAppDemo.CRUD;
using FincoraConsoleAppDemo.GraphicsUI;

namespace FincoraConsoleAppDemo.Filtering
{
    public class FilterClients
    {
        public static void OnAmount(MyAppContext context)
        {
            Console.WriteLine("Enter the minimum value of contracts you want to filter clients by:");
 
            int minVal = 0, maxVal = 0;

            GetIntInput(ref minVal);

            Console.WriteLine("Enter the maximum value of contracts you want to filter clients by:");

            GetIntInput(ref maxVal);

            var filteredCli = context.Clients.ToList().OrderBy(a => a.Name).ThenBy(x => x.Surname)
                                             .Where(x => x.Contracts.Count >= minVal && x.Contracts.Count <= maxVal).ToList();

            ListEntities.ListClients(filteredCli, " based on your filter");
        }


        public static void OnNationality(MyAppContext context)
        {
            Console.WriteLine("Enter the nationality you want to filter clients by:");

            string? response = Console.ReadLine().Trim().ToLower();

            var filteredCli = context.Clients.ToList().OrderBy(a => a.Name).ThenBy(x => x.Surname)
                                             .Where(x => x.Nationality.ToLower().Equals(response)).ToList();
            
            ListEntities.ListClients(filteredCli, " based on your filter");
        }


        public static void GetIntInput(ref int retval)
        {
            string? response;

            while (true)
            {
                response = Console.ReadLine();

                if (int.TryParse(response, out retval)) break;
                InstructionsOutput.InvalidArgs();
            }
        }
    }
}
