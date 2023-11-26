using Microsoft.EntityFrameworkCore;
using Tasks.Data;
using Tasks.IRepositories;
using Tasks.Models;

namespace Tasks.Repositories
{
    public class ToDoTaskRepository : IToDoTaskRepository
    {
        private readonly ApplicationDbContext _context;
        public ToDoTaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddToDoTasksync(ToDoTask toDoTask)
        {
            await _context.AddAsync(toDoTask);
            return await SaveAsync();
        }

        public async Task<bool> DeleteToDoTask(ToDoTask toDoTask)
        {
            await Task.Run(() => _context.Remove(toDoTask));
            return await SaveAsync();
        }
        public async Task<bool> EditToDoTask(ToDoTask toDoTask)
        {
            
            await Task.Run(() => _context.Update(toDoTask));
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
        public async Task<List<ToDoTask>> GetCurrentToDoTaskAsync()
        {
            var currentTasks = await _context.ToDoTasks.Where(x=>x.IsCompleted == false).ToListAsync();
            return currentTasks;
        }
        public async Task<List<ToDoTask>> GetCompletedToDoTaskAsync()
        {
            var completedTasks = await _context.ToDoTasks.Where(x => x.IsCompleted == true).ToListAsync();
            return completedTasks;
        }
    }
}
