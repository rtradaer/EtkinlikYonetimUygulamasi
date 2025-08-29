using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;

namespace Main.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void Configure_DbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("mssqlconnection"),
                b => b.MigrationsAssembly("Main"));
                options.EnableSensitiveDataLogging(true);
            });
        }
        public static void Configure_Services_Registration(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IEtkinlikService, EtkinlikManager>();
        }

        public static void Configure_Repository_Registration(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IEtkinlikRepository, EtkinlikRepository>();
        }

        public static void Configure_Session(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();  //session
            services.AddSession(options =>
            {
                options.Cookie.Name = "Main.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public static void Configure_Identity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
            })
            .AddEntityFrameworkStores<RepositoryContext>();
        }
    }
}
