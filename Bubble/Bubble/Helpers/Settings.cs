using Plugin.Settings;
using Plugin.Settings.Abstractions;
using SDR.Models;

namespace SDR.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string UserKey = "user_key";
        private static readonly string UserDefault = string.Empty;

        private const string UserOperatoreKey = "user_operatore_key";
        private static readonly string UserOperatoreDefault = string.Empty;

        private const string UrlKey = "url_key";
        private static readonly string UrlDefault = string.Empty;

            #endregion

        public static string UserSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserKey, UserDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserKey, value);
            }
        }

        public static string UserOperatoreSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserOperatoreKey, UserOperatoreDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserOperatoreKey, value);
            }
        }

        public static string UrlSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(UrlKey, UrlDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UrlKey, value);
            }
        }


            }
}