using EFCoreRepositoryWithDukesStore.Core.Domain;
using EFCoreRepositoryWithDukesStore.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EFCoreRepositoryWithDukesStore
{
    public class CourseEnrollmentService
    {
        private readonly UnitOfWork unit;
        public CourseEnrollmentService(UnitOfWork unitOfWork)
        {
            unit = unitOfWork;
        }

        public void ShowAllAvailableCourses() =>
            DisplayCourses(unit.Courses.GetAll());
        

        public void ShowAllEnrolledStudentByCourseId(int id)
        {

        }

        public void ShowCoursesHaveBeenJoinedByStudentID()
        {
            int answer = AskForStudentId();
            if (answer > 0)
            {
                DisplayCourses(unit.Courses.GetCourseByStudentId(answer));
            }
        }        


        private void DisplayStudents(List<Student> students)
        {
            if (students.Count > 0)
            {
                Console.WriteLine("Student information:");
                foreach (var s in students)
                {
                    Console.WriteLine("Student Id: " + s.Id);
                    Console.WriteLine("Student card number: " + s.StudentCardNumber);
                    Console.WriteLine("Student Name: " + s.Name);
                    Console.WriteLine();
                }
                Console.WriteLine(new String('-', 50));
            }
            else 
            {
                ResultNotFound();
            }
        }


        private void DisplayCourses(IEnumerable<Course> courses)
        {
            if (courses.Any())
            {
                Console.WriteLine("Course information:");
                foreach (var c in courses)
                {
                    Console.WriteLine("Course Id: " + c.Id);
                    Console.WriteLine("Course Title: " + c.Title);
                    Console.WriteLine("Course Code: " + c.CourseCode);
                    Console.WriteLine("Description: " + c.Description);
                    Console.WriteLine();
                }
                Console.WriteLine(new String('-', 50));
            }
            else    
            {
                ResultNotFound();
            }
        }

        private void ResultNotFound()
        {
            Console.WriteLine("Sorry! No result was found.");
        }

        
        public int AskForStudentId()
        {
            Console.WriteLine("Please Enter student Id (must be an integer): ");

            //Lead to inaccurate input cause by ReadKey()
            //int answer = Console.ReadKey();

            string answer = Console.ReadLine();
            Console.WriteLine(new String('-', 50));
            try
            {
                CourseEnrollmentValidator.ValidateStudentId(answer);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception message: " + exception.Message);
                Console.WriteLine("Source: " + exception.Source);
                return -1;
            }

            return Convert.ToInt32(answer);
        }
    }



    public static class CourseEnrollmentValidator 
    {
        public static void ValidateStudentId(string id)
        {
            if (id.Length <= 0 || id == "")
            {
                throw new Exception("Please enter student id!");
            }
            if (!Regex.IsMatch(id, @"^\d+$"))
            {
                throw new Exception("StudentId must be integer value!");
            }
            if (Convert.ToInt32(id) < 0)
            {
                throw new Exception("Student Id must be bigger than 0.");
            }

        }
    }
}
