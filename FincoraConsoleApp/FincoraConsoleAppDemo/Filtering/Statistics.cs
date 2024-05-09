using FincoraConsoleAppDemo.Context;

namespace FincoraConsoleAppDemo.Filtering
{
    public class Statistics
    {
        public static void PrintOutStats(MyAppContext context)
        {
            MostFrequentInsTypes(context);
            MostFrequentInsComps(context);
            MostFrequentNationality(context);
            MostFrequentBrandVehicle(context);
            MostExpensiveVehicle(context);
            AverageVehiclePrice(context);
        }


        private static void MostFrequentInsTypes(MyAppContext context)
        {
            var cTypes = context.ContractTypes.ToList().OrderBy(a => -a.Contracts.Count).ToList();

            var str = $"Most frequent contract type is: {cTypes[0].Name},";
            for (int i = 1; i < cTypes.Count; i++)
            {
                if (cTypes[i - 1].Contracts.Count != cTypes[i].Contracts.Count)
                    break;
                str += $" {cTypes[1].Name},";
            }
            Console.WriteLine($"{str.Remove(str.Length - 1)}");
        }


        private static void MostFrequentInsComps(MyAppContext context)
        {
            var insCompanies = context.InsuranceCompanies.ToList().OrderBy(a => -a.Contracts.Count).ToList();

            var str = $"Insurance company with the most contracts is: {insCompanies[0].Name},";
            
            for (int i = 1; i < insCompanies.Count; i++)
            {
                if (insCompanies[i - 1].Contracts.Count != insCompanies[i].Contracts.Count)
                    break;
                str += $" {insCompanies[1].Name},";
            }
            Console.WriteLine($"{str.Remove(str.Length - 1)}");
        }


        private static void MostFrequentNationality(MyAppContext context)
        {
            var clients = context.Clients.ToList().GroupBy(x => x.Nationality.ToLower()).OrderBy(y => -y.Count()).ToList();

            var str = $"Most frequent nationality is: {clients[0].Key},";

            for (int i = 1; i < clients.Count; i++)
            {
                if (clients[i - 1].Count() != clients[i].Count())
                    break;
                str += $" {clients[i].Key},";
            }
            Console.WriteLine($"{str.Remove(str.Length - 1)}");
        }


        private static void MostFrequentBrandVehicle(MyAppContext context)
        {
            var vehicles = context.Vehicles.ToList().GroupBy(x => x.Brand.ToLower()).OrderBy(y => -y.Count()).ToList();

            var str = $"Most frequent vehicle brand is: {vehicles[0].Key},";

            for (int i = 1; i < vehicles.Count; i++)
            {
                if (vehicles[i - 1].Count() != vehicles[i].Count())
                    break;
                str += $" {vehicles[i].Key},";
            }
            Console.WriteLine($"{str.Remove(str.Length - 1)}");
        }


        private static void MostExpensiveVehicle(MyAppContext context)
        {
            var vehicles = context.Vehicles.ToList().OrderBy(y => -int.Parse(y.Price)).First();

            Console.WriteLine($"Most expensive vehicle costs: {vehicles.Price} €");
        }


        private static void AverageVehiclePrice(MyAppContext context)
        {
            var avPri = context.Vehicles.ToList().Average(x => int.Parse(x.Price));

            Console.WriteLine($"Average price of vehicle is: {avPri} €");
        }
    }
}
