using Tasks.IRepositories;
using Tasks.IServices;

namespace Tasks.Services
{
    public class ToDoService : IToDoTaskService
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;
        public ToDoService(IToDoTaskRepository toDoTaskRepository)
        {
            _toDoTaskRepository = toDoTaskRepository;
        }
    }
}
