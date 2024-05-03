using FincoraConsoleAppDemo.Context;
using FincoraConsoleAppDemo.CRUD;
using FincoraConsoleAppDemo.GraphicsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FincoraConsoleAppDemo.InputHanding
{
    public class ProcessInput
    {
        public static bool ProcessUserInput(MyAppContext context)
        {
            InstructionsOutput.PossibleCommands();

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "add-contract":
                    break;

                case "add-inscompany":
                    CreateEntity.CreateNewInsCompany(context);
                    break;

                case "add-instype":
                    break;

                case "quit":
                    return false;

                default:
                    InstructionsOutput.InvalidInput();
                    break;
            }
            return true;
        }
    }
}
