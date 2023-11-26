using Microsoft.Identity.Client;
using Tasks.IRepositories;
using Tasks.IServices;
using Tasks.Models;

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
    }
}
