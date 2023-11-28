using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Tasks.ViewModels
{
    public class ToDoTaskEditViewModel
    {
        [NotNull]
        [Required(ErrorMessage ="Not Have Id")]
        public int Id { get; set; }
        [NotNull]
        [Required(ErrorMessage = "Not Have Name, Write Name")]
        public string? Name { get; set; }
        [NotNull]
        [Required(ErrorMessage = "Not Have Description, Write Description")]
        public string? Description { get; set; }
    }
}
