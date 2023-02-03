using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVC2.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MVC2.Repositry;
using MVC2.ViewModels;

namespace MVC2.Services
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepo Er;
        public EmployeeService( IEmployeeRepo Er)
        {
            this.Er = Er;
        }
        public List<EmployeeVM> getAllEmployees()
        {
            List<Employee> emplist = Er.getAllEmployees();
            List<EmployeeVM> empVmList = new List<EmployeeVM>();
            foreach (var item in emplist)
            {
                var empVm = new EmployeeVM()
                {
                    fname = item.fname,
                    minit = item.minit,
                    lname = item.lname,
                    sex = item.sex,
                    address = item.address,
                    salary = item.salary,
                    departmentWFid = item.departmentWFid,
                    supervisorid = item.supervisorid,
                };
                empVmList.Add(empVm);
            }
            return empVmList;
        }
        public EmployeeVM getEmployeeById(int id)
        {
            var emp = Er.getEmployeeById(id);
            EmployeeVM empVm = new EmployeeVM()
            {
                fname = emp.fname,
                minit = emp.minit,
                lname = emp.lname,
                sex = emp.sex,
                address = emp.address,
                salary = emp.salary,
                departmentWFid = emp.departmentWFid,
                supervisorid = emp.supervisorid,
            };
            return empVm;
        }


    }
}
