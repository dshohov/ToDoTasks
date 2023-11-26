using Microsoft.AspNetCore.Mvc;
using Tasks.IServices;
using Tasks.ViewModels;

namespace Tasks.Controllers
{
    public class ToDoTaskController : Controller
    {
        private readonly IToDoTaskService _toDoTaskService;
        public ToDoTaskController(IToDoTaskService toDoTaskService)
        {
            _toDoTaskService = toDoTaskService;
        }
        [HttpGet]
        public async Task<IActionResult> CurrentTasks()
        {
            var currentTasks = await _toDoTaskService.GetCurrentTasksInServiceAsync();
            return View(currentTasks);
        }
        [HttpGet]
        public async Task<IActionResult> CompletedTasks()
        {
            var comletedTasks = await _toDoTaskService.GetCompletedTasksInServiceAsync();
            return View(comletedTasks);
        }
        public IActionResult Error()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateToDoTask()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateToDoTaskAsync(ToDoTaskCreateViewModel toDoTaskCreateViewModel)
        {
            if(await _toDoTaskService.CreateToDoTaskPost(toDoTaskCreateViewModel))
                return RedirectToAction("CurrentTasks");
            else
                return RedirectToAction("Error");

        }
    }
}
