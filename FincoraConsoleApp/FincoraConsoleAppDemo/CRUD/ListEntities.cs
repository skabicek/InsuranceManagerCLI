using FincoraConsoleAppDemo.Context;
using FincoraConsoleAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace FincoraConsoleAppDemo.CRUD
{
    public class ListEntities
    {
        public static void ListClients(MyAppContext context)
        {
            var clients = context.Clients.ToList().OrderBy(a => a.Name).ThenBy(x => x.Surname).ToList();

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

            Console.WriteLine("List of all registred clients:");
            Console.WriteLine($"{"Name".PadRight(longestNameLen)} | {"Surname".PadRight(longestSurnameLen)} | " +
                               $"{"Nationality".PadRight(longestNationalityLen)} | {"Phone".PadRight(longestPhoneLen)}\n");

            for (int i = 0; i < clients.Count; i++)
            {
                Console.WriteLine($"{i}: {clients[i].Name.PadRight(longestNameLen)} | {clients[i].Name.PadRight(longestSurnameLen)} | " +
                                   $"{clients[i].Nationality.PadRight(longestNationalityLen)} | {clients[i].PhoneNumber.PadRight(longestPhoneLen)}");
            }
        }


        public static void ListInsCompanies(MyAppContext context)
        {
            var insCompanies = context.InsuranceCompanies.ToList().OrderBy(a => a.Name).ToList();

            int longestNameLen = insCompanies.Select(x => x.Name)
                                             .OrderBy(name => name.Length * -1)
                                             .First().Length;

            int longestPhoneLen = insCompanies.Select(x => x.PhoneNumber)
                                              .OrderBy(phone => phone.Length * -1)
                                              .First().Length;

            Console.WriteLine("List of all registred companies:");
            Console.WriteLine($"{"Name".PadRight(longestNameLen)} | {"Phone".PadRight(longestPhoneLen)}\n");

            for (int i = 0; i < insCompanies.Count; i++)
            {
                Console.WriteLine($"{i}: {insCompanies[i].Name.PadRight(longestNameLen)} | {insCompanies[i].PhoneNumber.PadRight(longestPhoneLen)}");
            }
        }
    }
}
