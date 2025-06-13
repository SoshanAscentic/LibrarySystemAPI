using LibrarySystemAPI.Data.InMemoryStorage;
using LibrarySystemAPI.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAPI.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            // Register data storage as singleton to maintain state
            services.AddSingleton<DataStorage>();

            // Register repositories
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();

            return services;
        }
    }
}
