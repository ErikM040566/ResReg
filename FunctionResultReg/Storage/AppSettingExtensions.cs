using System.ComponentModel;
using System.Configuration;
using System.Globalization;

namespace ResultReg.Storage
{
    public static class AppSettingExtensions
    {
        public static string GetAppSetting(this string value) => ConfigurationManager.AppSettings[value];

        public static string GetAppSetting(this string value, string defaultValue)
        {
            var setting = GetAppSetting(value);
            return setting.IsNullOrWhiteSpace() ? defaultValue : setting;
        }

        public static T GetAppSetting<T>(this string value)
        {
            return GetAppSetting<T>(value, default);
        }

        public static T GetAppSetting<T>(this string value, T defaultValue)
        {
            var setting = GetAppSetting(value);
            var converter = TypeDescriptor.GetConverter(typeof(T));
            return setting.IsNullOrWhiteSpace() ? defaultValue : (T)converter.ConvertFrom(null, CultureInfo.InvariantCulture, setting);
        }
    }
}
