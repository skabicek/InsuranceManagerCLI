using Microsoft.EntityFrameworkCore;
using FincoraConsoleAppDemo.Models;

namespace FincoraConsoleAppDemo.Context
{
    public class DataSeeding
    {
        public static void AddingAddresses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(

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
                                Street = "Babakova", HouseNumber = "103" }
            );
        }
    }
}
