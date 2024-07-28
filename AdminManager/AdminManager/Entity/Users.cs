using System.ComponentModel.DataAnnotations;

namespace ProjectFS2.Entity
{
    public class Users
    {
        [Key]
        public int id { get; set; }
        public string ?username { get; set; }
        public string ?password { get; set; }
        public string ?full_name { get; set; }
        public int role_id { get; set; }
        public int status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set;}
        public Employee Employee { get; set; }


    }
}
