using FincoraConsoleAppDemo;
using FincoraConsoleAppDemo.Context;
using FincoraConsoleAppDemo.GraphicsUI;
using FincoraConsoleAppDemo.InputHanding;
using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main(string[] _)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        try
        {
            /*if (File.Exists("myapp.db")) 
                File.Delete("myapp.db");*/
            bool seedFlag = !File.Exists("myapp.db");

            using (var context = new MyAppContext())
            {
                await context.Database.MigrateAsync();

                        // Default data seeding //
                if (seedFlag)
                {
                    DataSeed.AddingContractTypes(context);
                    DataSeed.AddingAddresses(context);
                    DataSeed.AddingClients(context);
                    DataSeed.AddingInsuranceCompanies(context);
                    DataSeed.AddingVehicles(context);
                    DataSeed.AddingContracts(context);
                }
                await context.SaveChangesAsync();
                InstructionsOutput.IntroductionMessage();
                
                while (ProcessInput.ProcessUserInput(context));
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
