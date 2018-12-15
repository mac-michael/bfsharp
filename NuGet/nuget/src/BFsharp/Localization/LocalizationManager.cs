using System;
using System.Globalization;
using System.Resources;

namespace BFsharp.Localization
{
    public class LocalizationManager
    {
        public static void SetLocalizationInterceptor(ILocalizationInterceptor interceptor)
        {
            Interceptor = interceptor;
        }

        protected static ILocalizationInterceptor Interceptor { get; set; }

        private const string ResourceName = 
#if NET
            "BFsharp.Localization.Strings";
#elif SILVERLIGHT
            "BFsharp.SL.Localization.Strings";
#elif PHONE
            "BFsharp.WP7.Localization.Strings";
#endif
        static readonly ResourceManager _manager = new ResourceManager(ResourceName, typeof(LocalizationManager).Assembly);

        public static string GetString(LocalizationString name)
        {
            return GetString(name.ToString(), CultureInfo.CurrentUICulture);
        }

        public static string GetString(string name, CultureInfo cultureInfo)
        {
            string value = null;
            if (Interceptor != null)
                value = Interceptor.GetString(name, cultureInfo);

            if ( value == null)
                value = _manager.GetString(name, cultureInfo);

            return value;
        }
    }
}