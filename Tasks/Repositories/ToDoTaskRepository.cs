using Tasks.Data;
using Tasks.IRepositories;

namespace Tasks.Repositories
{
    public class ToDoTaskRepository : IToDoTaskRepository
    {
        private readonly ApplicationDbContext _context;
        public ToDoTaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
