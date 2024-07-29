using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectFS2.Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public Employee Employee { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; }
    }
}
