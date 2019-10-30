using EFCoreRepositoryWithDukesStore.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCoreRepositoryWithDukesStore.Persistance
{
    public static class DBInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();


            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student{Name="Carson Alexander", StudentCardNumber="CarsonAlexander09220"},
                new Student{Name="Meredith Alonso", StudentCardNumber="MeredithAlonso71104"},
                new Student{Name="Arturo Anand", StudentCardNumber="ArturoAnand28901"},
                new Student{Name="Gytis Barzdukas", StudentCardNumber="GytisBarzdukas77865"},
                new Student{Name="Yan Li", StudentCardNumber="YanLi11913"},
                new Student{Name="Peggy Justice", StudentCardNumber="PeggyJustice22093"},
                new Student{Name="Laura Norman", StudentCardNumber="LauraNorman00791"},
                new Student{Name="Nino Olivetto", StudentCardNumber="NinoOlivetto13382"}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{CourseCode="1050",Title="Chemistry",Description="Chemistry course."},
                new Course{CourseCode="4022",Title="Microeconomics",Description="Microeconomics course."},
                new Course{CourseCode="4041",Title="Macroeconomics",Description="Macroeconomics course."},
                new Course{CourseCode="1045",Title="Calculus",Description="Calculus course."},
                new Course{CourseCode="3141",Title="Trigonometry",Description="Trigonometry course."},
                new Course{CourseCode="2021",Title="Composition",Description="Composition course."},
                new Course{CourseCode="2042",Title="Literature",Description="Literature course."}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();
        }
    }
}
