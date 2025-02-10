using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TasksCreator.Models
{
    [Table("Tasks")]
    public class TaskEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }

        [Required]
        public string TaskName { get; set; }

        [Required]
        public string JsonInput { get; set; }

        public string JsonOutput { get; set; }

        [Required]
        public string Status { get; set; } = "PENDING";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int? WorkerId { get; set; }
    }
}
