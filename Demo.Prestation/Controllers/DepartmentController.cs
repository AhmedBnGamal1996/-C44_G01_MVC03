using Microsoft.AspNetCore.Mvc;
using Demo.DataAccess.Models;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.BusinessLogic.DTOS;

namespace Demo.Prestation.Controllers
{


    public class DepartmentController(IDepartmentService _departmentService , IWebHostEnvironment _env , ILogger<DepartmentController> _logger ) : Controller
    {


        #region Index 
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }


        #endregion



        #region Create 

        // Return View [ Form ] 



        public IActionResult Create()
        {
            return View();
        }




        [HttpPost]
        public IActionResult Create(CreateDepartmentDto departmentDto)
        {
            if(ModelState.IsValid)      // Server Side Validation
            {
                try
                {

                   int result = _departmentService.AddDepartment(departmentDto);
                    if (result > 0)
                    { 

                        return RedirectToAction(nameof(Index)); 


                        //return View(viewName: "Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department can not be created");
                    }


                }


                catch(Exception ex)
                {

                    if(_env.IsDevelopment())
                    {
                        _logger.LogError($"Department can not be created because : {ex.Message}");
                    }
                    else
                    {
                        _logger.LogError($"Department can not be created brcause {ex}");
                        return View("ErrorView");
                    }



                }





            }

                return View(departmentDto); 




        }













        #endregion





        #region Details



        [HttpGet]

        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();  // Error 400 
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department == null) return NotFound();  // Error 404 


            return View(department);
        }


        #endregion

        #region Edit



        [HttpGet]

        public IActionResult Edit (int? id )
        {
            if (id.HasValue) return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value); 
            if (department == null) return NotFound();


            return View(department);
        }
















        #endregion





    }
}
