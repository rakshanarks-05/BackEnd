using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
    public class UserLogin
    {
        [Key]
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public Role Role { get; set; }
    }
    public enum Role
    {
        Admin = 1,
        Editor = 2,
        Viewer = 3,
    }
}
