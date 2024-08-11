using AdminManager.OfficeDB;
using EmployeeManager.DTOs;
using Microsoft.IdentityModel.Tokens;
using ProjectFS2.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeManager.Repository
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _officeDB;
        private readonly IConfiguration _configuration;

        public UserRepository(ApplicationDbContext officeDB, IConfiguration configuration)
        {
            _officeDB = officeDB;
            _configuration = configuration;
        }

        public void AddUser(User user)
        {
            try
            {
                if (GetUserByUsername(user.UserName) == null)
                {
                    _officeDB.Users.Add(user);
                    _officeDB.SaveChanges();
                }
                else throw new Exception();
                
            } catch(Exception ex) {
                throw new NotImplementedException("Fail to add user");
            }

        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
            _officeDB.Users.Remove(user);
            _officeDB.SaveChanges();
        }

        public string GenerateJWTToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaim = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.UserName!)
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: userClaim,
                expires: DateTime.Now.AddDays(5),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _officeDB.Users.ToList();
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

        public User GetUserByUsername(string username)
        {
            var u = _officeDB.Users.FirstOrDefault(x => x.UserName == username);
            if (u != null) return u;
            return null;
        }

        public LoginResponse LoginUser(LoginDTOs loginDTOs)
        {
            var getUser = GetUserByUsername(loginDTOs.UserName);
            if (getUser == null)
                return new LoginResponse(false, "User not found");
            bool checkPassword = BCrypt.Net.BCrypt.Verify(loginDTOs.Password, loginDTOs.Password);
            if (checkPassword)
                return new LoginResponse(true, "Login successfully!");
            return new LoginResponse(false, "Login failed!");

        }

        public RegistrationResponse RegisterUser(RegisterUserDTOs registerUserDTOs)
        {
            var getUser = GetUserByUsername(registerUserDTOs.UserName);
            if(getUser != null)
                return new RegistrationResponse(true, "Register failed!");
            _officeDB.Users.Add(new User()
            {
                UserName = registerUserDTOs.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(registerUserDTOs.Password),
                RoleId = registerUserDTOs.RoleId,
                DepartmentId = registerUserDTOs.DepartmentId
            });
            _officeDB.SaveChanges();
            return new RegistrationResponse(true, "Register successfully");
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
