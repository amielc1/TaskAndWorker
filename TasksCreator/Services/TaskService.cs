using System.Text.Json;
using TasksCreator.Models;
using TasksCreator.Repositories;

namespace TasksCreator.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _taskRepository;
        private static readonly Random _random = new();

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task GenerateRandomTasksAsync(int amount)
        {
            var taskTypes = new List<string> { "is_prime", "fibonacci_nth", "is_anagram", "how_many_anagrams" };

            for (int i = 0; i < amount; i++)
            {
                string taskType = taskTypes[_random.Next(taskTypes.Count)];
                string jsonInput = GenerateJsonInput(taskType);

                var task = new TaskEntity
                {
                    TaskName = taskType,
                    JsonInput = jsonInput,
                    Status = "PENDING",
                    CreatedAt = DateTime.UtcNow
                };

                await _taskRepository.AddTaskAsync(task);
            }
        }

        private string GenerateJsonInput(string taskType)
        {
            return taskType switch
            {
                "is_prime" => JsonSerializer.Serialize(new { number = _random.Next(1, 1000) }),
                "fibonacci_nth" => JsonSerializer.Serialize(new { index = _random.Next(1, 50) }),
                "is_anagram" => JsonSerializer.Serialize(new { s1 = "listen", s2 = "silent" }),
                "how_many_anagrams" => JsonSerializer.Serialize(new { s1 = "bcbc", s2 = "abcbcbca" }),
                _ => "{}"
            };
        }
    }
}
