using Microsoft.AspNetCore.Mvc;
using Demo.DataAccess.Models;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;

namespace Demo.Prestation.Controllers
{


    public class DepartmentController(IDepartmentService _departmentService) : Controller
    {




        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }









    }
}
