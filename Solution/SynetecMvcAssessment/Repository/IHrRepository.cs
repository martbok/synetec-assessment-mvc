using System.Collections.Generic;
using InterviewTestTemplatev2.Data;

namespace InterviewTestTemplatev2.Repository
{
    public interface IHrRepository
    {
        IEnumerable<HrEmployee> GetHrEmployees();
        HrEmployee GetHrEmployee(int employeeId);
    }
}