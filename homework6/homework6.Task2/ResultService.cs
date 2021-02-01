using System.IO;
using System.Text.Json;

namespace homework6.Task2
{
    class ResultService
    {
        private readonly string resultFileName;

        public ResultService(string resultFileName)
        {
            this.resultFileName = resultFileName;
        }

        public void WriteResultIntoFile(Result result)
        {
            if (!File.Exists(resultFileName))
            {
                File.Create(resultFileName).Close();
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var json = JsonSerializer.Serialize(result, options);
            File.WriteAllText(resultFileName, json);
        }
    }
}
