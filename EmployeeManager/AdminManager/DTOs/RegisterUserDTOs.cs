namespace EmployeeManager.DTOs
{
    public class RegisterUserDTOs
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int DepartmentId { get; set; }
    }
}
