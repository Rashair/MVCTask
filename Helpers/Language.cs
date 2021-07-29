using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;

namespace MVCTask.Helpers
{
    public static class Language
    {
        public const string Key = "Language";

        public const string plPL = "pl-PL";
        public const string enGB = "en-GB";

        public static void ChangeThreadCulture(string cultureInfoName)
        {
            var culture = TryCreateCulture(cultureInfoName);
            if (culture == null)
                return;

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = TryCreateCulture(cultureInfoName);
        }

        public static CultureInfo TryCreateCulture(string language)
        {
            try
            {
                return CultureInfo.CreateSpecificCulture(language);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}