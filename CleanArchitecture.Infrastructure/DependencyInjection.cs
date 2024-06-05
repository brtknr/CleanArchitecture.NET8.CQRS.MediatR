using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Infrastructure.Common.Persistence;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence();

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Data Source = CleanArchitecture.sqlite"));

            services.AddScoped<IMemberRepository,MemberRepository>();
            //services.AddScoped<IUsersRepository, UsersRepository>();
                
            return services;
        }
    }
}
