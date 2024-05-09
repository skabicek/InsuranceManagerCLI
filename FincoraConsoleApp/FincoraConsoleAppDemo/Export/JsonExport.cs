using FincoraConsoleAppDemo.Context;
using System.Text.Json;

namespace FincoraConsoleAppDemo.Export
{
    public class JsonExport
    {
        public static async void ExportJSON(MyAppContext context, string entityType)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };

            Console.WriteLine($"Extraction of the data has begun. Result file can be found in JsonResults folder.");

            switch (entityType)
            {
                case "cont":
                    await Task.Run(() => DataExporter.ExportToJson("contracts.json", context, options));
                    break;

                case "comp":
                    await Task.Run(() => DataExporter.ExportToJson("companies.json", context, options));
                    break;

                case "type":
                    await Task.Run(() => DataExporter.ExportToJson("insuranceTypes.json", context, options));
                    break;

                case "cli":
                    await Task.Run(() => DataExporter.ExportToJson("clients.json", context, options));
                    break;

                case "veh":
                    await Task.Run(() => DataExporter.ExportToJson("vehicles.json", context, options));
                    break;
            }
        }
    }
}
