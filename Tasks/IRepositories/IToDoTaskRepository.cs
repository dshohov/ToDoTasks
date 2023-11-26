using Tasks.Models;

namespace Tasks.IRepositories
{
    public interface IToDoTaskRepository
    {
        Task<bool> AddToDoTasksync(ToDoTask toDoTask);
        Task<bool> DeleteToDoTask(ToDoTask toDoTask);
        Task<bool> EditToDoTask(ToDoTask toDoTask);
        Task<bool> SaveAsync();
        Task<List<ToDoTask>> GetCurrentToDoTaskAsync();
        Task<List<ToDoTask>> GetCompletedToDoTaskAsync();

    }
}
