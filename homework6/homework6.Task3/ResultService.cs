using System.IO;
using System.Text.Json;

namespace homework6.Task3
{
    class ResultService
    {
        private readonly string _resultFileName;

        public ResultService(string resultFileName)
        {
            _resultFileName = resultFileName;
        }

        public void WriteResultIntoFile(Result result)
        {
            if (!File.Exists(_resultFileName))
            {
                File.Create(_resultFileName).Close();
            }
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var json = JsonSerializer.Serialize(result, options);
            File.WriteAllText(_resultFileName, json);
        }
    }
}
