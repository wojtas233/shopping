using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.DataAccess.Entities;

namespace Shopping.DataAccess.Configurations
{
    public class SystemLanguageConfiguration
    {
        public SystemLanguageConfiguration(EntityTypeBuilder<SystemLanguage> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.Code).IsRequired();
        }
    }
}
