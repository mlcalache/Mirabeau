using System.Configuration;

namespace Mirabeau.Infra.CrossCutting.Helpers
{
    public static class ConfigurationManagerHelper
    {
        public static string UrlJsonAirport => ConfigurationManager.AppSettings["UrlJsonAirport"];
    }
}