using Microsoft.AspNetCore.Mvc;
using Demo.DataAccess.Models;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;

namespace Demo.Prestation.Controllers
{


    public class DepartmentController : Controller
    {




        private readonly IDepartmentService _departmentSrevice; 

        public DepartmentController(IDepartmentService departmentService )
        {
            this._departmentSrevice = departmentService;
        }




        public IActionResult Index()
        {
            return View();
        }









    }
}
