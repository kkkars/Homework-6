using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace homework6.Task3
{
    class LogInDataService
    {
        private readonly string _dataFileName;
        private List<LogInData> logData = null;

        public LogInDataService(string settingFileName)
        {
            _dataFileName = settingFileName;
        }

        public List<LogInData> GetLogData()
        {
            if (!File.Exists(_dataFileName))
            {
                throw new Exception();
            }

            var json = File.ReadAllText(_dataFileName);
            logData = JsonSerializer.Deserialize<List<LogInData>>(json);

            if (logData == null)
            {
                throw new Exception();
            }

            return logData;
        }
    }
}
