using Microsoft.AspNetCore.Mvc;
using Demo.DataAccess.Models;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.BusinessLogic.DTOS;
using Demo.Prestation.viewModels;

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
            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value); 
            if (department == null) return NotFound();

            var departmentVM = new DepartmentEditViewModel
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreatedOn = department.CreatedOn.HasValue ? department.CreatedOn.Value : default




            };

            return View(departmentVM);



            // return View(department);
        }


        [HttpPost]

        public IActionResult Edit(int? id,  DepartmentEditViewModel departmentVM)
        {
            if (ModelState.IsValid)
            {

                try


                {
                    if (!id.HasValue) return BadRequest();

                    var updateDepartmentDto = new UpdateDepartmentDto
                    {
                        Id = id.Value,
                        Code = departmentVM.Code,
                        Name = departmentVM.Name,
                        Description = departmentVM.Description,
                        DateOfCreation = departmentVM.CreatedOn
                    };


                    int result = _departmentService.UpdateDepartment(updateDepartmentDto);


                    if (result > 0) return RedirectToAction(nameof(Index));


                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department can not be updated");

                    }



                }



                catch (Exception ex)
                {
                    if (_env.IsDevelopment())
                    {
                        _logger.LogError($"Department can not be updated because : {ex.Message}");
                    }
                    else
                    {
                        _logger.LogError($"Department can not be updated brcause {ex}");
                        return View("ErrorView");
                    }
                   
                }
                return View(departmentVM);
            }
            return View(departmentVM);

        }











        #endregion





    }
}
