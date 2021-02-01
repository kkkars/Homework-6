using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace homework6.Task2
{
    class SettingService
    {
        private readonly string settingFileName;
        private List<Setting> settings = null;

        public SettingService(string settingFileName)
        {
            this.settingFileName = settingFileName;
        }

        public List<Setting> GetSettings()
        {
            if (!File.Exists(settingFileName))
            {
                throw new Exception();
            }

            var json = File.ReadAllText(settingFileName);
            settings = JsonSerializer.Deserialize<List<Setting>>(json);

            if (settings == null)
            {
                throw new Exception();
            }

            return settings;
        }
    }
}
