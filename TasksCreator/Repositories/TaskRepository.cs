using Microsoft.EntityFrameworkCore;
using TasksCreator.Data;
using TasksCreator.Models;

namespace TasksCreator.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddTaskAsync(TaskEntity task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TaskEntity>> GetTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }
    }
}
