using TasksCreator.Models;

namespace TasksCreator.Repositories
{
    public class MockTaskRepository : ITaskRepository
    {
        private readonly List<TaskEntity> _tasks = new();

        public Task AddTaskAsync(TaskEntity task)
        {
            task.TaskId = _tasks.Count + 1;
            _tasks.Add(task);
            return Task.CompletedTask;
        }

        public Task<List<TaskEntity>> GetTasksAsync()
        {
            return Task.FromResult(_tasks);
        }
    }
}
