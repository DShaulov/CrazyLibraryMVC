using System.Text.Json;
using CrazyLibraryMVC.Data;

namespace CrazyLibraryMVC.Services
{
    public class DataImportService
    {
        private readonly DatabaseContext m_DbContext;
        private readonly Random m_Random = new Random();

        public DataImportService(DatabaseContext dbContext)
        {
            m_DbContext = dbContext;
        }

        public async Task ImportFromJsonFile(string filePath)
        {
            try
            {
                // Read the JSON file
                string jsonContent = await File.ReadAllTextAsync(filePath);

                using (JsonDocument doc = JsonDocument.Parse(jsonContent))
                {
                    foreach (JsonElement element in doc.RootElement.EnumerateArray())
                    {
                        await ProcessJsonEntry(element);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An exception has occured while reading the JSON file:", ex);
            }
        }

        public async Task ProcessJsonEntry(JsonElement element)
        {

        }
    }
}
