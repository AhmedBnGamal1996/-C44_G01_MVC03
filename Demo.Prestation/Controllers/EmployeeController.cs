using Demo.BusinessLogic.DTOS.DepartmentDTOS;
using Demo.BusinessLogic.DTOS.EmployeeDTOS;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Models.EmployeeModule;
using Demo.DataAccess.Models.Shared;
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


        #region Edit 

        [HttpGet]
         
        public IActionResult Edit (int? id )
        {
            if(!id.HasValue) return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value); 
            if (employee == null) return NotFound();
            var employeeDto = new UpdatedEmployeeDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                IsActive = employee.IsActive,
                Email = employee.Email,
                Salary = employee.Salary,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
                Gender = Enum.Parse<Gender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
                Address = employee.Address


            };
        
        
            return View(employeeDto);
        }


        [HttpPost]

        public IActionResult Edit([FromRoute] int? id , UpdatedEmployeeDto employeeDto )
        {
            if(!id.HasValue || id != employeeDto.Id) return BadRequest();

            if (!ModelState.IsValid) return View(employeeDto); 

            try
            {
                int result = _employeeService.UpdateEmployee(employeeDto);
                if (result > 0) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee can not updated");
                    return View(employeeDto); 
                }
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    _logger.LogError($"Employee Can not be Updated because : {ex.Message}");
                    return View(employeeDto);

                }
                else
                {
                    _logger.LogError($"Employee can not be Updated because  {ex}");

                    return View("ErrorView", ex);

                }
            }
            
      
        }




        #endregion




        #region Delete


        [HttpPost]

        public IActionResult Delete(int id)
        {


            if (id == 0) return BadRequest();

            try

            {
                bool isDeleted = _employeeService.DeleteEmployee(id);

                if (isDeleted) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee can not be deleted");
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }




            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    _logger.LogError($"Employee can not be deleted because : {ex.Message}");
                }
                else
                {
                    _logger.LogError($"Employee can not be deleted brcause {ex}");
                    return View("ErrorView");
                }

            }
            return RedirectToAction(nameof(Delete), new { id });
        }



        #endregion










    }
}
