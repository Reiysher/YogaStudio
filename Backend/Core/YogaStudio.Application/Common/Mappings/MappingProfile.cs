using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile(Assembly assembly)
        {
            ApplyMappings(assembly);
        }

        private void ApplyMappings(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces()
                    .Any(i => i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();

            foreach(var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodinfo = type.GetMethod("Mapping");
                methodinfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
