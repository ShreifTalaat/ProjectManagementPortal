using AutoMapper;
using BLL.Interfaces;
using BLL.ModelViews;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITask _taskService;
        private readonly IMapper _mapper;

        public TaskController(ITask taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            var tasks = _taskService.GetTasks();
            return Ok(_mapper.Map<List<TaskMV>>(tasks));
        }

        [HttpPost]
        public IActionResult AddTask([FromBody] TaskMV model)
        {
            var result = _taskService.AddTask(_mapper.Map<DAL.Models.Task>(model));
            return result > 0 ? Ok(result) : BadRequest("Failed to add task");
        }
    }
}
