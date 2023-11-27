using Tasks.Models;
using Tasks.ViewModels;

namespace Tasks.IServices
{
    public interface IToDoTaskService
    {
        Task<List<ToDoTask>> GetCurrentTasksInServiceAsync();
        Task<List<ToDoTask>> GetCompletedTasksInServiceAsync();
        Task<bool> CreateToDoTaskPost(ToDoTaskCreateViewModel toDoTaskCreateViewModel);
        Task<bool> ChangeStateToDoTask(int idTask);
        Task<bool> DeleteToDoTask(int idTask);
        Task<ToDoTaskEditViewModel> GetToDoTaskEditViewModel(int idTask);
        Task<bool> EditToDoTaskAsync(ToDoTaskEditViewModel toDoTaskEditViewModel);
    }
}
