using System;
using System.Diagnostics.CodeAnalysis;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd.CrossCutting.DependencyInjection
{
    public static class MediatorServiceCollectionExtensions
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("BackEnd.Application");
            services.AddMediatR(assembly);
            return services;
        }
    }
}