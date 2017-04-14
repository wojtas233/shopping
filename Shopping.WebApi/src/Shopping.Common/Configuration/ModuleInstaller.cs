using Autofac;
using Shopping.Common.Implementations;
using Shopping.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Common.Configuration
{
    public class ModuleInstaller : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            try
            {
                builder.RegisterType<TimeProvider>().As<ITimeProvider>();                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}


