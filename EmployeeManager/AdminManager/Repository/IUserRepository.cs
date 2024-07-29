using ProjectFS2.Entity;

namespace EmployeeManager.Repository
{
    public interface IUserRepository
    {
        // Create
        void AddUser(User user);

        // Read
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers();

        // Update
        void UpdateUser(User user);

        // Delete
        void DeleteUser(int id);
    }
}
