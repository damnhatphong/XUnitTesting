using EFCoreRepositoryWithDukesStore.Core.Application.Repository;
using EFCoreRepositoryWithDukesStore.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreRepositoryWithDukesStore.Persistance.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(SchoolContext context) : base(context) { }
    }
}
