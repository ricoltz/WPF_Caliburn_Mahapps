using System.Reflection;
using WPFLocalizeExtension.Extensions;

namespace WPF_Caliburn_Mahapps.Services
{
    public static class LocalizationProvider
    {
        public static T GetLocalizedValue<T>(string key)
        {
            return LocExtension.GetLocalizedValue<T>(Assembly.GetCallingAssembly().GetName().Name + ":Resources:" + key);
        }
    }
}
