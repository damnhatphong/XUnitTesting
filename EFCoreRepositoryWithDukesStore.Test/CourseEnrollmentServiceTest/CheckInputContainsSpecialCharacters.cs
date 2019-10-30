using EFCoreRepositoryWithDukesStore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EFCoreRepositoryWithDukesStoreTest.CourseEnrollmentServiceTest
{
    public class CheckInputContainsSpecialCharacters
    {

        string message = "StudentId must be integer value!";
        [Fact]
        public void EnterSpecialCharacterString()
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
           "卩尺乇ᐯ丨乇山 ㄒ乇乂ㄒ",
           "ᎮᏒᏋᏉᎥᏋᏇ ᏖᏋጀᏖ",
           "✌☝♝♞➥⏎⌤⌆",
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
