using Microsoft.Extensions.DependencyInjection;
using System;

namespace AA.CommoditiesDashboard.WebAPI.Mappings.AutoMapper.Configuration
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMappingSetup(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddAutoMapper(typeof(MappingProfile).Assembly);
        }
    }
}
