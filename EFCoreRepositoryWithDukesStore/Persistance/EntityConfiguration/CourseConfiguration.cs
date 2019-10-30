using EFCoreRepositoryWithDukesStore.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreRepositoryWithDukesStore.Persistance.EntityConfiguration
{
    class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(c => c.CourseCode)
                .IsRequired();

            builder.HasIndex(c => c.CourseCode)
                .IsUnique();

            builder.HasKey(c => c.Id);
        }

    }
}
