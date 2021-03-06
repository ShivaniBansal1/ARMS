﻿using System;
using System.Collections.Generic;
using System.Text;
using Arms.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arms.Infrastructure.EntityTypeConfigurations
{
    internal class SkillEntityTypeConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skill", "ARMS");

            // builder.Property(e => e.id).HasColumnName("id");

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.createdAt)
                .HasColumnName("createdAt")
                .HasDefaultValueSql("(sysdatetime())");

            builder.Property(e => e.skillName)
                .HasColumnName("skillName")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.modifiedAt)
                .HasColumnName("modifiedAt")
                .HasDefaultValueSql("(sysdatetime())");

            builder.Property(e => e.createdBy)
                     .HasColumnName("createdBy")
                     .HasMaxLength(255);

            builder.Property(e => e.modifiedBy)
                   .HasColumnName("modifiedBy")
                   .HasMaxLength(255);
        }




    }
}
