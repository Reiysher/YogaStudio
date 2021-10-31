using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaStudio.Application.Interfaces;

namespace YogaStudio.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<YogaStudioDbContext>(options =>
            {
                options.UseSqlServer(connection);
            });
            services.AddScoped<IYogaStudioDbContext>(provider =>
                provider.GetRequiredService<YogaStudioDbContext>());
            //TODO: DbContext dependency like this?
            //services.AddScoped<IYogaStudioDbContext, YogaStudioDbContext>();
            return services;
        }
    }
}
