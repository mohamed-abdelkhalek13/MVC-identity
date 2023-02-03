using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC2.Models;
using MVC2.Repositry;
using MVC2.Services;
using MVC2.ViewModels;
namespace MVC2.Controllers
{
    
    public class EmployeeController : Controller
    {
        IEmployeeRepo er;
        public EmployeeController( IEmployeeRepo er)
        {
            this.er = er;
        }
        public IActionResult Index()
        {
            var employessList = er.getAllEmployees();

            return View(employessList);
        }
        public IActionResult employeeDetails(int id)
        {
            var empDetails = er.getEmployeeById(id);
            if(empDetails == null)
            {
                return View("errorpage");
            }
            else
            {
                return View(empDetails);
            }
        }
        


        public IActionResult addemployeeform()
        {
            var employessList = er.getAllEmployees();
            return View(employessList);

        }
        public IActionResult AddEmployee(Employee emp)
        {
            er.addEmployee(emp);
            return RedirectToAction("Index");
        }
        public IActionResult updateEmployee(int id)
        {
            var emp = er.getEmployeeById(id);
            var supervisors = er.getAllEmployees();
            ViewBag.all = supervisors;
            return View(emp);
        }
        public IActionResult updateEmployeeInfo(Employee emp)
        {
            er.editEmployee(emp);

            return RedirectToAction("Index");
        }
        public IActionResult delete(int id)
        {
            er.deleteEmployee(id);
            return RedirectToAction("Index");
        }
        
    }

}
