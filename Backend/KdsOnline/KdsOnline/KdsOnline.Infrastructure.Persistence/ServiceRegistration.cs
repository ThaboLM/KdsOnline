using KdsOnline.Application.Interfaces;
using KdsOnline.Application.Interfaces.Repositories;
using KdsOnline.Infrastructure.Persistence.Contexts;
using KdsOnline.Infrastructure.Persistence.Repositories;
using KdsOnline.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KdsOnline.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IProductRepositoryAsync, ProductRepositoryAsync>();
            services.AddTransient<IPersonalDetailRepositoryAsync, PersonalDetailRepositoryAsync>();
            services.AddTransient<IContactRepositoryAsync, ContactRepositoryAsync>();
            services.AddTransient<IAddressRepositoryAsync, AddressRepositoryAsync>();
            #endregion
        }
    }
}
