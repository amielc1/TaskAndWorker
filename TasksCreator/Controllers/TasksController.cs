using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TasksCreator.Services;

namespace TasksCreator.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TasksController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost("generate/{amount}")]
        public async Task<IActionResult> GenerateTasks(int amount)
        {
            await _taskService.GenerateRandomTasksAsync(amount);
            return Ok(new { message = $"{amount} tasks generated." });
        }
    }
}
