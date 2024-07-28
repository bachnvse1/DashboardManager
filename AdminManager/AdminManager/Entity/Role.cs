using System.ComponentModel.DataAnnotations;

namespace ProjectFS2.Entity
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string ?Name { get; set; }
    }
}
