using AdminManager.OfficeDB;
using ProjectFS2.Entity;

namespace EmployeeManager.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _officeDB;
        public EmployeeRepository(ApplicationDbContext officeDB)
        {
            _officeDB = officeDB;
        }
        public void AddEmployee(Employee employee)
        {
            _officeDB.Employees.Add(employee);
            _officeDB.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var employee = GetEmployeeById(id);
            _officeDB.Employees.Remove(employee);
            _officeDB.SaveChanges();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _officeDB.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return (Employee)_officeDB.Employees.Where(x => x.EmployeeId == id);
        }

        public void UpdateEmployee(Employee employee)
        {
            _officeDB.Employees.Update(employee);
            _officeDB.SaveChanges();
        }
    }
}
