using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunchCode
{
    public static class SettingManager
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static bool IsNameSet => AppSettings.Contains(nameof(Name));

        public static bool IsPinSet => AppSettings.Contains(nameof(Pin));

        public static string Name
        {
            get => AppSettings.GetValueOrDefault(nameof(Name), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Name), value);
        }

        public static int Pin
        {
            get => AppSettings.GetValueOrDefault(nameof(Pin), 0);
            set => AppSettings.AddOrUpdateValue(nameof(Pin), value);
        }
    }
}
