using FincoraConsoleAppDemo;
using FincoraConsoleAppDemo.Context;
using FincoraConsoleAppDemo.GraphicsUI;
using FincoraConsoleAppDemo.InputHanding;

class Program
{
    static async Task Main(string[] _)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
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
