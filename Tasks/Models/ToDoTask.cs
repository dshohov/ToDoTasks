using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Tasks.Models
{
    public class ToDoTask
    {
        [Key]
        public int Id { get; set; }
        [NotNull]
        [Required(ErrorMessage = "Not Have Name, Write Name")]
        public string? Name { get; set; }
        [NotNull]
        [Required(ErrorMessage = "Not Have Description, Write Description")]
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
