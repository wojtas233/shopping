﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.DataAccess.Entities;

namespace Shopping.DataAccess.Configurations
{
    public class SystemTranslationConfiguration
    {
        public SystemTranslationConfiguration(EntityTypeBuilder<SystemTranslation> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder
                .HasOne(t => t.SystemLanguage)
                .WithMany(t => t.SystemTranslation)
                .HasForeignKey(t => t.SystemLanguageId)
                .IsRequired();

        }
    }
}
