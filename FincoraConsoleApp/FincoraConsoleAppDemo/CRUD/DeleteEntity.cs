using FincoraConsoleAppDemo.Context;
using FincoraConsoleAppDemo.GraphicsUI;

namespace FincoraConsoleAppDemo.CRUD
{
    public class DeleteEntity
    {
        public static async void DeleteCompsWithoutContr(MyAppContext context)
        {
            var zeroContractComp = context.InsuranceCompanies.ToList().OrderBy(a => a.Name).Where(x => x.Contracts.Count == 0).ToList();

            if (zeroContractComp.Count == 0)
            {
                Console.WriteLine("There are not currently companies without any contract.");
                return;
            }
            ListEntities.ListInsCompanies(zeroContractComp, " without any contract");
 
            if (ConfirmDeletion("comp"))
            {
                foreach (var comp in zeroContractComp)
                {
                    context.Addresses.Remove(comp.Address);
                    context.InsuranceCompanies.Remove(comp);
                }
                await context.SaveChangesAsync();
                CRUDmessages.SuccessfullyDeleted("companies without any contract");
            }
        }


        public static async void DeleteClientsWithoutContr(MyAppContext context)
        {
            var zeroContractCli = context.Clients.ToList().OrderBy(a => a.Name).ThenBy(x => x.Surname).Where(x => x.Contracts.Count == 0).ToList();

            if (zeroContractCli.Count == 0)
            {
                Console.WriteLine("There are not currently clients without any contract.");
                return;
            }
            ListEntities.ListClients(zeroContractCli, " without any contract");  

            if (ConfirmDeletion("cli"))
            {
                foreach (var cli in zeroContractCli)
                {
                    context.Addresses.Remove(cli.Address);
                    context.Clients.Remove(cli);
                }
                await context.SaveChangesAsync();
                CRUDmessages.SuccessfullyDeleted("clients without any contract");
            }
        }


        public static async void DeleteStornedContrs(MyAppContext context)
        {
            var storned = context.Contracts.ToList().OrderBy(a => a.SignDate).Where(x => x.Status.Equals("Storno")).ToList();

            if (storned.Count == 0)
            {
                Console.WriteLine("There are not currently storned contracts.");
                return;
            }
            ListEntities.ListContracts(storned, " that are storned");

            if (ConfirmDeletion("cont"))
            {
                foreach (var cont in storned)
                {
                    if (cont.Vehicle != null)
                        context.Vehicles.Remove(cont.Vehicle);

                    context.Contracts.Remove(cont);
                }
                await context.SaveChangesAsync();
                CRUDmessages.SuccessfullyDeleted("storned contracts");
            }
        }


        private static bool ConfirmDeletion(string message)
        {
            string response;
            while (true)
            {
                CRUDmessages.ConfirmDeleting(message);
                response = Console.ReadLine();

                if (response.Trim().ToLower().Equals("y") || response.Trim().ToLower().Equals("n")) break;

                InstructionsOutput.InvalidArgs();
            }
            return response.Trim().ToLower().Equals("y");
        }
    }
}
