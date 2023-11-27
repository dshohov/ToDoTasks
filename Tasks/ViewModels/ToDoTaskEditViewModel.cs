using System.Diagnostics.CodeAnalysis;

namespace Tasks.ViewModels
{
    public class ToDoTaskEditViewModel
    {
        [NotNull]
        public int Id { get; set; }
        [NotNull]
        public string? Name { get; set; }
        [NotNull]
        public string? Description { get; set; }
    }
}
