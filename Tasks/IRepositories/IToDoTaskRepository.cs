using Tasks.Models;

namespace Tasks.IRepositories
{
    public interface IToDoTaskRepository
    {
        Task<bool> AddToDoTaskAsync(ToDoTask toDoTask);
        Task<bool> DeleteToDoTaskAsync(ToDoTask toDoTask);
        Task<bool> EditToDoTaskAsync(ToDoTask toDoTask);
        Task<bool> SaveAsync();
        Task<List<ToDoTask>> GetCurrentToDoTaskAsync();
        Task<List<ToDoTask>> GetCompletedToDoTaskAsync();
        Task<ToDoTask> GetToDoTaskByIdAsync(int idTask);

    }
}
