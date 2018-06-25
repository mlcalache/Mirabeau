using AutoMapper;
using System;
using System.Linq;

namespace Mirabeau.API.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration CreateMapperConfiguration()
        {
            return new MapperConfiguration(p =>
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.Contains("Mirabeau."));

                p.AddProfiles(assemblies);
            });
        }
    }
}