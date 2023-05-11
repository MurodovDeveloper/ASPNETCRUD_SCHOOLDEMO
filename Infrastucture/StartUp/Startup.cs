using Application.Abstraction;
using Infrastucture.DataAcces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.StartUp
{
    public static class Startup
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Connectionstring")));
            service.AddScoped<IApplicationDbContext, AppDbContext>();
            return service;
        }
    }
}
