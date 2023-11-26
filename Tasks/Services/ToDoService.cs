using Microsoft.Identity.Client;
using Tasks.IRepositories;
using Tasks.IServices;
using Tasks.Models;
using Tasks.ViewModels;

namespace Tasks.Services
{
    public class ToDoService : IToDoTaskService
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;
        public ToDoService(IToDoTaskRepository toDoTaskRepository)
        {
            _toDoTaskRepository = toDoTaskRepository;
        }

        public async Task<List<ToDoTask>> GetCurrentTasksInServiceAsync()
        {
            return await _toDoTaskRepository.GetCurrentToDoTaskAsync();
        }
        public async Task<List<ToDoTask>> GetCompletedTasksInServiceAsync()
        {
            return await _toDoTaskRepository.GetCompletedToDoTaskAsync();
        }
        public async Task<bool> CreateToDoTaskPost(ToDoTaskCreateViewModel toDoTaskCreateViewModel)
        {
            if(toDoTaskCreateViewModel != null)
            {
                var toDoTask = new ToDoTask { Name = toDoTaskCreateViewModel.Name, Description = toDoTaskCreateViewModel.Description};
                return await _toDoTaskRepository.AddToDoTasksync(toDoTask);
            }
            return false;
        }
    }
}
