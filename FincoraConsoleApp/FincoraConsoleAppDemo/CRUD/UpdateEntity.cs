using FincoraConsoleAppDemo.Models;
using FincoraConsoleAppDemo.Context;
using FincoraConsoleAppDemo.GraphicsUI;
using FincoraConsoleAppDemo.Interfaces;

namespace FincoraConsoleAppDemo.CRUD
{
    public class UpdateEntity
    {
        public static async void UpdateVehicle(MyAppContext context)
        {
            ListEntities.ListVehicles([.. context.Vehicles.ToList().OrderBy(a => a.Brand).ThenBy(a => a.Model)]);
            Console.WriteLine("Select the vehicle number for updating:");

            string? response;
            string[] changedValues;

            var vehicle = context.Vehicles.ToList().OrderBy(a => a.Brand).ThenBy(a => a.Model).ToList()[SelectRowNumber(context.Vehicles.Count())];

            Vehicle updatedVehic = await context.Vehicles.FindAsync(vehicle.Id);

            while (true)
            {
                InstructionsOutput.ToCreateVehicle();
                CRUDmessages.ChangeCertainAttr();

                response = Console.ReadLine();
                changedValues = response.Split(",");

                if (changedValues.Length == 5)
                {
                    if ((changedValues[3].Trim().Equals("-") ||
                         (int.TryParse(changedValues[3].Trim(), out int yearOfManufacture) &&
                            yearOfManufacture <= DateOnly.FromDateTime(DateTime.Now).Year)) &&
                              (changedValues[4].Trim().Equals("-") || int.TryParse(changedValues[4].Trim(), out _)))
                        break;
                }
                InstructionsOutput.InvalidArgs();
            }

            if (!changedValues[0].Trim().Equals("-"))
                updatedVehic.EvidenceNumber = changedValues[0].Trim();

            if (!changedValues[1].Trim().Equals("-"))
                updatedVehic.Brand = changedValues[1].Trim();

            if (!changedValues[2].Trim().Equals("-"))
                updatedVehic.Model = changedValues[2].Trim();

            if (!changedValues[3].Trim().Equals("-"))
                updatedVehic.YearOfManufacture = changedValues[3].Trim();

            if (!changedValues[4].Trim().Equals("-"))
                updatedVehic.Price = changedValues[4].Trim();

            context.Update(updatedVehic);

            await context.SaveChangesAsync();
            CRUDmessages.SuccessfullyUpdated("vehicle stats");
        }


        public static async void UpdateInsType(MyAppContext context)
        {
            ListEntities.ListInsTypes([.. context.ContractTypes.ToList().OrderBy(a => a.Name)]);
            Console.WriteLine("Select the insurance type number to update its name:");

            string? response;

            var contractType = context.ContractTypes.ToList().OrderBy(a => a.Name).ToList()[SelectRowNumber(context.ContractTypes.Count())];

            ContractType updatedType = await context.ContractTypes.FindAsync(contractType.Id);

            while (true)
            {
                Console.WriteLine("Type the new name of selected insurance type:");
                response = Console.ReadLine();

                if (response.Length != 0) break;
                InstructionsOutput.InvalidArgs();
            }

            updatedType.Name = response;
            context.Update(updatedType);

            await context.SaveChangesAsync();
            CRUDmessages.SuccessfullyUpdated("insurance type");
        }


        public static async void UpdateContStatus(MyAppContext context)
        {
            ListEntities.ListContracts([.. context.Contracts.ToList().OrderBy(a => a.SignDate)], "");
            Console.WriteLine("Select the contract number to update its status to storno:");

            var contract = context.Contracts.ToList().OrderBy(a => a.SignDate).ToList()[SelectRowNumber(context.Contracts.Count())];

            Contract updatedCont = await context.Contracts.FindAsync(contract.Id);

            updatedCont.Status = "Storno";
            context.Update(updatedCont);

            await context.SaveChangesAsync();
            CRUDmessages.SuccessfullyUpdated("contract status");
        }


