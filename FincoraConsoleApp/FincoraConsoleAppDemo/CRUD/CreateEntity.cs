using FincoraConsoleAppDemo.Context;
using FincoraConsoleAppDemo.GraphicsUI;
using FincoraConsoleAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FincoraConsoleAppDemo.CRUD
{
    public class CreateEntity
    {
        public static void CreateNewContract(MyAppContext context)
        {
            CRUDmessages.CreatingContract(0);
            string response;

            while (true)
            {
                CRUDmessages.CreatingContract(1);

                response = Console.ReadLine();
                if (response.Trim().ToLower().Equals("e") ||
                     response.Trim().ToLower().Equals("n")) break;

                InstructionsOutput.InvalidArgs();
            }
                        // user assigning //

            Client assignedClient;

            if (response.Trim().ToLower().Equals("n")) // Creating new client
            {
                CRUDmessages.CreateAddressFirstly();
                assignedClient = CreateNewClient(context);
            }
            else // Choosing from existing clients
            {
                int ixOfClient;
                ListEntities.ListClients(context);
                InstructionsOutput.SelectClient();

                while (true)
                {
                    response = Console.ReadLine();
                    if (int.TryParse(response, out ixOfClient) && 
                         ixOfClient > 0 && ixOfClient <= context.Clients.Count()) break;

                    InstructionsOutput.InvalidArgs();
                }
                assignedClient = context.Clients.ToList().OrderBy(a => a.Name).ThenBy(x => x.Surname).ToList()[ixOfClient - 1];
            }

                        // Insurance company assigning //
            

        }


        public static Vehicle CreateNewVehicle(MyAppContext context)
        {
            string vehicleResponse;
            string[] vehicleToList;

            while (true)
            {
                InstructionsOutput.ToCreateVehicle();

                vehicleResponse = Console.ReadLine();
                vehicleToList = vehicleResponse.Split(",");

                if (vehicleToList.Length == 5 &&
                    int.TryParse(vehicleToList[3].Trim(), out _) &&
                     int.TryParse(vehicleToList[4].Trim(), out _)) break;

                InstructionsOutput.InvalidArgs();
            }

            var vehicleToBeAdded = new Vehicle()
            {
                EvidenceNumber = vehicleToList[0].Trim(),
                Brand = vehicleToList[1].Trim(),
                Model = vehicleToList[2].Trim(),
                YearOfManufacture = vehicleToList[3].Trim(),
                Price = vehicleToList[4].Trim(),
            };
            context.Vehicles.AddAsync(vehicleToBeAdded);
            context.SaveChangesAsync();

            CRUDmessages.VehicleCreated();
            return vehicleToBeAdded;
        }


        public static Client CreateNewClient(MyAppContext context)
        {
            var corespondingAddress = CreateNewAddress(context);
 
            string clientResponse;
            string[] clientToList;

            while (true)
            {
                InstructionsOutput.ToCreateClient();

                clientResponse = Console.ReadLine();
                clientToList = clientResponse.Split(",");

                if (clientToList.Length == 4) break;

                InstructionsOutput.InvalidArgs();
            }

            var clientToBeAdded = new Client()
            {
                Name = clientToList[0].Trim(), Surname = clientToList[1].Trim(), 
                 Nationality = clientToList[2].Trim(), PhoneNumber = clientToList[3].Trim(), AddressID = corespondingAddress.Id
            };
            context.Clients.AddAsync(clientToBeAdded);
            context.SaveChangesAsync();

            CRUDmessages.ClientCreated();
            return clientToBeAdded;
        }


        public static Address CreateNewAddress(MyAppContext context)
        {
            string addressResponse;
            string[] adrToList;

            while (true)
            {
                InstructionsOutput.ToCreateAddress();

                addressResponse = Console.ReadLine();
                adrToList = addressResponse.Split(",");

                if (adrToList.Length == 5) break;

                InstructionsOutput.InvalidArgs();
            }

            var adrressToBeAdded = new Address()
            {
                Country = adrToList[0].Trim(),
                City = adrToList[1].Trim(),
                PostalCode = adrToList[2].Trim(),
                Street = adrToList[3].Trim(),
                HouseNumber = adrToList[4].Trim()
            };

            context.Addresses.AddAsync(adrressToBeAdded);
            context.SaveChangesAsync();

            CRUDmessages.AddressCreated();
            return adrressToBeAdded;
        }


        public static void CreateNewInsCompany(MyAppContext context)
        {
            CRUDmessages.CreateAddressFirstly();

            var corespondingAddress = CreateNewAddress(context);

            string companyResponse;
            string[] companyToList;

            while (true)
            {
                InstructionsOutput.ToCreateCompany();

                companyResponse = Console.ReadLine();
                companyToList = companyResponse.Split(",");

                if (companyToList.Length == 2) break;

                InstructionsOutput.InvalidArgs();
            }

            var companyToBeAdded = new InsuranceCompany()
            {
                Name = companyToList[0].Trim(), 
                PhoneNumber = companyToList[1].Trim(),
                AddressId = corespondingAddress.Id
            };

            context.InsuranceCompanies.AddAsync(companyToBeAdded);
            context.SaveChangesAsync();

            CRUDmessages.CompanyCreated();
        }


        public static void CreateNewInsType(MyAppContext context)
        {
            string insTypeResponse;
            string[] insTypeToList;

            while (true)
            {
                InstructionsOutput.ToCreateInsType();

                insTypeResponse = Console.ReadLine();
                insTypeToList = insTypeResponse.Split(",");

                if (insTypeToList.Length == 2 &&
                    (insTypeToList[1].Trim().ToLower().Equals("y") || insTypeToList[1].Trim().ToLower().Equals("n"))) break;

                InstructionsOutput.InvalidArgs();
            }

            var insTypeToBeAdded = new ContractType()
            {
                Name = insTypeToList[0].Trim(),
                InvolveVehicle = insTypeToList[1].Trim().ToLower().Equals("y") ? 1 : 0  
            };

            context.ContractTypes.AddAsync(insTypeToBeAdded);
            context.SaveChangesAsync();

            CRUDmessages.InsuranceTypeCreated();
        }
    }
}
