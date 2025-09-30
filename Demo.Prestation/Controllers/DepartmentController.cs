using Microsoft.AspNetCore.Mvc;
using Demo.DataAccess.Models;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.BusinessLogic.DTOS;
using Demo.Prestation.viewModels;
using Demo.BusinessLogic.DTOS.DepartmentDTOS;

namespace Demo.Prestation.Controllers
{


    public class DepartmentController(IDepartmentService _departmentService , IWebHostEnvironment _env , ILogger<DepartmentController> _logger ) : Controller
    {


        #region Index 
        // View Data , ViewBag ==> ViewStorage ==> Deal with the same storage 
        // Extra info [ Extra Data ] 
        // Send Controller ==> View 
        // Send View ==> Partial View 
        // Send View ==> Layout
        // ViewData [ Safe ] [ .Net 3.5 ] 
        // ViewBag [ UnSafe ] [ .Net 4.0 ] , Dynamic  



        [HttpGet]


        public IActionResult Index()
        {
            // ViewData["Message"] = "Hello from view data  ";

            // ViewBag.Message = "Hello from view bag  ";

            ViewData["Message"] = new DepartmentDto() { Name = "Test" }; 
            ViewBag.Message = new DepartmentDto() { Name = "Test" };



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

        // [ValidateAntiForgeryToken]  // Attribute ==> Action Filter 
        public IActionResult Create(DepartmentViewModel departmentViewModel)
        {
            if(ModelState.IsValid)      // Server Side Validation
            {
                try
                {

                   int result = _departmentService.AddDepartment(new CreateDepartmentDto()
                   {
                          Code = departmentViewModel.Code,
                          Name = departmentViewModel.Name,
                          Description = departmentViewModel.Description,
                          DateOfCreation = departmentViewModel.CreatedOn
                   });

                    string message; 

                    if (result > 0)
                      message = "Department created successfully";
                    
                    else
                        message = "Department can not be created";

                    TempData["Message"] = message; 
                    return RedirectToAction(nameof(Index) );


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

                return View(departmentViewModel); 




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

            var departmentVM = new DepartmentViewModel
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

        public IActionResult Edit(int? id,  DepartmentViewModel departmentVM)
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





        #region Delete
        // GET ==> render the view 



        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (!id.HasValue) return BadRequest();
        //    var department = _departmentService.GetDepartmentById(id.Value);
        //    if (department == null) return NotFound();
        //    return View(department);
        //}




        [HttpPost]

        public IActionResult Delete(int id)
        {


            if (id ==0 ) return BadRequest();

            try

            {
                bool isDeleted = _departmentService.DeleteDepartment(id);

                if (isDeleted) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Department can not be deleted");
                    return RedirectToAction(nameof(Delete) , new {id});
                }
            }




            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    _logger.LogError($"Department can not be deleted because : {ex.Message}");
                }
                else
                {
                    _logger.LogError($"Department can not be deleted brcause {ex}");
                    return View("ErrorView");
                }
               
            }
            return RedirectToAction(nameof(Delete), new { id });
        }















        #endregion

























    }
}
