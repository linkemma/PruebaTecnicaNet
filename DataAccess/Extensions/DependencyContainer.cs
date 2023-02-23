using Business;
using Business.Interfaces;
using Business.Services;
using DataAccess.Data;
using CustomerEntity = Business.Entities.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using DataAccess.Model;

namespace DataAccess.Extensions
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddServices(this IServiceCollection services,
            IConfiguration configuration)
        {

            //Agregar cadena de conexion al contexto
            services.AddDbContext<JujuTestContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Development")));

            //Servicios                      
            services.AddScoped<JujuTestContext, JujuTestContext>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerModel, CustomerModel>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPostModel, PostModel>();
            //services.AddScoped<BaseService<Post>, BaseService<Post>>();
            //services.AddScoped<BaseModel<Post>, BaseModel<Post>>();
            return services;

        }
    }
}
