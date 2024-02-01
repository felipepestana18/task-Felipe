using Microsoft.AspNetCore.Mvc;
using taskFelipe.Data.ValueObject;

namespace taskFelipe.Controllers
{
    [ApiController]
    [Route("api/v1/Task/")]
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
            var clientes = await _taskRepository.GetAll();
            if (clientes == null) return NotFound();
            return Ok(clientes);
        }

        [HttpGet("find-by-id/{id}")]
        public async Task<ActionResult<TaskVO>> GetById(int id)
        {
            var cliente = await _taskRepository.GetById(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost("create")]
        public async Task<ActionResult<TaskVO>> Create(TaskVO vo)
        {
            var cliente = await _taskRepository.Create(vo);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPut("update")]
        public async Task<ActionResult<TaskVO>> Update(TaskVO vo)
        {
            var cliente = await _taskRepository.Update(vo);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpDelete("delete{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var status = await _taskRepository.Delete(id);
            if (!status) BadRequest();
            return Ok(status);
        }


        [HttpDelete("delete{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var status = await _taskRepository.Delete(id);
            if (!status) BadRequest();
            return Ok(status);
        }

    }
}