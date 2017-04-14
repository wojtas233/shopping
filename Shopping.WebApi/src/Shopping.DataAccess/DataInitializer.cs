using Autofac;
using Shopping.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Shopping.DataAccess
{
    public static class DataInitializer
    {
        public static void Initialize(Autofac.IContainer applicationContainer)
        {            
            using (var unitOfWork = applicationContainer.Resolve<UnitOfWork>())
            {
                CreateClients(unitOfWork);
                AddSystemLanguages(unitOfWork);
                AddSystemParameters(unitOfWork);
            }  
        }

        private static void CreateClients(UnitOfWork unitOfWork)
        {
            if (unitOfWork.Clients.GetAll().Any())
            {
                return;
            }

            var clients = new List<Client>
            {
                new Client { Name = "Carson", Date = DateTime.Parse("2010-09-01") }
            };

            unitOfWork.Clients.InsertRange(clients);
        }

        private static void AddSystemParameters(UnitOfWork unitOfWork)
        {
            if (string.IsNullOrEmpty(unitOfWork.SystemParameters.GetValue<string>("test")))
            {
                unitOfWork.SystemParameters.AddValue<string>("test", "testValue", "value just for test", null, null);
            }
        }

        private static void AddSystemLanguages(UnitOfWork unitOfWork)
        {
            if (unitOfWork.SystemLanguages.GetAll().Any())
            {
                return;
            }

            var languages = new List<SystemLanguage>
            {
                new SystemLanguage { Code = "en-US", Name="English" },
                new SystemLanguage { Code = "fr", Name="French" }
            };

            unitOfWork.SystemLanguages.InsertRange(languages);
        }
    }
}