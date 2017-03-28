using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.DataAccess.Entities;

namespace Shopping.DataAccess.Configurations
{
    public class SystemParameterConfiguration
    {
        public SystemParameterConfiguration(EntityTypeBuilder<SystemParameter> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Code).IsRequired();
            entityBuilder
                .HasOne(t => t.SystemTranslation)
                .WithMany(t => t.SystemParameter)
                .HasForeignKey(t => t.SystemTranslationId)
                .IsRequired();
        }
    }
}
