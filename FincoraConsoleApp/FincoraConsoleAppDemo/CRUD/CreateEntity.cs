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
        public static void CreateNewClient(MyAppContext context)
        {
            Console.WriteLine("For creating the new client, it is necessary to create his address firstly." +
                "\n Type Country, City, Postal Code, Street and House Number use \";\" as delimiter:");

            string addressResponse = Console.ReadLine();

            string[] AdrIntoList = addressResponse.Split(";");

            var adrressToBeAdded = new Address()
            { 
                Country = AdrIntoList[0].Trim(), City = AdrIntoList[1].Trim(), PostalCode = AdrIntoList[2].Trim(), 
                 Street = AdrIntoList[3].Trim(), HouseNumber = AdrIntoList[4].Trim()
            };

            context.AddAsync(adrressToBeAdded);
            context.SaveChangesAsync();

            Console.WriteLine("Now we can proceed to creating the new client.\n Type Name, Surname, Degree (N for none), Nationality and Phone Number " +
                "use \";\" as delimiter:");

            string clientResponse = Console.ReadLine();

            string[] CliIntoList = clientResponse.Split(";");

            var clientToBeAdded = new Client()
            {
                Name = CliIntoList[0].Trim(), Surname = CliIntoList[1].Trim(), Degree = CliIntoList[2].Trim(), 
                 Nationality = CliIntoList[3].Trim(), PhoneNumber = CliIntoList[4].Trim(), AddressID = adrressToBeAdded.Id
            };
            context.AddAsync(clientToBeAdded);
            context.SaveChangesAsync();


            Console.WriteLine($"foltanova {context.Addresses.Where(x => x.Id == clientToBeAdded.AddressID).First().City}");
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

                InstructionsOutput.InvalidArgsAmount();
            }

            var adrressToBeAdded = new Address()
            {
                Country = adrToList[0].Trim(),
                City = adrToList[1].Trim(),
                PostalCode = adrToList[2].Trim(),
                Street = adrToList[3].Trim(),
                HouseNumber = adrToList[4].Trim()
            };

            context.AddAsync(adrressToBeAdded);
            context.SaveChangesAsync();

            CRUDmessages.AddressCreated();
            return adrressToBeAdded;
        }


        public static void CreateNewInsCompany(MyAppContext context)
        {
            CRUDmessages.CreateAddress();

            var corespondingAddress = CreateNewAddress(context);

            string companyResponse;
            string[] companyToList;

            while (true)
            {
                InstructionsOutput.ToCreateCompany();

                companyResponse = Console.ReadLine();
                companyToList = companyResponse.Split(",");

                if (companyToList.Length == 2) break;

                InstructionsOutput.InvalidArgsAmount();
            }

            var companyToBeAdded = new InsuranceCompany()
            {
                Name = companyToList[0].Trim(), 
                PhoneNumber = companyToList[1].Trim(),
                AddressId = corespondingAddress.Id
            };

            context.AddAsync(companyToBeAdded);
            context.SaveChangesAsync();

            CRUDmessages.CompanyCreated();
        }
    }
}
