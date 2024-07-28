using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectFS2.Service.Controller;
using ProjectFS2.DBContext;
using ProjectFS2.Entity;
using ProjectFS2.Service.DataAccess;
using System.Net.Http.Headers;
using System.Text;

namespace ProjectFS2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IEmployeeController _employeeController;
        public EmployeeController(IEmployeeController employeeController)
        {
            _employeeController = employeeController;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> addEmployee(string username, string password, string roleName, string departmentName)
        {
            
            var token = HttpContext.Session.GetString("token");
            int userCurrentId = (int)HttpContext.Session.GetInt32("userId");
            string reponseAdd = await _employeeController.addEmployee(token, userCurrentId, username, password, roleName, departmentName);
            if (reponseAdd != null)
                return RedirectToAction("Index", "Home");
            else return BadRequest("Fail add");
            
        }

        [HttpPost]
        public async Task<string> getEmployeeById(int id)
        {
            var token = HttpContext.Session.GetString("token");
            return await _employeeController.getEmployeeById(token, id);
        }
    }
}
