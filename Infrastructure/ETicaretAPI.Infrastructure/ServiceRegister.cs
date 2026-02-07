using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure
{
    public static class ServiceRegister
    {
        public static void InfrastructureServiceRegister(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageService>();

        }
        public static void StorageServiceType<T>(this IServiceCollection services) where T : class  , IStorage
        {

            services.AddScoped<IStorage, T>();
        }

    }
}
