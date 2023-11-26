using System.Diagnostics.CodeAnalysis;

namespace Tasks.ViewModels
{
    public class ToDoTaskCreateViewModel
    {
        [NotNull]
        public string? Name { get; set; }
        [NotNull]
        public string? Description { get; set; }
    }
}
