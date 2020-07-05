using System;
using KodluyoruzBootcampEFCore.Repository;
using KodluyoruzBootcampEFCore.Services;
using KodluyoruzBootcampEFCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KodluyoruzBootcampEFCore.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomizedDataStore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BloggingContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("IntegrationConnection"));
            });
            return services;
        }

        public static IServiceCollection InjectApplicationServices(this IServiceCollection services)
        {
            //infrastructure
            services.AddScoped(typeof(IRepository<>), typeof(Repository<,>));

            //helper service
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            //repository, service
            //services.AddScoped<IProductService, ProductService>();

            services.AddScoped(typeof(IGeneralService<Post>), typeof(PostService));


            return services;
        }

        //public static IServiceCollection CookiePoliciyServices(this IServiceCollection services)
        //{
        //    services.Configure<CookiePolicyOptions>(options =>
        //    {
        //        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        //        options.CheckConsentNeeded = context => true;
        //        options.MinimumSameSitePolicy = SameSiteMode.None;
        //    });
        //    return services;
        //}
    }
}
