using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NIC { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public Address? Address { get; set; }

        public ICollection<TaskItem>? Tasks { get; set; }=new List<TaskItem>();




    }
}
