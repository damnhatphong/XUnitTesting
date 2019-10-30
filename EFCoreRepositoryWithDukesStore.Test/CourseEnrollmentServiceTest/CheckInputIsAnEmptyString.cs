using EFCoreRepositoryWithDukesStore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EFCoreRepositoryWithDukesStoreTest.CourseEnrollmentServiceTest
{

    public class CheckInputIsAnEmptyString
    {
        string message = "Please enter student id!";
        [Theory]
        [InlineData("")]
        public void EnterAnEmptyString(string input)
        {
            Exception ex = Assert.Throws<Exception>(() => CourseEnrollmentValidator.ValidateStudentId(input));
            Assert.Equal(message, ex.Message);
        }
    }
}
