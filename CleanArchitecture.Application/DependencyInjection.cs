using CleanArchitecture.Application.Common.Behaviors;
using CleanArchitecture.Application.Common.Filters;
using CleanArchitecture.Application.Features.Memberships.Commands.CreateMembership;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                options.AddOpenBehavior(typeof(ValidationBehavior<,>));
                options.AddOpenBehavior(typeof(LoggingBehavior<,>));

            });

            services.AddValidatorsFromAssemblyContaining(typeof(CreateMembershipCommandValidator));

            services.AddControllers(options =>
            {
                //options.Filters.Add(new InvalidateCacheFilter());
            });

            return services;
        }
    }
}
