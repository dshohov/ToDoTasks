using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Tasks.Models
{
    public class ToDoTask
    {
        [Key]
        public int Id { get; set; }
        [NotNull]
        public string? Name { get; set; }
        [NotNull]
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
