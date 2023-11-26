using Microsoft.AspNetCore.Mvc;
using Tasks.IServices;

namespace Tasks.Controllers
{
    public class ToDoTaskController : Controller
    {
        private readonly IToDoTaskService _toDoTaskService;
        public ToDoTaskController(IToDoTaskService toDoTaskService)
        {
            _toDoTaskService = toDoTaskService;
        }

        public async Task<IActionResult> CurrentTasks()
        {
            var currentTasks = await _toDoTaskService.GetCurrentTasksInServiceAsync();
            return View(currentTasks);
        }
        public async Task<IActionResult> CompletedTasks()
        {
            var comletedTasks = await _toDoTaskService.GetCompletedTasksInServiceAsync();
            return View(comletedTasks);
        }
    }
}
