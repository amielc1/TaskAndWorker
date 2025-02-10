using TasksCreator.Models;

namespace TasksCreator.Repositories
{
    public interface ITaskRepository
    {
        Task AddTaskAsync(TaskEntity task);
        Task<List<TaskEntity>> GetTasksAsync();
    }
}
