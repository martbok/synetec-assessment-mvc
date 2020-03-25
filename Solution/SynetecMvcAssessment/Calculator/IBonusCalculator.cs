using System.Collections.Generic;
using InterviewTestTemplatev2.Data;

namespace InterviewTestTemplatev2.Calculator
{
    public interface IBonusCalculator
    {
        int Calculate(int employeeSalary, int allEmployeesSalary, int bonusPool);
        int GetSalary(HrEmployee hrEmployee);
        int GetTotalSalary(IEnumerable<HrEmployee> hrEmployees);
    }
}