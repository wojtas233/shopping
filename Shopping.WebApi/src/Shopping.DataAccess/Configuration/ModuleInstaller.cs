using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using Shopping.DataAccess.Repositories;
using Shopping.DataAccess.Repositories.Interfaces;

namespace Shopping.DataAccess.Configuration
{
    public class ModuleInstaller : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            try
            {
                builder.RegisterType<SystemParameterRepository>().As<ISystemParameterRepository>();
            }
            catch (Exception)
            {                
                throw;
            }
        }       
    }
}
