using ProjectFS2.Entity;

namespace EmployeeManager.Repository
{
    public interface IDepartmentRepository
    {
        // Create
        void AddDepartment(Department department);

        // Read
        Department GetDepartmentById(int id);
        IEnumerable<Department> GetAllDepartments();

        // Update
        void UpdateDepartment(Department department);

        // Delete
        void DeleteDepartment(int id);
    }
}
