using System.Collections.Generic;
using System.Linq;
using InterviewTestTemplatev2.Data;

namespace InterviewTestTemplatev2.Repository
{
    public class HrRepository : IHrRepository
    {
        private MvcInterviewV3Entities1 _databaseEntities;

        public HrRepository(MvcInterviewV3Entities1 databaseEntities)
        {
            _databaseEntities = databaseEntities;
        }

        public IEnumerable<HrEmployee> GetHrEmployees()
        {
            return _databaseEntities.HrEmployees;
        }

        public HrEmployee GetHrEmployee(int employeeId)
        {
            return _databaseEntities.HrEmployees.FirstOrDefault(item => item.ID == employeeId);
        }
    }
}