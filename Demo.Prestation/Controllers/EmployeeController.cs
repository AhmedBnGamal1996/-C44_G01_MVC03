using Demo.BusinessLogic.DTOS.DepartmentDTOS;
using Demo.BusinessLogic.DTOS.EmployeeDTOS;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Prestation.Controllers
{
    public class EmployeeController(IEmployeeService _employeeService , IWebHostEnvironment _env , ILogger<EmployeeController> _logger): Controller
    {



        // Master Action

        // BaseUrl/Employee/Index ==> Send Data Controller ==> View 


        #region Index 

        [HttpGet]
        public IActionResult Index()
        {


            var employees = _employeeService.GetAllEmployees();
            return View(employees);
        }




        #endregion




        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatedEmployeeDto employeeDto)
        {

            if (ModelState.IsValid)      // Server Side Validation
            {
                try
                {

                    int result = _employeeService.CreateEmployee(employeeDto);
                    if (result > 0)
                    {

                        return RedirectToAction(nameof(Index));


                        //return View(viewName: "Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee can not be created");
                    }


                }


                catch (Exception ex)
                {

                    if (_env.IsDevelopment())
                    {
                        _logger.LogError($"Employee can not be created because : {ex.Message}");
                    }
                    else
                    {
                        _logger.LogError($"Employee can not be created brcause {ex}");
                        return View("ErrorView");
                    }



                }





            }

            return View(employeeDto);

            
        }




        #endregion


        #region Details 



        [HttpGet]

        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();  // Error 400 
            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee == null) return NotFound();  // Error 404 


            return View(employee);
        }
         
        #endregion






    }
}
