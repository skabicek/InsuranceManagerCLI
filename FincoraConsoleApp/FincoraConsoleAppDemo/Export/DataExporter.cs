using System.Text;
using System.Text.Json;
using FincoraConsoleAppDemo.Context;

namespace FincoraConsoleAppDemo.Export
{
    public class DataExporter
    {
        public static void ExportToJson(string filePath, MyAppContext context, JsonSerializerOptions options)
        {
            switch (filePath)
            {
                case ("contracts.json"):
                    WriteText(filePath, JsonSerializer.Serialize(context.Contracts.ToList(), options));
                    break;

                case ("companies.json"):
                    WriteText(filePath, JsonSerializer.Serialize(context.InsuranceCompanies.ToList(), options));
                    break;

                case ("insuranceTypes.json"):
                    WriteText(filePath, JsonSerializer.Serialize(context.InsuranceCompanies.ToList(), options));
                    break;

                case ("clients.json"):
                    WriteText(filePath, JsonSerializer.Serialize(context.Clients.ToList(), options));
                    break;

                case ("vehicles.json"):
                    WriteText(filePath, JsonSerializer.Serialize(context.Vehicles.ToList(), options));
                    break;
            }     
        }


        public static void WriteText(string filePath, string jsonString)
        {
            File.WriteAllText("../../../JsonResults/" + filePath, jsonString, Encoding.UTF8);
        }
    }
}
