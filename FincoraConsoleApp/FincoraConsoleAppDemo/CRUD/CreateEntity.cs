using FincoraConsoleAppDemo.Context;
using FincoraConsoleAppDemo.GraphicsUI;
using FincoraConsoleAppDemo.Models;

namespace FincoraConsoleAppDemo.CRUD
{
    public class CreateEntity
    {
        public static Client AssignClient(string response, MyAppContext context)
        {
            Client assignedClient;
            int selectedRow;

            if (response.Trim().ToLower().Equals("n")) // Creating new client
            {
                CRUDmessages.CreateAddressFirstly();
                assignedClient = CreateNewClient(context);
            }
            else // Choosing from existing clients
            {
                ListEntities.ListClients([.. context.Clients.ToList().OrderBy(a => a.Name).ThenBy(x => x.Surname)], "");
                InstructionsOutput.SelectRowNumberCr("client");

                while (true)
                {
                    response = Console.ReadLine();
                    if (int.TryParse(response, out selectedRow) &&
                         selectedRow > 0 && selectedRow <= context.Clients.Count()) break;

                    InstructionsOutput.InvalidArgs();
                }
                assignedClient = context.Clients.ToList().OrderBy(a => a.Name).ThenBy(x => x.Surname).ToList()[selectedRow - 1];
            }
            return assignedClient;
        }


        public static int AssignCompany(MyAppContext context)
        {
            int selectedRow;
            string response;

            ListEntities.ListInsCompanies([.. context.InsuranceCompanies.ToList().OrderBy(a => a.Name)], "");
            InstructionsOutput.SelectRowNumberCr("insurance company");

            while (true)
            {
                response = Console.ReadLine();
                if (int.TryParse(response, out selectedRow) &&
                     selectedRow > 0 && selectedRow <= context.InsuranceCompanies.Count()) break;

                InstructionsOutput.InvalidArgs();
            }
            return selectedRow;
        }


        public static int AssignInsType(MyAppContext context)
        {
            int selectedRow;
            string response;

            ListEntities.ListInsTypes([.. context.ContractTypes.ToList().OrderBy(a => a.Name)]);
            InstructionsOutput.SelectRowNumberCr("insurance type");

            while (true)
            {
                response = Console.ReadLine();
                if (int.TryParse(response, out selectedRow) &&
                     selectedRow > 0 && selectedRow <= context.ContractTypes.Count()) break;

                InstructionsOutput.InvalidArgs();
            }
            return selectedRow;
        }


        public static void CreateNewContract(MyAppContext context)
        {
            CRUDmessages.CreatingContract(0);
            string response;
            int selectedRow;

            while (true)
            {
                CRUDmessages.CreatingContract(1);

                response = Console.ReadLine();
                if (response.Trim().ToLower().Equals("e") ||
                     response.Trim().ToLower().Equals("n")) break;

                InstructionsOutput.InvalidArgs();
            }

            Client assignedClient = AssignClient(response, context);

            selectedRow = AssignCompany(context);
            InsuranceCompany assignedCompany = context.InsuranceCompanies.ToList().OrderBy(a => a.Name).ToList()[selectedRow - 1];

            selectedRow = AssignInsType(context);
            ContractType assignedType = context.ContractTypes.ToList().OrderBy(a => a.Name).ToList()[selectedRow - 1];

                        // check whether involve vehicle //

            Vehicle? assignedVehicle = null;

            if (assignedType.InvolveVehicle.Equals('Y'))
            {
                Console.WriteLine("Your selected insurance type involves vehicle.");
                assignedVehicle = CreateNewVehicle(context);
            }

            var contractToBeAdded = new Contract()
            {
                ContractTypeId = assignedType.Id,
                ClientId = assignedClient.Id,
                InsuranceCompanyId = assignedCompany.Id,
                VehicleId = assignedVehicle?.Id,
            };
            context.Contracts.AddAsync(contractToBeAdded);
            context.SaveChangesAsync();

            CRUDmessages.ContractCreated();
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
                    int.TryParse(vehicleToList[4].Trim(), out _) &&
                     int.TryParse(vehicleToList[3].Trim(), out int yearOfManufacture) &&
                      yearOfManufacture <= DateOnly.FromDateTime(DateTime.Now).Year) break;

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
                InvolveVehicle = insTypeToList[1].Trim().ToUpper()[0]  
            };

            context.ContractTypes.AddAsync(insTypeToBeAdded);
            context.SaveChangesAsync();

            CRUDmessages.InsuranceTypeCreated();
        }
    }
}
