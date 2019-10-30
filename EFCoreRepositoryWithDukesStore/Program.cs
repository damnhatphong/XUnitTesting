using EFCoreRepositoryWithDukesStore.Persistance;
namespace EFCoreRepositoryWithDukesStore
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (UnitOfWork unit = new UnitOfWork(new SchoolContext()))
            {
                CourseEnrollmentService enrollmentService = new CourseEnrollmentService(unit);
                
                enrollmentService.ShowAllAvailableCourses();

                enrollmentService.ShowCoursesHaveBeenJoinedByStudentID();
            }
        }

       
    }
}
