using TaskManagement.Models;

namespace TaskManagement.DTO
{
    public class UserDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
