using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shopping.DataAccess.Configurations;
using Shopping.DataAccess.Entities;

namespace Shopping.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new SystemLanguageConfiguration(modelBuilder.Entity<SystemLanguage>());
            new SystemTranslationConfiguration(modelBuilder.Entity<SystemTranslation>());
            new SystemParameterConfiguration(modelBuilder.Entity<SystemParameter>());
            new SystemParameterValueConfiguration(modelBuilder.Entity<SystemParameterValue>());
        }
    }
}
