using ProjectFS2.Entity;

namespace EmployeeManager.Repository
{
    public interface IRoleRepository
    {
        // Create
        void AddRole(Role role);

        // Read
        Role GetRoleById(int id);

        IEnumerable<Role> GetAllRoles();

        // Update
        void UpdateRole(Role role);

        // Delete
        void DeleteRole(int id);
    }
}
