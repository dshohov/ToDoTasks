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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateToDoTaskAsync(ToDoTaskCreateViewModel toDoTaskCreateViewModel)
        {
            if(await _toDoTaskService.CreateToDoTaskPost(toDoTaskCreateViewModel))
                return RedirectToAction("CurrentTasks");
            else
                return RedirectToAction("Error");
        }        
        public async Task<IActionResult> ChangeStateTask(int idTask, bool stateTaskNow)
        {
            if(await _toDoTaskService.ChangeStateToDoTask(idTask))
            {
                if(stateTaskNow)
                    return RedirectToAction("CompletedTasks");
                else
                    return RedirectToAction("CurrentTasks");
            }                
            else
                return RedirectToAction("Error");
        }
        
        public async Task<IActionResult> DeleteToDoTask(int idTask, bool stateTaskNow)
        {
            if(await _toDoTaskService.DeleteToDoTask(idTask))
            {
                if (stateTaskNow)
                    return RedirectToAction("CompletedTasks");
                else
                    return RedirectToAction("CurrentTasks");
            }
            else
                return RedirectToAction("Error");
        }
        [HttpGet]
        public async Task<IActionResult> EditToDoTask(int idTask)
        {
            var toDoTaskEditViewModel = await _toDoTaskService.GetToDoTaskEditViewModel(idTask);
            if(toDoTaskEditViewModel.Id != 0)
            {
                return View(toDoTaskEditViewModel);
            }
            return RedirectToAction("Error");
            
        }
        [HttpPost]
        public async Task<IActionResult> EditToDoTaskAsync(ToDoTaskEditViewModel toDoTaskEditViewModel)
        {
            if(ModelState.IsValid)
            {
                if (await _toDoTaskService.EditToDoTaskAsync(toDoTaskEditViewModel))
                    return RedirectToAction("CurrentTasks");
            }

            return RedirectToAction("Error");
        }
    }
}
