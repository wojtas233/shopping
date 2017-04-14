using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopping.DataAccess.Entities;

namespace Shopping.DataAccess.Configuration
{
    public class SystemParameterValueConfiguration
    {
        public SystemParameterValueConfiguration(EntityTypeBuilder<SystemParameterValue> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.IsActive).IsRequired();
            entityBuilder.Property(t => t.Value).IsRequired();
            entityBuilder
                .HasOne(t => t.SystemParameter)
                .WithMany(t => t.SystemParameterValue)
                .HasForeignKey(t => t.SystemParameterId)                
                .IsRequired();
        }
    }
}
