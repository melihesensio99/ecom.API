using ETicaretAPI.Application.Abstractions.Token;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.CustomerRepository;
using ETicaretAPI.Application.Repositories.FileRepository;
using ETicaretAPI.Application.Repositories.InvoiceFileRepository;
using ETicaretAPI.Application.Repositories.OrderRepository;
using ETicaretAPI.Application.Repositories.ProductImageFileRepository;
using ETicaretAPI.Application.Repositories.ProductRepository;
using ETicaretAPI.Domain.Entities.Identity;
using ETicaretAPI.Persistence.Contexts;
using ETicaretAPI.Persistence.Repositories;
using ETicaretAPI.Persistence.Repositories.InvoceFile;
using ETicaretAPI.Persistence.Repositories.ProductImageFile;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ETicaretAPIDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ETicaretAPIDbContext>();
            
            

            services.AddScoped<IWriteCustomerRepository, WriteCustomerRepository>();
            services.AddScoped<IReadCustomerRepository, ReadCustomerRepository>();
            services.AddScoped<IWriteOrderRepository, WriteOrderRepository>();
            services.AddScoped<IReadOrderRepository, ReadOrderRepository>();
            services.AddScoped<IWriteProductRepository, WriteProductRepository>();
            services.AddScoped<IReadProductRepository, ReadProductRepository>();
            services.AddScoped<IReadProductImageFileRepostiroy, ReadProductImageFileRepository>();
            services.AddScoped<IReadFileRepository, ReadFileRepository>();
            services.AddScoped<IReadInvoiceFileRepository, ReadInvoiceFileRepository>();
            services.AddScoped<IWriteProductImageFileRepository, WriteProductImageFileRepository>();
            services.AddScoped<IWriteFileRepository, WriteFileRepository>();
            services.AddScoped<IWriteInvoiceFileRepository, WriteInvoiceFileRepository>();
            
            return services;
        }
    }
}
