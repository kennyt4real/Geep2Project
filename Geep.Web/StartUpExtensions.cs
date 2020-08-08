using Geep.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geep.Web
{
    public static class StartUpExtensions
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            #region[Reading PasswordGenSetting from appsetting.json]
            services.Configure<PasswordGenSetting>(configuration.GetSection("PasswordGenParam"));
            #endregion

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddMvc()
                 .AddJsonOptions(o =>
                 {
                     o.JsonSerializerOptions.PropertyNamingPolicy = null;
                     o.JsonSerializerOptions.DictionaryKeyPolicy = null;
                 });

            services.AddControllersWithViews();

            services.AddRazorPages();
           
            services.AddControllers();
            services.AddMemoryCache();

            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy",
                builder =>
                {
                    builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
                });
            });


            //services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
            //services.AddResponseCompression();


            return services;

        }
    }
}