        public static async void UpdateComp(MyAppContext context)
        {
            ListEntities.ListInsCompanies([.. context.InsuranceCompanies.ToList().OrderBy(a => a.Name)], "");
            Console.WriteLine("Select the company number for updating:");

            string? response;
            string[] changedValues;

            var company = context.InsuranceCompanies.ToList().OrderBy(a => a.Name).ToList()[SelectRowNumber(context.InsuranceCompanies.Count())];

            InsuranceCompany updatedComp = await context.InsuranceCompanies.FindAsync(company.Id);

            while (true)
            {
                InstructionsOutput.ToCreateCompany();
                CRUDmessages.ChangeCertainAttr();

                response = Console.ReadLine();
                changedValues = response.Split(",");

                if (changedValues.Length == 2) break;

                InstructionsOutput.InvalidArgs();
            }

            if (!changedValues[0].Trim().Equals("-"))
                updatedComp.Name = changedValues[0].Trim();

            if (!changedValues[1].Trim().Equals("-"))
                updatedComp.PhoneNumber = changedValues[1].Trim();

            UpdatingAddress(context, updatedComp);

            context.Update(updatedComp);

            await context.SaveChangesAsync();
            CRUDmessages.SuccessfullyUpdated("company info");
        }


        public static async void UpdateClient(MyAppContext context)
        {
            ListEntities.ListClients([.. context.Clients.ToList().OrderBy(a => a.Name).ThenBy(x => x.Surname)], "");
            Console.WriteLine("Select the client number for updating:");

            string? response;
            string[] changedValues;

            var client = context.Clients.ToList().OrderBy(a => a.Name).ThenBy(x => x.Surname).ToList()[SelectRowNumber(context.Clients.Count())];

            Client updatedClient = await context.Clients.FindAsync(client.Id);

            while (true)
            {
                InstructionsOutput.ToCreateClient();
                CRUDmessages.ChangeCertainAttr();

                response = Console.ReadLine();
                changedValues = response.Split(",");

                if (changedValues.Length == 4) break;

                InstructionsOutput.InvalidArgs();
            }
            if (!changedValues[0].Trim().Equals("-"))
                updatedClient.Name = changedValues[0].Trim();

            if (!changedValues[1].Trim().Equals("-"))
                updatedClient.Surname = changedValues[1].Trim();

            if (!changedValues[2].Trim().Equals("-"))
                updatedClient.Nationality = changedValues[2].Trim();

            if (!changedValues[3].Trim().Equals("-"))
                updatedClient.PhoneNumber = changedValues[3].Trim();

            UpdatingAddress(context, updatedClient);

            context.Update(updatedClient);
            await context.SaveChangesAsync();

            CRUDmessages.SuccessfullyUpdated("client info");
        }


        private static async void UpdatingAddress<T>(MyAppContext context, T entity) where T : IAddressable
        {
            string? response;
            string[] changedValues;

            while (true)
            {
                Console.WriteLine("Would you also like to update the address?\nType y/n:");
                response = Console.ReadLine();

                if (response.ToLower().Equals("y") || response.ToLower().Equals("n")) break;
                InstructionsOutput.InvalidArgs();
            }

            if (response.Equals("y"))
            {
                while (true)
                {
                    InstructionsOutput.ToCreateAddress();
                    CRUDmessages.ChangeCertainAttr();

                    response = Console.ReadLine();
                    changedValues = response.Split(",");

                    if (changedValues.Length == 5) break;

                    InstructionsOutput.InvalidArgs();
                }
                Address updatedAddr = await context.Addresses.FindAsync(entity.Address.Id);

                if (!changedValues[0].Trim().Equals("-"))
                    updatedAddr.Country = changedValues[0].Trim();

                if (!changedValues[1].Trim().Equals("-"))
                    updatedAddr.City = changedValues[1].Trim();

                if (!changedValues[2].Trim().Equals("-"))
                    updatedAddr.PostalCode = changedValues[2].Trim();

                if (!changedValues[3].Trim().Equals("-"))
                    updatedAddr.Street = changedValues[3].Trim();

                if (!changedValues[4].Trim().Equals("-"))
                    updatedAddr.HouseNumber = changedValues[4].Trim();

                context.Update(updatedAddr);
                await context.SaveChangesAsync();
            }
        }


        private static int SelectRowNumber(int total)
        {
            int selectedRow;
            string? response;

            while (true)
            {
                response = Console.ReadLine();
                if (int.TryParse(response, out selectedRow) &&
                     selectedRow > 0 && selectedRow <= total) break;

                InstructionsOutput.InvalidArgs();
            }
            return selectedRow - 1;
        }
    }
}
