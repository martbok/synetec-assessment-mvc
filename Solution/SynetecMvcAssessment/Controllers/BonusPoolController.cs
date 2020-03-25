using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterviewTestTemplatev2.Calculator;
using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Models;
using InterviewTestTemplatev2.Repository;


namespace InterviewTestTemplatev2.Controllers
{
    public class BonusPoolController : Controller
    {
        private readonly IHrRepository _hrRepository;
        private readonly IBonusCalculator _bonusCalculator;

        public BonusPoolController() : this(new HrRepository(new MvcInterviewV3Entities1()), new BonusCalculator())
        { }

        public BonusPoolController(IHrRepository hrRepository, IBonusCalculator bonusCalculator)
        {
            _hrRepository = hrRepository;
            _bonusCalculator = bonusCalculator;
        }

        // GET: BonusPool
        public ActionResult Index()
        {
            BonusPoolCalculatorModel model = new BonusPoolCalculatorModel();

            model.AllEmployees = _hrRepository.GetHrEmployees().ToList();
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calculate(BonusPoolCalculatorModel model)
        {
            int selectedEmployeeId = model.SelectedEmployeeId;
            int totalBonusPool = model.BonusPoolAmount;

            //load the details of the selected employee using the ID
            HrEmployee hrEmployee = _hrRepository.GetHrEmployee(selectedEmployeeId);
            
            int employeeSalary = _bonusCalculator.GetSalary(hrEmployee);

            IEnumerable<HrEmployee> allEmployees = _hrRepository.GetHrEmployees();

            //get the total salary budget for the company
            int totalSalary = _bonusCalculator.GetTotalSalary(allEmployees);

            int bonusAllocation = _bonusCalculator.Calculate(employeeSalary, totalSalary, totalBonusPool);

            var result = ToBonusPoolCalculatorResultModel(hrEmployee, bonusAllocation);

            return View(result);
        }

        private static BonusPoolCalculatorResultModel ToBonusPoolCalculatorResultModel(HrEmployee hrEmployee, int bonusAllocation)
        {
            return new BonusPoolCalculatorResultModel
            {
                hrEmployee = hrEmployee, 
                bonusPoolAllocation = bonusAllocation
            };
        }
    }
}