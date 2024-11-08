using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? city { get; set; }
        public int? userId { get; set; }

        public User? User { get; set; }
    }
}
