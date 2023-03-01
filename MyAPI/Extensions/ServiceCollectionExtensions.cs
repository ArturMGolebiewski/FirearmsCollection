using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAPI.Application.Common.Interfaces;
using MyAPI.Infrastructure;
using MyAPI.Infrastructure.Ammo;
using MyAPI.Infrastructure.Calibers;
using MyAPI.Infrastructure.Database;
using MyAPI.Infrastructure.Firearms;
using MyAPI.Infrastructure.FirearmTypes;
using MyAPI.Infrastructure.Manufacturers;
using MyAPI.Validators;
using System.Reflection;

namespace MyAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            var appAssembly = Assembly.Load("MyAPI.Application");
            var infrastructureAssembly = Assembly.Load("MyAPI.Infrastructure");
            services.AddMediatR(appAssembly);
            services.AddAutoMapper(infrastructureAssembly, appAssembly);
            services.AddValidatorsFromAssemblyContaining<AddManufacturerModelValidator>();
            services.AddScoped<INewManufacturerWriter, NewManufacturerWriter>();
            services.AddScoped<IManufacturersReader, ManufacturersReader>();
            services.AddScoped<INewFirearmWriter, NewFirearmWriter>();
            services.AddScoped<IFirearmsReader, FirearmsReader>();
            services.AddScoped<INewFirearmTypeWriter, NewFirearmTypeWriter>();
            services.AddScoped<IFirearmTypesReader, FirearmTypesReader>();
            services.AddScoped<INewCaliberWriter, NewCaliberWriter>();
            services.AddScoped<ICaliberReader, CaliberReader>();
            services.AddScoped<INewAmmoWriter, NewAmmoWriter>();
            services.AddScoped<IAmmoReader, AmmoReader>();
        }

        public static void RegisterDbContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<FirearmContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        }

        public static void EnsureDatabaseMigration(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var dbContext = serviceProvider.GetService<FirearmContext>();
            if (dbContext == null)
            {
                throw new InvalidOperationException("Couldn't find registered database");
            }
            dbContext.Database.Migrate();
            dbContext.Database.EnsureCreated();
        }
    }
}
