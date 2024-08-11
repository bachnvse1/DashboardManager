using EmployeeManager.DTOs;
using ProjectFS2.Entity;

namespace EmployeeManager.Repository
{
    public interface IUserRepository
    {
        // Create
        void AddUser(User user);

        // Read
        User GetUserById(int id);

        User GetUserByUsername(string username);

        IEnumerable<User> GetAllUsers();

        // Update
        void UpdateUser(User user);

        // Delete
        void DeleteUser(int id);

        RegistrationResponse RegisterUser(RegisterUserDTOs registerUserDTOs);

        LoginResponse LoginUser(LoginDTOs loginDTOs);

        string GenerateJWTToken(User user);
    }
}
