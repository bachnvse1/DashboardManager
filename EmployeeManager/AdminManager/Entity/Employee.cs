using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectFS2.Entity
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User user { get; set; }
    }
}
