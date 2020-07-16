using System;
using System.Linq;
using System.Configuration;

namespace AutomationTests.StepDefinitions
{
    public sealed class AppSettings
    {
        private readonly KeyValueConfigurationCollection appSettings;
        private static readonly Lazy<AppSettings> lazy =
            new Lazy<AppSettings>(() => new AppSettings());
        public static AppSettings Instance { get { return lazy.Value; } }
        private AppSettings()
        {
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = "App.config"
            };

            // Get the mapped configuration file
            var mappedConfig = 
                ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
            appSettings = mappedConfig.AppSettings.Settings;
        }

        public string GetConfigValue(string configKey)
        {
            return appSettings[configKey].Value;
        }
    }
}
