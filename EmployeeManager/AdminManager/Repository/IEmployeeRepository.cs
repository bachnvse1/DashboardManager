using ProjectFS2.Entity;

namespace EmployeeManager.Repository
{
    public interface IEmployeeRepository
    {
        // Create
        void AddEmployee(Employee employee);

        // Read
        Employee GetEmployeeById(int id);
        IEnumerable<Employee> GetAllEmployees();

        // Update
        void UpdateEmployee(Employee employee);

        // Delete
        void DeleteEmployee(int id);
    }
}
