using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MVC2.Models;

namespace MVC2.Repositry
{
    public class EmployeeRepo : IEmployeeRepo
    {
        CompanyContext db;
        public EmployeeRepo(CompanyContext db)
        {
            this.db = db;
        }

        public List<Employee> getAllEmployees()
        {
            return db.employees.ToList();
        }

        public Employee getEmployeeById(int id)
        {
            return db.employees.SingleOrDefault(s => s.id == id);
        }

        public void addEmployee(Employee emp)
        {

            db.employees.Add(emp);
            db.SaveChanges();


        }

        public void editEmployee(Employee emp)
        {

            var empl = db.employees.SingleOrDefault(e => e.id == emp.id);
            empl.fname = emp.fname;
            empl.minit = emp.minit;
            empl.lname = emp.lname;
            empl.sex = emp.sex;
            empl.birthday = emp.birthday;
            empl.address = emp.address;
            empl.salary = emp.salary;
            empl.supervisorid = emp.supervisorid;
            empl.departmentWFid = emp.departmentWFid;

            db.SaveChanges();

        }

        public int deleteEmployee(int id)
        {

            var emp = getEmployeeById(id);
            db.employees.Remove(emp);
            return db.SaveChanges();



        }
    }
}
