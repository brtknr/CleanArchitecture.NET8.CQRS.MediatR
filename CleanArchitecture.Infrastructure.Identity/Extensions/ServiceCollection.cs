using CleanArchitecture.Application.Common.Services.Identity;
using CleanArchitecture.Infrastructure.Identity.Data;
using CleanArchitecture.Infrastructure.Identity.Models;
using CleanArchitecture.Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Identity.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddIdentityDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("GymDb"),
                    b => b.MigrationsAssembly(typeof(AppIdentityDbContext).Assembly.FullName)));

            return services;
        }

        public static IServiceCollection AddIdentityAuth(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>(options => 
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<AppIdentityDbContext>();

            return services;
                
        }

        public static IServiceCollection AddInfrastructureIdentityServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        public static void AddInfrastructureIdentityMappingProfile(this IServiceCollection services)
        {
            // not implemented

            //MapperConfiguration mappingConfig = new(mc =>
            //{
            //    mc.AddProfile(new InfrastructureIdentityProfile());
            //});

            //services.AddSingleton(mappingConfig.CreateMapper());
        }
    }
}
