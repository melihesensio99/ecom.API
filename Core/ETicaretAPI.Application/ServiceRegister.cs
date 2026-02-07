using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application
{
    public static class ServiceRegister
    {
        public static void ApplicationServiceRegister(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssembly(typeof(ServiceRegister).Assembly));
        }
    }
}
