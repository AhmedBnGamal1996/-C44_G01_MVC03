using Demo.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Prestation.Controllers
{
    public class EmployeeController(IEmployeeService _employeeService) : Controller
    {



        // Master Action

        // BaseUrl/Employee/Index ==> Send Data Controller ==> View 


        [HttpGet]
        public IActionResult Index()
        {


            var employees = _employeeService.GetAllEmployees();
            return View(employees);
        }












    }
}
