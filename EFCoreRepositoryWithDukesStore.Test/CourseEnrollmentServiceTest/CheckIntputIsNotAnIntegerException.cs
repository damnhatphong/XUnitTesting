using System;
using System.Collections.Generic;
using Xunit;
using EFCoreRepositoryWithDukesStore;
using EFCoreRepositoryWithDukesStore.Core.Domain;
using EFCoreRepositoryWithDukesStore.Persistance;

namespace EFCoreRepositoryWithDukesStoreTest.CourseEnrollmentServiceTest
{
    public class CheckIntputIsNotAnIntegerException
    {
        string message = "StudentId must be integer value!";
        //CourseEnrollmentService service = new CourseEnrollmentService(new UnitOfWork(new SchoolContext()));
        [Fact]
        public void EnterAlphabetString()
        {
            //message = "0000";
            foreach (string input in IterateThroughTestData()) {
                Exception ex = Assert.Throws<Exception>(() => CourseEnrollmentValidator.ValidateStudentId(input));

                Assert.Equal(message,ex.Message);
            }
        }


        /*
        [Theory]
        [InlineData("Leon Matheron")]
        [InlineData("Luke Moran")]
        [InlineData("M.Cethese")]
        [InlineData("Posalit2565")]
        public void EnterAlphabetString(string input)
        {

        } 
         */

        public List<string> TestData => new List<string>
        {
           "Leon Matheron",
           "Luke Moran",
           "M.Cethese",
           "Posalit2565",
           "asdfklja;sfweqntg;lkdagvjhaiosdpqrjhewqkl;ngpoiqu4hnklwjerh"
        };

        public IEnumerable<string> IterateThroughTestData()
        {
            for (int i = 0; i < TestData.Count; i++) 
            {
                yield return TestData[i];
            }
        }

    }
}
