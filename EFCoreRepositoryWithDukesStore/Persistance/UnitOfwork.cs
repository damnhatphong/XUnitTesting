using EFCoreRepositoryWithDukesStore.Core.Application.Repository;
using EFCoreRepositoryWithDukesStore.Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreRepositoryWithDukesStore.Persistance
{
    public class UnitOfWork : IDisposable
    {
        private readonly SchoolContext _context;
        public ICourseRepository Courses { get; private set; }
        public IStudentRepository Students { get; private set; }

        private bool disposed = false;
        public UnitOfWork(SchoolContext context)
        {
            _context = context;
            Courses = new CourseRepository(_context);
            Students = new StudentRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (_context != null) 
                    {
                        _context.Dispose();
                    }
                }
                // free native resources.
                disposed = true;

            }
        }
    }
}
