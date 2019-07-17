using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementApp.Models;
using EmployeeManagementApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApp.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository,
                              IHostingEnvironment hostingEnvironment)
        {
            this._employeeRepository = employeeRepository;
            this._hostingEnvironment = hostingEnvironment;
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
        [Route("[action]")]
        public IActionResult Delete(int id)
        {
            _employeeRepository.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost("[action]")]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = "";
                if (model.Photo != null)
                {
                   string uploadsFolder =  Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName =  Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName
                };
                _employeeRepository.Add(newEmployee);
                return RedirectToAction("Details", new { id = newEmployee.Id });
            }
            return View();
        }
    }
}