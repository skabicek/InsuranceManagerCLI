using FincoraConsoleAppDemo.Models;

namespace FincoraConsoleAppDemo.CRUD
{
    public class ListEntities
    {
        public static void ListClients(List<Client> clients, string message)
        {
            //var clients = context.Clients.ToList().OrderBy(a => a.Name).ThenBy(x => x.Surname).ToList();

            if (clients.Count == 0)
            {
                Console.WriteLine("No clients were found");
                return;
            }

            int longestNameLen = clients.Select(x => x.Name)
                                        .OrderBy(name => name.Length * -1)
                                        .First().Length;

            int longestSurnameLen = clients.Select(x => x.Surname)
                                           .OrderBy(surname => surname.Length * -1)
                                           .First().Length;

            int longestNationalityLen = clients.Select(x => x.Nationality)
                                               .OrderBy(nat => nat.Length * -1)
                                               .First().Length;

            int longestPhoneLen = clients.Select(x => x.PhoneNumber)
                                         .OrderBy(phone => phone.Length * -1)
                                         .First().Length;

            int longestAddressLen = clients.Select(x => x.Address.Street + " " + x.Address.HouseNumber + ", " + x.Address.PostalCode + " "
                                                         + x.Address.City + ", " + x.Address.Country)
                                           .OrderBy(phone => phone.Length * -1)
                                           .First().Length;

            longestNameLen = "Name".Length > longestNameLen ? "Name".Length : longestNameLen;
            longestSurnameLen = "Surname".Length > longestSurnameLen ? "Surname".Length : longestSurnameLen;
            longestPhoneLen = "Phone".Length > longestPhoneLen ? "Phone".Length : longestPhoneLen;
            longestNationalityLen = "Nationality".Length > longestNationalityLen ? "Nationality".Length : longestNationalityLen;

            Console.WriteLine($"List of all registred clients{message}:\n");
            Console.WriteLine($"{"   Name".PadRight(longestNameLen + 3)} | {"Surname".PadRight(longestSurnameLen)} | " +
                               $"{"Nationality".PadRight(longestNationalityLen > "Nationality".Length ? longestNationalityLen : "Nationality".Length)} " +
                                $"| {"Phone".PadRight(longestPhoneLen)} | {"Address".PadRight(longestAddressLen)}\n");

            for (int i = 0; i < clients.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {clients[i].Name.PadRight(longestNameLen)} | {clients[i].Surname.PadRight(longestSurnameLen)} | " +
                                   $"{clients[i].Nationality.PadRight(longestNationalityLen)} | {clients[i].PhoneNumber.PadRight(longestPhoneLen)} | "
                                    + $"{clients[i].Address.Street + " " + clients[i].Address.HouseNumber + ", "
                                    + clients[i].Address.PostalCode + " " + clients[i].Address.City + ", " + clients[i].Address.Country}");
            }
        }


