using for_task.Models;
using for_task.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace for_task.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TaskController : ControllerBase
    {
        ITaskCollectionService? _taskCollectionService;

        public TaskController(ITaskCollectionService taskCollectionService)
        {
            _taskCollectionService = taskCollectionService ?? throw new ArgumentNullException(nameof(TaskCollectionService));
        }


        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            List<TaskModel> tasks = await _taskCollectionService.GetAll();
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskModel task)
        {
            task.Id = Guid.NewGuid();
            if (task == null)
            {
                return BadRequest();
            }
            if(task.Title == null || task.AssignedTo == null)
            {
                return BadRequest();
            }
            if(task.Title == "" || task.AssignedTo == "")
            {
                return BadRequest();
            }
            var newTask = await _taskCollectionService.Create(task);
            return Ok(newTask);
        }

        [HttpPut("{id}")]
        public async Task< IActionResult> UpdateTask(string id, [FromBody] TaskModel task)
        {
            var updatedTask = await _taskCollectionService.Update(Guid.Parse(id), task);
            if (task == null)
            {
                return BadRequest();
            }
            if (task.Title == null || task.AssignedTo == null)
            {
                return BadRequest();
            }
            if (task.Title == "" || task.AssignedTo == "")
            {
                return BadRequest();
            }
            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var deletedTask = await _taskCollectionService.Delete(id);
            return Ok(deletedTask);
        }
    }
}
