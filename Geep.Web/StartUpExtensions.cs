using AutoMapper;
using Geep.DataAccess.CommandQuery;
using Geep.DataAccess.Concrete;
using Geep.DomainLayer;
using Geep.DomainLayer.CustomAbstrations;
using Geep.DomainLayer.GeneralAbstractions;
using Geep.DomainLayer.Mapper;
using Geep.ViewModels;
using Geep.ViewModels.CoreVm;
using Geep.Web.Services;
using Hangfire;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace Geep.Web
{
    public static class StartUpExtensions
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            #region[Reading PasswordGenSetting from appsetting.json]
            services.Configure<PasswordGenSetting>(configuration.GetSection("PasswordGenParam"));
            #endregion
            services.AddSingleton<IEmailSender>(x => new EmailSender(configuration.GetValue<string>("SenGridApiKey:ApiKey")));


            services.AddScoped(typeof(IPasswordGenerator), typeof(PasswordGenerator));
            services.AddScoped(typeof(IRepo<>), typeof(Repo<>));
            services.AddScoped(typeof(IUserContext), typeof(UserContext));
            services.AddScoped(typeof(ICrudInteger<AgentVm>), typeof(AgentCQ));
            services.AddScoped(typeof(ICrudInteger<AgentClusterLocationVm>), typeof(AgentClusterLocationCQ));
            services.AddScoped(typeof(ICrudInteger<AssociationVm>), typeof(AssociationCQ));
            services.AddScoped(typeof(ICrudInteger<AssociationBeneficiaryVm>), typeof(AssociationBeneficiaryCQ));
            services.AddScoped(typeof(ICrudInteger<BeneficiaryVm>), typeof(BeneficiaryCQ));
            services.AddScoped(typeof(ICrudInteger<ClusterLocationVm>), typeof(ClusterLocationCQ));
            services.AddScoped(typeof(ICrudInteger<LocalGovernmentAreaVm>), typeof(LocalGovernmentAreaCQ));
            services.AddScoped(typeof(IEntitiesManagement), typeof(EntitiesManagement));
            services.AddScoped(typeof(ICrudInteger<StateVm>), typeof(StateCQ));
            services.AddScoped(typeof(ICrudInteger<DocumentVm>), typeof(DocumentCQ));

            services.AddHttpContextAccessor();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);


            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                { 
                    Title = "GEEP2 Dashboard", 
                    Version = "v1" 
                });
                //c.SchemaFilter<SchemaFilter>();
                //c.OperationFilter<HeaderFilter>();
            });

            // Add the processing server as IHostedService
            services.AddHangfireServer();

            services.AddSwaggerGenNewtonsoftSupport();

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

            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);


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

            services.AddAuthentication();

            //services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
            //services.AddResponseCompression();


            return services;

        }
    }
}
