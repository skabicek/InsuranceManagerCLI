using FincoraConsoleAppDemo.Models;
using FincoraConsoleAppDemo.Context;

namespace FincoraConsoleAppDemo
{
    public class DataSeed
    {
        public static void AddingAddresses(MyAppContext context)
        {
            context.Addresses.AddRangeAsync
            (
                new Address() { Country = "Slovakia", City = "Bereseg",PostalCode = "92001",
                                Street = "Frobadurska", HouseNumber = "11" },

                new Address() { Country = "Czech Republic", City = "Brno",PostalCode = "60200",
                                Street = "Cejl", HouseNumber = "22" },

                new Address() { Country = "Slovakia", City = "Trnava",PostalCode = "91701",
                                Street = "Kapitalska", HouseNumber = "9" },

                new Address() { Country = "Czech Republic", City = "Brno",PostalCode = "60202",
                                Street = "Lipová", HouseNumber = "75" },

                new Address() { Country = "Slovakia", City = "Nitra",PostalCode = "94901",
                                Street = "Mostná", HouseNumber = "17" },

                new Address() { Country = "Czech Republic", City = "Ostrava",PostalCode = "70030",
                                Street = "Štúrova", HouseNumber = "65/C" },

                new Address() { Country = "Slovakia", City = "Trnava",PostalCode = "91701",
                                Street = "Hollého", HouseNumber = "19" },

                new Address() { Country = "Czech Republic", City = "Brno",PostalCode = "63900",
                                Street = "Babakova", HouseNumber = "103" },

                new Address() { Country = "Czech Republic", City = "Praha",PostalCode = "80090",
                                Street = "Václavská", HouseNumber = "44" },

                new Address() { Country = "Czech Republic", City = "Brno",PostalCode = "60204",
                                Street = "Česká", HouseNumber = "3" }
            );
            context.SaveChangesAsync();
        }


        public static void AddingClients(MyAppContext context)
        {
            var addresses = context.Addresses.ToList().OrderBy( a => a.Country ).ToList();

            context.Clients.AddRangeAsync
            (
                new Client() { Name = "Filip", Surname = "Barovsky",
                                Nationality = "Slovak", PhoneNumber = "44452456", AddressID = addresses[6].Id },

                new Client() { Name = "Jaroslav", Surname = "Novotný",
                                Nationality = "Czech", PhoneNumber = "759994", AddressID = addresses[5].Id },

                new Client() { Name = "Patrik", Surname = "Landovsky",
                                Nationality = "Slovak", PhoneNumber = "778847", AddressID = addresses[9].Id },

                new Client() { Name = "Stanislav", Surname = "Prochazka",
                                Nationality = "Slovak", PhoneNumber = "479226655", AddressID = addresses[8].Id },

                new Client() { Name = "Šimon", Surname = "Kibaks",
                                Nationality = "Slovak", PhoneNumber = "54566", AddressID = addresses[7].Id },

                new Client() { Name = "Vladislav", Surname = "Kincl",
                                Nationality = "Czech", PhoneNumber = "142437", AddressID = addresses[4].Id }
            );
            context.SaveChangesAsync();
        }


        public static void AddingContractTypes(MyAppContext context)
        {
            context.ContractTypes.AddRangeAsync
            (
                new ContractType() { Name = "Investičné životné poistenie", InvolveVehicle = 0 },

                new ContractType() { Name = "Kapitálové poistenie", InvolveVehicle = 0 },

                new ContractType() { Name = "KASKO", InvolveVehicle = 1 },

                new ContractType() { Name = "PZP", InvolveVehicle = 1 },

                new ContractType() { Name = "Úrazové poistenie", InvolveVehicle = 0 }

            );
            context.SaveChangesAsync();
        }


        public static void AddingInsuranceCompanies(MyAppContext context)
        {
            var addresses = context.Addresses.ToList().OrderBy( a => a.Country ).ToList();

            context.InsuranceCompanies.AddRangeAsync
            (
                new InsuranceCompany() { Name = "Allianz", PhoneNumber = "4002437", AddressId = addresses[0].Id },

                new InsuranceCompany() { Name = "Generali", PhoneNumber = "5664778", AddressId = addresses[1].Id },

                new InsuranceCompany() { Name = "Union", PhoneNumber = "77899402", AddressId = addresses[2].Id },

                new InsuranceCompany() { Name = "Uniqua", PhoneNumber = "9897435", AddressId = addresses[3].Id }
            );
            context.SaveChangesAsync();
        }


        public static void AddingVehicles(MyAppContext context)
        {
            context.Vehicles.AddRangeAsync
            (
                new Vehicle() { Brand = "Audi", Model = "A5", YearOfManufacture = "2016", 
                                 Price = "25000", EvidenceNumber = "7A8 6521" },

                new Vehicle() { Brand = "Audi", Model = "A7", YearOfManufacture = "2020", 
                                 Price = "35000", EvidenceNumber = "3B6 4192" },

                new Vehicle() { Brand = "Mazda", Model = "3", YearOfManufacture = "2014", 
                                 Price = "15000", EvidenceNumber = "5C1 7409" },

                new Vehicle() { Brand = "Škoda", Model = "Superb", YearOfManufacture = "2020", 
                                 Price = "20000", EvidenceNumber = "2D9 8374" }
            );
            context.SaveChangesAsync();
        }


        public static void AddingContracts(MyAppContext context)
        {
            var contractTypes =  context.ContractTypes.ToList().OrderBy( a => a.Name ).ToList();

            var insuranceCompanies = context.InsuranceCompanies.ToList().OrderBy( a => a.Name ).ToList();

            var clients = context.Clients.ToList().OrderBy( a => a.Name ).ThenBy(x => x.Surname).ToList();

            var vehicles = context.Vehicles.ToList().OrderBy( a => a.Brand).ThenBy( a => a.Model ).ToList();

            context.Contracts.AddRangeAsync
            (
                new Contract() { ContractTypeId = contractTypes[0].Id, ClientId = clients[0].Id, 
                                  InsuranceCompanyId = insuranceCompanies[0].Id },

                new Contract() { ContractTypeId = contractTypes[2].Id, ClientId = clients[1].Id, 
                                  InsuranceCompanyId = insuranceCompanies[1].Id, VehicleId = vehicles[0].Id },

                new Contract() { ContractTypeId = contractTypes[2].Id, ClientId = clients[2].Id, 
                                  InsuranceCompanyId = insuranceCompanies[2].Id, VehicleId = vehicles[1].Id },

                new Contract() { ContractTypeId = contractTypes[3].Id, ClientId = clients[3].Id, 
                                  InsuranceCompanyId = insuranceCompanies[2].Id, VehicleId = vehicles[2].Id },

                new Contract() { ContractTypeId = contractTypes[1].Id, ClientId = clients[4].Id, 
                                  InsuranceCompanyId = insuranceCompanies[3].Id },

                new Contract() { ContractTypeId = contractTypes[3].Id, ClientId = clients[5].Id, 
                                  InsuranceCompanyId = insuranceCompanies[3].Id, VehicleId = vehicles[3].Id }
            );
            context.SaveChangesAsync();
        }
    }
}
