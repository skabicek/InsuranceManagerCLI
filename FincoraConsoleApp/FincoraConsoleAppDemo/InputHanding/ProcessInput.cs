using FincoraConsoleAppDemo.Context;
using FincoraConsoleAppDemo.CRUD;
using FincoraConsoleAppDemo.GraphicsUI;

namespace FincoraConsoleAppDemo.InputHanding
{
    public class ProcessInput
    {
        public static bool ProcessUserInput(MyAppContext context)
        {
            InstructionsOutput.PossibleGeneralCommands();

            string userInput = Console.ReadLine();

            switch (userInput)
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
                    ListEntities.ListContracts(context);
                    break;

                case "comp":
                    ListEntities.ListInsCompanies(context);
                    break;

                case "type":
                    ListEntities.ListInsTypes(context);
                    break;

                case "cli":
                    ListEntities.ListClients(context);
                    break;

                case "veh":
                    ListEntities.ListVehicles(context);
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
    }
}
