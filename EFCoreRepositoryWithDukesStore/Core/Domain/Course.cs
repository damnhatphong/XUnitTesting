using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreRepositoryWithDukesStore.Core.Domain
{
    public class Course
    {
        public Course()
        {
            StudentCourses = new HashSet<StudentCourses>();
        }

        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
