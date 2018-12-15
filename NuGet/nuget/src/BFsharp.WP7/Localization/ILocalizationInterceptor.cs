using System.Globalization;

namespace BFsharp.Localization
{
    public interface ILocalizationInterceptor
    {
        string GetString(string name, CultureInfo cultureInfo);
    }
}