using EFCoreRepositoryWithDukesStore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EFCoreRepositoryWithDukesStoreTest.CourseEnrollmentServiceTest
{
    public class CheckInputWithInvalidIntegerNumber
    {
        string message = "Student Id must be bigger than 0.";
        [Fact]
        public void EnterInvalidNumbers()
        {
            //message = "0000";
            foreach (string input in IterateThroughTestData())
            {
                Exception ex = Assert.Throws<Exception>(() => CourseEnrollmentValidator.ValidateStudentId(input));

                Assert.Equal(message, ex.Message);
            }
        }

        public List<string> TestData => new List<string>
        {
           "-10000000",
           "-1",
           "-99999999999999",
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
