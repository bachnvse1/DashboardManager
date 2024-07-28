using System.ComponentModel.DataAnnotations;

namespace ProjectFS2.Entity
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        public int user_id { get; set; }
        public string? img { get; set; }
        public int department_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; }

    }
}
