using Tasks.Models;

namespace Tasks.IServices
{
    public interface IToDoTaskService
    {
        Task<List<ToDoTask>> GetCurrentTasksInServiceAsync();
        Task<List<ToDoTask>> GetCompletedTasksInServiceAsync();
    }
}
