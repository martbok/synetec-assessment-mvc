using System.Collections;
using System.Collections.Generic;
using System.Linq;
using InterviewTestTemplatev2.Data;

namespace InterviewTestTemplatev2.Calculator
{
    public class BonusCalculator : IBonusCalculator
    {
        public int Calculate(int employeeSalary, int allEmployeesSalary, int bonusPool)
        {
            //calculate the bonus allocation for the employee
            decimal bonusPercentage = (decimal)employeeSalary / (decimal)allEmployeesSalary;
            return (int)(bonusPercentage * bonusPool);
        }

        public int GetSalary(HrEmployee hrEmployee)
        {
            return hrEmployee.Salary;
        }

        public int GetTotalSalary(IEnumerable<HrEmployee> hrEmployees)
        {
            return hrEmployees.Sum(item => item.Salary);
        }
    }
}