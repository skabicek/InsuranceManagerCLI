using FincoraConsoleAppDemo.Context;
using FincoraConsoleAppDemo.CRUD;

namespace FincoraConsoleAppDemo.Filtering
{
    public class FilterVehicles
    {
        public static void OnBrand(MyAppContext context)
        {
            Console.WriteLine("Enter the brand you want to filter vehicles by:");

            string? response = Console.ReadLine().Trim().ToLower();

            var vehicles = context.Vehicles.ToList().OrderBy(a => a.Brand).ThenBy(a => a.Model)
                                           .Where(x => x.Brand.ToLower().Equals(response)).ToList();

            ListEntities.ListVehicles(vehicles);
        }


        public static void OnPrice(MyAppContext context)
        {
            Console.WriteLine("Enter the minimum value of price in € you want to filter vehicles by:");

            int minVal = 0, maxVal = 0;

            FilterClients.GetIntInput(ref minVal);

            Console.WriteLine("Enter the maximum value of price in € you want to filter vehicles by:");

            FilterClients.GetIntInput(ref maxVal);

            var vehicles = context.Vehicles.ToList().OrderBy(a => a.Brand).ThenBy(a => a.Model)
                                           .Where(x => int.Parse(x.Price) <= maxVal && int.Parse(x.Price) >= minVal).ToList();

            ListEntities.ListVehicles(vehicles);
        }


        public static void OnManufactureDate(MyAppContext context)
        {
            Console.WriteLine("Enter the year.");

            int year = 0;
            FilterClients.GetIntInput(ref year);

            var vehicles = context.Vehicles.ToList().OrderBy(a => a.Brand).ThenBy(a => a.Model)
                                           .Where(x => int.Parse(x.YearOfManufacture) >= year).ToList();
            
            ListEntities.ListVehicles(vehicles);
        }
    }  
}
