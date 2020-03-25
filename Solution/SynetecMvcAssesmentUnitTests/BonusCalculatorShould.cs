using System.Collections.Generic;
using InterviewTestTemplatev2.Calculator;
using InterviewTestTemplatev2.Data;
using NUnit.Framework;

namespace SynetecMvcAssesmentUnitTests
{
    [TestFixture]
    public class BonusCalculatorShould
    {
        [TestCase(1500, 10000, 123456, 18518)]
        [TestCase(1500, 10000, 0, 0)]
        public void CalculateBonus(int employeeSalary, int allEmployeesSalary, int bonusPool, int expectedBonus)
        {
            // Arrange
            var sut = new BonusCalculator();

            // Act
            var actualBonus = sut.Calculate(employeeSalary, allEmployeesSalary, bonusPool);

            // Assert
            Assert.That(actualBonus, Is.EqualTo(expectedBonus));
        }

        [Test]
        public void GetTotalSalary_GivenHrEmployeeList()
        {
            // Arrange
            var hrEmployees = GetHrEmployees();
            var expectedTotalSalary = 3000;
            var sut = new BonusCalculator();

            // Act
            var actualTotalSalary = sut.GetTotalSalary(hrEmployees);

            // Assert
            Assert.That(actualTotalSalary, Is.EqualTo(expectedTotalSalary));
        }

        private static List<HrEmployee> GetHrEmployees()
        {
            var hrEmployees = new List<HrEmployee>()
            {
                new HrEmployee()
                {
                    Salary = 1000
                },
                new HrEmployee()
                {
                    Salary = 2000
                }
            };
            return hrEmployees;
        }
    }
}
