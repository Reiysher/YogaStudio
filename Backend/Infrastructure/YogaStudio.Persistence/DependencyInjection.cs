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
            this IServiceCollection services, IConfiguration configuration)
        {
            var server = configuration["DbServer"];
            var port = configuration["DbPort"];
            var user = configuration["DbUser"];
            var password = configuration["DbPassword"];
            var database = configuration["Database"];

            var connection = $"Server={server},{port};Initial Catalog={database};User ID ={user}; Password={password}";
            services.AddDbContext<YogaStudioDbContext>(options =>
            {
                options.UseSqlServer(connection);
            });
            services.AddScoped<IYogaStudioDbContext, YogaStudioDbContext>();
            return services;
        }
    }
}
