using EFCoreRepositoryWithDukesStore.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreRepositoryWithDukesStore.Core.Application.Repository
{
    public interface ICourseRepository:IRepository<Course>
    {

        IEnumerable<Course> GetCourseWithStudent(int pageIndex, int pageSize);
        IEnumerable<Course> GetCourseByStudentId(int studentId);
    }
}
