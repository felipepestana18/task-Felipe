using Microsoft.AspNetCore.Mvc;
using taskFelipe.Data.ValueObject;

namespace taskFelipe.Controllers
{
    [ApiController]
    [Route("api/v1/task/")]
    public class ClienteController : Controller
    {
        readonly ITaskRepository _taskRepository;

        public ClienteController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet("find-all")]
        public async Task<ActionResult<TaskVO>> GetAll()
        {
            var task = await _taskRepository.GetAll();
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpGet("get-task-filter")]
        public async Task<ActionResult<TaskVO>> GetTaskFilter(FilterVO vo)
        {
            var task = await _taskRepository.GetFilter(vo.Id, vo.Title, vo.page);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost("create")]
        public async Task<ActionResult<TaskVO>> Create(TaskVO vo)
        {
            var task = await _taskRepository.Create(vo);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPut("update")]
        public async Task<ActionResult<TaskVO>> Update(TaskVO vo)
        {
            var task = await _taskRepository.Update(vo);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var status = await _taskRepository.Delete(id);
            if (!status) BadRequest();
            return Ok(status);
        }


        [HttpPut("done/{id}")]
        public async Task<ActionResult<bool>> Done(int id)
        {
            var status = await _taskRepository.Done(id);
            if (!status) BadRequest();
            return Ok(status);
        }

    }
}