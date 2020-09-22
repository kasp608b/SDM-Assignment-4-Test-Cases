using System;
using SDM_Assignment_4_Test_Cases.Implementations;
using SDM_Assignment_4_Test_Cases.Interfaces;
using Xunit;
namespace SDM_Assignment_4_Test_Cases_Unit_Tests
{
    public class GradeTesterTest
    {
        [Theory]
        [InlineData(-1, "Evaluation percentage cannot be negative")]
        [InlineData(101, "Evaluation percentage cannot be higher than 100")]
        public void ToGradeIndexOutOfRangeExceptionTest(int percentage, string expectedMessage)
        {
            //Arrange
            IGradeTester gradeTester = new GradeTester();

            //Act
            var ex = Assert.Throws<IndexOutOfRangeException>(() =>
            {
                gradeTester.ToGrade(percentage);
            });

            //Assert
            Assert.Equal(expectedMessage, ex.Message);
        }


        [Theory]
        [InlineData(0, -3)]
        [InlineData(1, -3)]
        [InlineData(7, -3)]
        [InlineData(33, 00)]
        [InlineData(41, 02)]
        [InlineData(57, 4)]
        [InlineData(77, 7)]
        [InlineData(89, 10)]
        [InlineData(90, 12)]
        [InlineData(100, 12)]
        public void ToGradeEquivalenceClassPartitioningTest(int percentage, int expectedGrade)
        {
            //Arrange
            IGradeTester gradeTester = new GradeTester();

            //Act
            int actualGrade = gradeTester.ToGrade(percentage);

            //Assert
            Assert.Equal(expectedGrade, actualGrade);
        }
    }
}