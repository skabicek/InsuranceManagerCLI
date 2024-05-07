using FincoraConsoleAppDemo.Context;
using FincoraConsoleAppDemo.CRUD;
using FincoraConsoleAppDemo.GraphicsUI;
using FincoraConsoleAppDemo.Models;

namespace FincoraConsoleAppDemo.Filtering
{
    public class FilterContracts
    {
        public static void OnInsType(MyAppContext context)
        {
            var allTypes = context.ContractTypes.ToList().OrderBy(a => a.Name).ToList();
            ListEntities.ListInsTypes(allTypes);

            int rowNum = 0;

            SelectRow(ref rowNum, allTypes.Count, "type");

            var filteredCont = context.Contracts.ToList().OrderBy(a => a.SignDate)
                                                .Where(x => x.ContractType.Id == allTypes[rowNum - 1].Id).ToList();
            
            ListEntities.ListContracts(filteredCont, " based on your filter");
        }


        public static void OnInsCompany(MyAppContext context)
        {
            var allCompanies = context.InsuranceCompanies.ToList().OrderBy(a => a.Name).ToList();
            ListEntities.ListInsCompanies(allCompanies, "");

            int rowNum = 0;

            SelectRow(ref rowNum, allCompanies.Count, "company");

            var filteredCont = context.Contracts.ToList().OrderBy(a => a.SignDate)
                                                .Where(x => x.InsuranceCompany.Id == allCompanies[rowNum - 1].Id).ToList();

            ListEntities.ListContracts(filteredCont, " based on your filter");
        }


        public static void OnVehicle(MyAppContext context)
        {
            Console.WriteLine("Would you like to filter contracts that contain vehicles ('y') or do not contain them ('n')?");

            string? response;

            while (true)
            {
                response = Console.ReadLine();
                
                if (response.Trim().ToLower().Equals("y") || response.Trim().ToLower().Equals("n")) break;

                InstructionsOutput.InvalidArgs();
            }
            List<Contract> filteredCont;

            if (response.Trim().ToLower().Equals("y"))
            
                filteredCont = context.Contracts.ToList().OrderBy(a => a.SignDate)
                                                .Where(x => x.ContractType.InvolveVehicle.ToString().ToLower().Equals("y")).ToList();
            else
                filteredCont = context.Contracts.ToList().OrderBy(a => a.SignDate)
                                                .Where(x => x.ContractType.InvolveVehicle.ToString().ToLower().Equals("n")).ToList();

            ListEntities.ListContracts(filteredCont, " based on your filter");
        }


        public static void OnSignDate(MyAppContext context)
        {
            Console.WriteLine("Enter the number of days.");

            int days = 0;
            FilterClients.GetIntInput(ref days);

            var filteredCont = context.Contracts.ToList().OrderBy(a => a.SignDate)
                                                .Where(x => x.SignDate >= DateOnly.FromDateTime(DateTime.Now).AddDays(-days)).ToList();

            ListEntities.ListContracts(filteredCont, " based on your filter");
        }


        public static void SelectRow(ref int retval, int threshold, string entity)
        {
            string? response;

            while (true)
            {
                Console.WriteLine($"\nEnter the number of row containg {entity} you want to filter contracts by:");

                response = Console.ReadLine();

                if (int.TryParse(response.Trim(), out retval) &&
                    retval > 0 && retval <= threshold) break;

                InstructionsOutput.InvalidArgs();
            }
        }
    }
}
