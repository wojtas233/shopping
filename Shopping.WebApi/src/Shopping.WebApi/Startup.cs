using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shopping.DataAccess;
using Microsoft.EntityFrameworkCore;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using NLog.Extensions.Logging;
using NLog.Web;
using Shopping.WebApi.Configuration;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Shopping.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            env.ConfigureNLog("nlog.config");
                       
        }

        public IContainer ApplicationContainer { get; private set; }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {           
            ILoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddNLog();

            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            //corsBuilder.WithOrigins("http://localhost:4200"); 
            corsBuilder.AllowAnyOrigin();
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });

            // Add framework services.          
            services.AddMvc(
            config =>
            {            
                config.Filters.Add(new ExceptionFilterLogger(loggerFactory));                
            });

            services.AddDbContext<DataContext>(options => options.UseNpgsql(Configuration.GetConnectionString(
                    "DefaultConnection")));

            //services.Configure<ExternalApi>(Configuration.GetSection("ExternalApi"));

            return ConfigureAutofac(services);           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("fr")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),                
                SupportedCultures = supportedCultures,                
                SupportedUICultures = supportedCultures
            });

            
            loggerFactory.AddNLog();
            app.UseCors("SiteCorsPolicy");
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = "https://localhost:44386",                
                AllowedScopes = { "shopping_api" },
            });
           
            app.UseMvc();
            
            DataInitializer.Initialize(this.ApplicationContainer);
        }

        public IServiceProvider ConfigureAutofac(IServiceCollection services)
        {
            // Create the container builder.
            var builder = new ContainerBuilder();

            builder.RegisterModule(new Services.Configuration.ModuleInstaller());
            builder.RegisterModule(new DataAccess.Configuration.ModuleInstaller());
            builder.RegisterModule(new Common.Configuration.ModuleInstaller());

            builder.Populate(services);
            this.ApplicationContainer = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);
        }
    }
}
