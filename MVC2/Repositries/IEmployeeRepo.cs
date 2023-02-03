using MVC2.Models;

namespace MVC2.Repositry
{
    public interface IEmployeeRepo
    {
        void addEmployee(Employee emp);
        int deleteEmployee(int id);
        void editEmployee(Employee emp);
        List<Employee> getAllEmployees();
        Employee getEmployeeById(int id);
    }
}