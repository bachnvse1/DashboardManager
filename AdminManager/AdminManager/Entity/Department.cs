using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ProjectFS2.Entity
{
    public class Department
    {
        [Key]
        public int id { get; set; }
        public string ?name { get; set; }
        public int parent_department_id { get; set; }
        public int manager_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; }

    }
}
