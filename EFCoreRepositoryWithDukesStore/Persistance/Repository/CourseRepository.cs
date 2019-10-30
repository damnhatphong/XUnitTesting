using EFCoreRepositoryWithDukesStore.Core.Application.Repository;
using EFCoreRepositoryWithDukesStore.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCoreRepositoryWithDukesStore.Persistance.Repository
{
    class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(SchoolContext context) : base(context) { }

        public IEnumerable<Course> GetCourseWithStudent(int pageIndex, int pageSize = 10)
        {
            return SchoolContext.StudentCourses
                .Include(c => c.Student)
                .Include(c=>c.Course)
                .OrderBy(c => c.Course.CourseCode)
                .Select(c=>c.Course)
                .Skip((pageSize - 1) * pageIndex)
                .Take(pageIndex)
                .ToList();
        }

        public IEnumerable<Course> GetCourseByStudentId(int studentId)
        {
            return SchoolContext.StudentCourses.Include(c => c.Course).Where(s => s.StudentId == studentId).Select(sc=>sc.Course).ToList();
        }

        public SchoolContext SchoolContext 
        {
            get { return Context as SchoolContext; }
        }
    }
}
