using Application;
using Application.Helpers;
using Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.API.Extension
{
    public static class  ConfigurationExtension
    {
        public static IServiceCollection AddAllExtension(this IServiceCollection serviceCollection   )
        {
            serviceCollection.AddScoped<IBookApplication, BookApplication>();
            serviceCollection.AddSingleton<IData, BookData>();
            serviceCollection.AddAutoMapper(typeof(BookProfile).Assembly);
            return serviceCollection;
        }
    }
}
