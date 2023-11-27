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
                return await _toDoTaskRepository.AddToDoTaskAsync(toDoTask);
            }
            return false;
        }
        public async Task<bool> ChangeStateToDoTask(int idTask)
        {
            var toDoTask = await _toDoTaskRepository.GetToDoTaskByIdAsync(idTask);
            if(toDoTask != null)
            {
                toDoTask.IsCompleted = !toDoTask.IsCompleted;
                return await _toDoTaskRepository.EditToDoTaskAsync(toDoTask);
            }
            return false;
        }
        
        public async Task<bool> DeleteToDoTask(int idTask)
        {
            var toDoTask = await _toDoTaskRepository.GetToDoTaskByIdAsync(idTask);
            if (toDoTask != null)
            {
                return await _toDoTaskRepository.DeleteToDoTaskAsync(toDoTask);
            }
            return false;
        }

        public async Task<ToDoTaskEditViewModel> GetToDoTaskEditViewModel(int idTask)
        {
            var toDoTask = await _toDoTaskRepository.GetToDoTaskByIdAsync(idTask);
            if(toDoTask != null)
            {
                var toDoTaskEditViewModel = new ToDoTaskEditViewModel() { Id = toDoTask.Id, Name = toDoTask.Name, Description = toDoTask.Description };
                return toDoTaskEditViewModel;
            }
            else
            {
                var toDoTaskEditViewModel = new ToDoTaskEditViewModel();
                return toDoTaskEditViewModel;
            }            
        }
        public async Task<bool> EditToDoTaskAsync(ToDoTaskEditViewModel toDoTaskEditViewModel)
        {
            var toDoTask = await _toDoTaskRepository.GetToDoTaskByIdAsync(toDoTaskEditViewModel.Id);
            if (toDoTask != null)
            {
                toDoTask.Name = toDoTaskEditViewModel.Name;
                toDoTask.Description = toDoTaskEditViewModel.Description;
                return await _toDoTaskRepository.EditToDoTaskAsync(toDoTask);
            }
            return false;
        }
    }
}
