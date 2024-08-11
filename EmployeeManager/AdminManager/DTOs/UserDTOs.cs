using ProjectFS2.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManager.DTOs
{
    public class UserDTOs
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int DepartmentId { get; set; }
    }
}
