using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopping.DataAccess.Entities;

namespace Shopping.DataAccess.Configuration
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
