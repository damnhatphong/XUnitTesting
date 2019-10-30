using EFCoreRepositoryWithDukesStore.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreRepositoryWithDukesStore.Persistance.EntityConfiguration
{
    class StudentCoursesConfiguration : IEntityTypeConfiguration<StudentCourses>
    {
        public void Configure(EntityTypeBuilder<StudentCourses> builder)
        {
            builder.HasKey(c => new { c.StudentId, c.CourseId });

            builder.HasOne(s => s.Student)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.Course)
                .WithMany(m => m.StudentCourses)
                .HasForeignKey(x => x.CourseId);


        }
    }
}
