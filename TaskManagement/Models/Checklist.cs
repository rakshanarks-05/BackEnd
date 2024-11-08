using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
    public class Checklist
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }

        public int TaskId { get; set; }
        public TaskItem? Task { get; set; }
    }
}