        public static void ListInsCompanies(List<InsuranceCompany> insCompanies, string message)
        {
            //var insCompanies = context.InsuranceCompanies.ToList().OrderBy(a => a.Name).ToList();

            if (insCompanies.Count == 0)
            {
                Console.WriteLine("No insurance companies were found");
                return;
            }

            int longestNameLen = insCompanies.Select(x => x.Name)
                                             .OrderBy(name => name.Length * -1)
                                             .First().Length;

            int longestPhoneLen = insCompanies.Select(x => x.PhoneNumber)
                                              .OrderBy(phone => phone.Length * -1)
                                              .First().Length;

            int longestAddressLen = insCompanies.Select(x => x.Address.Street + " " + x.Address.HouseNumber + ", " + x.Address.PostalCode + " " 
                                                         + x.Address.City + ", " + x.Address.Country)
                                                .OrderBy(phone => phone.Length * -1)
                                                .First().Length;

            longestNameLen = "Name".Length > longestNameLen ? "Name".Length : longestNameLen;

            Console.WriteLine($"List of all registred companies{message}:\n");
            Console.WriteLine($"{"   Name".PadRight(longestNameLen + 3)} | {"Phone".PadRight(longestPhoneLen)} | {"Address".PadRight(longestAddressLen)}\n");

            for (int i = 0; i < insCompanies.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {insCompanies[i].Name.PadRight(longestNameLen)} | " +
                                   $"{insCompanies[i].PhoneNumber.PadRight(longestPhoneLen)} | " +
                                    $"{insCompanies[i].Address.Street + " " + insCompanies[i].Address.HouseNumber + ", " 
                                    + insCompanies[i].Address.PostalCode + " " + insCompanies[i].Address.City + ", " + insCompanies[i].Address.Country}");
            }
        }


        public static void ListInsTypes(List<ContractType> contractTypes)
        {
            //var contractTypes = context.ContractTypes.ToList().OrderBy(a => a.Name).ToList();

            if (contractTypes.Count == 0)
            {
                Console.WriteLine("No insurance types were found.");
                return;
            }

            int longestNameLen = contractTypes.Select(x => x.Name)
                                              .OrderBy(name => name.Length * -1)
                                              .First().Length;

            Console.WriteLine("List of all registred insurance types:\n");
            Console.WriteLine($"{"   Name".PadRight(longestNameLen + 3)} | {"Involves vehicle"}\n");

            for (int i = 0; i < contractTypes.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {contractTypes[i].Name.PadRight(longestNameLen)} | {contractTypes[i].InvolveVehicle}");
            }
        }


        public static void ListContracts(List<Contract> contracts, string message)
        {
            //var contracts = context.Contracts.ToList().OrderBy(a => a.SignDate).ToList();

            if (contracts.Count == 0)
            {
                Console.WriteLine("No contracts were found.");
                return;
            }

            int longestNameLen = contracts.Select(x => x.Client.Name)
                                          .OrderBy(name => name.Length * -1)
                                          .First().Length;

            int longestSurnameLen = contracts.Select(x => x.Client.Surname)
                                             .OrderBy(surname => surname.Length * -1)
                                             .First().Length;

            int longestInsCompLen = contracts.Select(x => x.InsuranceCompany.Name)
                                             .OrderBy(name => name.Length * -1)
                                             .First().Length;

            int longestInsTypeLen = contracts.Select(x => x.ContractType.Name)
                                             .OrderBy(name => name.Length * -1)
                                             .First().Length;

            var ecvList = contracts.Where(x => x.Vehicle != null)
                                   .Select(x => x.Vehicle.EvidenceNumber)
                                   .OrderBy(name => name.Length * -1)
                                   .ToList();

            int longestVehicleEcvLen = ecvList.Count > 0 ? ecvList.First().Length : 4;

            var vehList = contracts.Where(x => x.Vehicle != null)
                                   .Select(x => x.Vehicle.Brand + " " + x.Vehicle.Model)
                                   .OrderBy(name => name.Length * -1)
                                   .ToList();

            int longestVehicleNameLen = vehList.Count > 0 ? vehList.First().Length : 7;

            longestNameLen = "Name".Length > longestNameLen ? "Name".Length : longestNameLen;
            longestSurnameLen = "Surname".Length > longestSurnameLen ? "Surname".Length : longestSurnameLen;
            longestInsCompLen = "Company".Length > longestInsCompLen ? "Company".Length : longestInsCompLen;
            longestInsTypeLen = "Ins Type".Length > longestInsTypeLen ? "Ins Type".Length : longestInsTypeLen;
            longestVehicleNameLen = "Vehicle".Length > longestVehicleNameLen ? "Vehicle".Length : longestVehicleNameLen;

            Console.WriteLine($"List of all contracts:{message}\n");
            Console.WriteLine($"{"   Name".PadRight(longestNameLen + 3)} | {"Surname".PadRight(longestSurnameLen)} | " +
                               $"{"Ins Type".PadRight(longestInsTypeLen)} | {"Company".PadRight(longestInsCompLen)} | " +
                                $"{"Vehicle".PadRight(longestVehicleNameLen)} | {"ECV".PadRight(longestVehicleEcvLen)} | " +
                                 $"{"Sign date",-11} | {"Status",-8}\n");

            for (int i = 0; i < contracts.Count; i++)
            {
                string vehicleName = contracts[i].Vehicle != null ?
                         (contracts[i].Vehicle.Brand + " " + contracts[i].Vehicle.Model) : "null";

                string vehicleEcv = contracts[i].Vehicle?.EvidenceNumber ?? "null";

                Console.WriteLine($"{i + 1}: {contracts[i].Client.Name.PadRight(longestNameLen)} | " +
                                   $"{contracts[i].Client.Surname.PadRight(longestSurnameLen)} | " +
                                    $"{contracts[i].ContractType.Name.PadRight(longestInsTypeLen)} | " +
                                     $"{contracts[i].InsuranceCompany.Name.PadRight(longestInsCompLen)} | " +
                                      $"{vehicleName.PadRight(longestVehicleNameLen)} | " +
                                       $"{vehicleEcv.PadRight(longestVehicleEcvLen)} | " +
                                        $"{contracts[i].SignDate, -11} | {contracts[i].Status}");
            } 
        }


        public static void ListVehicles(List<Vehicle> vehicles)
        {
            //var vehicles = context.Vehicles.ToList().OrderBy(a => a.Brand).ThenBy(a => a.Model).ToList();

            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles were found.");
                return;
            }

            int longestVehicleEcvLen = vehicles.Select(x => x.EvidenceNumber)
                                               .OrderBy(name => name.Length * -1)
                                               .First().Length;

            int longestVehicleNameLen = vehicles.Select(x => x.Brand + " " + x.Model)
                                                .OrderBy(name => name.Length * -1)
                                                .First().Length;

            int longestOwnerNameLen = vehicles.Select(x => x.Contracts.Where(y => y.VehicleId == x.Id).First().Client.Name)
                                         .OrderBy(name => name.Length * -1)
                                         .First().Length;

            int longestOwnerSurnameLen = vehicles.Select(x => x.Contracts.Where(y => y.VehicleId == x.Id).First().Client.Surname)
                                            .OrderBy(surname => surname.Length * -1)
                                            .First().Length;

            Console.WriteLine("List of all registred vehicles:\n");
            Console.WriteLine($"{"   Vehicle".PadRight(longestVehicleNameLen + 3)} | {"ECV".PadRight(longestVehicleEcvLen)} | " +
                               $"{"Year",-4} | {"Price", -10} | " +
                                $"{"Owner".PadRight(longestOwnerNameLen + longestOwnerSurnameLen + 1)}\n");

            for (int i = 0; i < vehicles.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {(vehicles[i].Brand + " " + vehicles[i].Model).PadRight(longestVehicleNameLen)} | " +
                                   $"{vehicles[i].EvidenceNumber.PadRight(longestVehicleEcvLen)} | " +
                                    $"{vehicles[i].YearOfManufacture,-4} | " +
                                     $"{vehicles[i].Price + " \u20AC",-10} | " +
                                      $"{(vehicles[i].Contracts.Where(y => y.VehicleId == vehicles[i].Id).First().Client.Name + " " 
                                      + vehicles[i].Contracts.Where(y => y.VehicleId == vehicles[i].Id).First().Client.Surname).PadRight(longestVehicleNameLen)}");
            }
        }
    }
}
