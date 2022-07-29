using ColossalFramework.Globalization;
using System;
using System.Reflection;
using System.Resources;

namespace ExtendedGameOptions
{
    public static class Locale
    {
        private static string[] availableLanguages = { "en", "ru", "ja" };
        private static string selectedLanguage;
        private static ResourceManager rm;

        public static string Text(string key)
        {
            string currentLanguage = LocaleManager.instance.language;

            if (selectedLanguage != currentLanguage)
            {
                selectedLanguage = currentLanguage;

                if (Array.IndexOf(availableLanguages, selectedLanguage) == -1)
                {
                    rm = new ResourceManager("ExtendedGameOptions.localize.en", Assembly.GetExecutingAssembly());
                }
                else
                {
                    rm = new ResourceManager("ExtendedGameOptions.localize." + selectedLanguage, Assembly.GetExecutingAssembly());
                }
            }

            return rm.GetString(key);
        }
    }
}
