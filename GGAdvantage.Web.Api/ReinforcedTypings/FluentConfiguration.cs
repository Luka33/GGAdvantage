using GGAdvantage.Application.Models;
using Reinforced.Typings.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GGAdvantage.Web.Api.ReinforcedTypings
{
    public static class FluentConfiguration
    {
        public const string SOLUTION_NAMESPACE = "GGAdvantage";
        public static readonly string BASE_DTO = $"{SOLUTION_NAMESPACE}.Application.Models.BaseDto";

        public static void Configure(ConfigurationBuilder builder)
        {
            builder.Global(i => i.UseModules());

            builder.ConfigureTypes();
        }

        private static void ConfigureTypes(this ConfigurationBuilder builder)
        {
            builder.ConfigureAsClass(
                Assembly.GetAssembly(typeof(BaseDto)).ExportedTypes.Where(_ => _.Namespace.StartsWith($"{SOLUTION_NAMESPACE}.Application.Models")).ToArray()    
            );
        }

        private static void ConfigureAsClass(this ConfigurationBuilder builder, Type[] types)
        {
            if (types.GetLength(0) == 0)
                return;

            builder
                .ExportAsClasses(
                    types,
                    conf => conf
                    .FlattenHierarchy()
                    .WithPublicProperties(p => p.CamelCase())
                    .WithProperties(i => i.PropertyType == typeof(DateTime), i => i.Type("Date"))
                    .WithProperties(i => i.PropertyType == typeof(DateTime?), i => i.Type("Date | null"))
                    .WithProperties(i => i.PropertyType == typeof(Guid) || i.PropertyType == typeof(Guid?), i => i.Type("string"))
                    .ExportTo("models.ts")
                );
        }
    }
}
