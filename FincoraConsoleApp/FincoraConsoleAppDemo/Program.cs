using FincoraConsoleAppDemo;
using FincoraConsoleAppDemo.Context;
using FincoraConsoleAppDemo.CRUD;
using FincoraConsoleAppDemo.GraphicsUI;
using FincoraConsoleAppDemo.InputHanding;
using FincoraConsoleAppDemo.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            if (File.Exists("myapp.db"))
                File.Delete("myapp.db");

            using (var context = new MyAppContext())
            {
                await context.Database.EnsureCreatedAsync();

                // Default data seeding //

                DataSeed.AddingContractTypes(context);
                DataSeed.AddingAddresses(context);
                DataSeed.AddingClients(context);
                DataSeed.AddingInsuranceCompanies(context);
                DataSeed.AddingVehicles(context);
                DataSeed.AddingContracts(context);

                InstructionsOutput.IntroductionMessage();
                while (ProcessInput.ProcessUserInput(context));
                
                /*var contracts = await context.Contracts.ToListAsync();
                
                foreach (var u in contracts)
                {
                    Console.WriteLine($"meno: {u.Client.Name}, ContractType u zmluvy: { u.ContractType.Name }");
                }

                var contractsTypes = await context.ContractTypes.ToListAsync();

                foreach (var u in contractsTypes)
                {
                    Console.WriteLine($"ID: {u.Id}, Type: {u.Name}");
                }*/

                //CreateEntity.CreateNewClient(context);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            if (ex.InnerException != null)
                Console.WriteLine("Inner exception: " + ex.InnerException.Message);
        }
    }
}
