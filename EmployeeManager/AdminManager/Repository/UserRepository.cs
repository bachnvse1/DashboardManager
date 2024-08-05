using AdminManager.OfficeDB;
using ProjectFS2.Entity;

namespace EmployeeManager.Repository
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _officeDB;
        public UserRepository(ApplicationDbContext officeDB) {
            _officeDB = officeDB;
        }
        public void AddUser(User user)
        {
            _officeDB.Users.Add(user);
            _officeDB.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            try
            {
                var u = _officeDB.Users.FirstOrDefault(x => x.UserId == id);
                if (u == null) throw new Exception();
                return u;
            } catch(Exception ex)
            {
                throw new NotImplementedException("Fail to get user");
            }
            
        }

        public void UpdateUser(User user)
        {
            try
            {
                _officeDB.Users.Update(user);
                _officeDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Fail to update user");
            }
        }
    }
}
