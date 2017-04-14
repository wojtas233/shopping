using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shopping.DataAccess.Configuration;
using Shopping.DataAccess.Entities;

namespace Shopping.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            base.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ClientConfiguration(modelBuilder.Entity<Client>());
            new SystemLanguageConfiguration(modelBuilder.Entity<SystemLanguage>());
            new SystemTranslationConfiguration(modelBuilder.Entity<SystemTranslation>());
            new SystemParameterConfiguration(modelBuilder.Entity<SystemParameter>());
            new SystemParameterValueConfiguration(modelBuilder.Entity<SystemParameterValue>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
