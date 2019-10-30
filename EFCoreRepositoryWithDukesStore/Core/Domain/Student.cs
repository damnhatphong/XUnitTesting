using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreRepositoryWithDukesStore.Core.Domain
{
    public class Student
    {
        public Student()
        {
            StudentCourses = new HashSet<StudentCourses>();
        }
        public int Id { get; set; }
        public string StudentCardNumber { get; set; }
        public string Name { get; set; }

        public ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
