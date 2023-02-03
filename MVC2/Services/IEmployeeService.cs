using MVC2.ViewModels;

namespace MVC2.Services
{
    public interface IEmployeeService
    {
        List<EmployeeVM> getAllEmployees();
        EmployeeVM getEmployeeById(int id);
    }
}