using OMSServiceMaxi.Data.Access.Maps;
using OMSServiceMaxi.Data.Access.Maps.Main;
using System.Reflection;

namespace OMSServiceMaxi.Data.Access.Helpers
{
    public static class MappingsHelper
    {
        public static IEnumerable<IMap> GetMainMappings()
        {
            // типы сборки - 
            var assemblyTypes = typeof(UserMap).GetTypeInfo().Assembly.DefinedTypes; 
            var mappings = assemblyTypes
                // ReSharper disable once AssignNullToNotNullAttribute
                .Where(t => t.Namespace != null && t.Namespace.Contains(typeof(UserMap).Namespace))
                .Where(t => typeof(IMap).GetTypeInfo().IsAssignableFrom(t));
            mappings = mappings.Where(x => !x.IsAbstract);
            return mappings.Select(m => (IMap)Activator.CreateInstance(m.AsType())).ToArray();
        }
    }
}