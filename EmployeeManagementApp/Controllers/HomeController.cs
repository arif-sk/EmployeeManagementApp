using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementApp.Models;
using EmployeeManagementApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApp.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [Route("[action]")]
        [Route("")]
        [Route("~/")]
        public ViewResult Index()
        {
            ViewBag.PageTitle = "All Employees";
            var employees = _employeeRepository.GetEmployee();
            return View(employees);
        }
        [Route("[action]/{id?}")]
        [HttpGet]
        public ActionResult Details(int? id)
        {
            ViewBag.PageTitle = "Employee Details";
            var emp = _employeeRepository.GetEmployee(id ?? 1);
            return View(emp);
        }
        [Route("[action]")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost("[action]")]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.Add(employee);
                return RedirectToAction("Details", new { id = newEmployee.Id });
            }
            return View();
        }
    }
}