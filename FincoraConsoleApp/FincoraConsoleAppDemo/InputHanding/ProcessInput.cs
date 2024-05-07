using FincoraConsoleAppDemo.Context;
using FincoraConsoleAppDemo.CRUD;
using FincoraConsoleAppDemo.Filtering;
using FincoraConsoleAppDemo.GraphicsUI;

namespace FincoraConsoleAppDemo.InputHanding
{
    public class ProcessInput
    {
        public static bool ProcessUserInput(MyAppContext context)
        {
            InstructionsOutput.PossibleGeneralCommands();

            string userInput = Console.ReadLine();

            switch (userInput.Trim().ToLower())
            {
                case "add":
                    ProcessAddOption(context);
                    break;

                case "list":
                    ProcessListOption(context);
                    break;

                case "update":
                    ProcessUpdateOption(context);
                    break;

                case "delete":
                    ProcessDeleteOption(context);
                    break;

                case "filter":
                    ProcessFilterOption(context);
                    break;

                case "quit":
                    return false;

                default:
                    InstructionsOutput.InvalidArgs();
                    break;
            }
            return true;
        }


        public static void ProcessAddOption(MyAppContext context)
        {
            InstructionsOutput.AddingOptMessage();

            string userInput = Console.ReadLine();

            switch (userInput.Trim().ToLower())
            {
                case "cont":
                    CreateEntity.CreateNewContract(context);
                    break;

                case "comp":
                    CreateEntity.CreateNewInsCompany(context);
                    break;

                case "type":
                    CreateEntity.CreateNewInsType(context);
                    break;

                case "cli":
                    CRUDmessages.CreateAddressFirstly();
                    CreateEntity.CreateNewClient(context);
                    break;

                case "c":
                    break;

                default:
                    InstructionsOutput.InvalidArgs();
                    ProcessAddOption(context);
                    break;
            }
        }


        public static void ProcessListOption(MyAppContext context)
        {
            InstructionsOutput.ListingOptMessage();

            string userInput = Console.ReadLine();

            switch (userInput.Trim().ToLower())
            {
                case "cont":
                    ListEntities.ListContracts([.. context.Contracts.ToList().OrderBy(a => a.SignDate)], "");
                    break;

                case "comp":
                    ListEntities.ListInsCompanies([.. context.InsuranceCompanies.ToList().OrderBy(a => a.Name)], "");
                    break;

                case "type":
                    ListEntities.ListInsTypes([.. context.ContractTypes.ToList().OrderBy(a => a.Name)]);
                    break;

                case "cli":
                    ListEntities.ListClients([.. context.Clients.ToList().OrderBy(a => a.Name).ThenBy(x => x.Surname)], "");
                    break;

                case "veh":
                    ListEntities.ListVehicles([.. context.Vehicles.ToList().OrderBy(a => a.Brand).ThenBy(a => a.Model)]);
                    break;

                case "c":
                    break;

                default:
                    InstructionsOutput.InvalidArgs();
                    ProcessListOption(context);
                    break;
            }
        }


        public static void ProcessUpdateOption(MyAppContext context)
        {
            InstructionsOutput.UpdatingOptMessage();

            string userInput = Console.ReadLine();

            switch (userInput.Trim().ToLower())
            {
                case "cont":
                    UpdateEntity.UpdateContStatus(context);
                    break;

                case "comp":
                    UpdateEntity.UpdateComp(context);
                    break;

                case "type":
                    UpdateEntity.UpdateInsType(context);
                    break;

                case "cli":
                    UpdateEntity.UpdateClient(context);
                    break;

                case "veh":
                    UpdateEntity.UpdateVehicle(context);
                    break;

                case "c":
                    break;

                default:
                    InstructionsOutput.InvalidArgs();
                    ProcessUpdateOption(context);
                    break;
            }
        }


        public static void ProcessDeleteOption(MyAppContext context)
        {
            InstructionsOutput.DeletingOptMessage();

            string userInput = Console.ReadLine();

            switch (userInput.Trim().ToLower())
            {
                case "cli":
                    DeleteEntity.DeleteClientsWithoutContr(context);
                    break;

                case "cont":
                    DeleteEntity.DeleteStornedContrs(context);
                    break;

                case "comp":
                    DeleteEntity.DeleteCompsWithoutContr(context);
                    break;

                case "c":
                    break;

                default:
                    InstructionsOutput.InvalidArgs();
                    ProcessDeleteOption(context);
                    break;
            }
        }


        public static void ProcessFilterOption(MyAppContext context)
        {
            InstructionsOutput.FilteringOptMessage();

            string userInput = Console.ReadLine();

            switch (userInput.Trim().ToLower())
            {
                case "cli-am":
                    FilterClients.OnAmount(context);
                    break;

                case "cli-nat":
                    FilterClients.OnNationality(context);
                    break;

                case "cont-type":
                    FilterContracts.OnInsType(context);
                    break;

                case "cont-comp":
                    FilterContracts.OnInsCompany(context);
                    break;

                case "cont-veh":
                    FilterContracts.OnVehicle(context);
                    break;

                case "cont-date":
                    FilterContracts.OnSignDate(context);
                    break;

                case "veh-brand":
                    FilterVehicles.OnBrand(context);
                    break;

                case "veh-price":
                    FilterVehicles.OnPrice(context);
                    break;

                case "veh-date":
                    FilterVehicles.OnManufactureDate(context);
                    break;

                case "c":
                    break;

                default:
                    InstructionsOutput.InvalidArgs();
                    ProcessDeleteOption(context);
                    break;
            }
        }
    }
}
