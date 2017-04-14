using Autofac;
using Shopping.DataAccess;
using Shopping.External.ApiServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using Shopping.Services.Configuration;
using Shopping.Services.Implementations;
using Shopping.Services.Interfaces;

namespace Shopping.Services.Configuration
{
    public class ModuleInstaller : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            try
            {
                builder.RegisterType<TestService>().As<ITestService>();
                builder.RegisterType<QuestionnaireService>().AsSelf();
                builder.RegisterType<UnitOfWork>().AsSelf().InstancePerLifetimeScope();

                var mapperConfiguration = new MapperConfiguration();
                mapperConfiguration.MappingRegistration();
            }
            catch (Exception)
            {                
                throw;
            }
        }

        private DbContextOptions<TContext> DbContextOptionsFactory<TContext>(
            Action<DbContextOptionsBuilder> optionsAction)
            where TContext : DbContext
        {
            var options = new DbContextOptions<TContext>(new Dictionary<Type, IDbContextOptionsExtension>());
            if (optionsAction != null)
            {
                var builder = new DbContextOptionsBuilder<TContext>(options);
                optionsAction(builder);
                options = builder.Options;
            }

            return options;
        }
    }
}
