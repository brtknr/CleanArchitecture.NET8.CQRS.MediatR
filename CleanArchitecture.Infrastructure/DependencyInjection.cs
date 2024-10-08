﻿using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Services;
using CleanArchitecture.Infrastructure.Common.Persistence;
using CleanArchitecture.Infrastructure.Common.RabbitMQ;
using CleanArchitecture.Infrastructure.Common.RabbitMQ.Configuration;
using CleanArchitecture.Infrastructure.Common.RabbitMQ.Conversion;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
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
            services.AddPersistence(configuration);
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });

            services.AddScoped<IRabbitMQService, RabbitMQService>();
            services.AddScoped<IRabbitMQConfiguration, RabbitMQConfiguration>();
            services.AddScoped<IObjectConvertFormat, ObjectConvertFormat>();
            services.AddScoped<IPublisherService, PublisherService>();

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("GymDb"))
                );
            
            services.AddScoped<IMembershipRepository, MembershipRepository>();
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<IWorkoutRepository, WorkoutRepository>();
            services.AddScoped<IPlanRepository, PlanRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<ICacheService, CacheService>();
            
            return services;
        }
    }
}
