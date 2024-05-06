using AutoMapper;
using BLL.Interfaces;
using BLL.ModelViews;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class TaskController : ControllerBase
    {
        private readonly ITask _taskService;
        private readonly IMapper _mapper;

        public TaskController(ITask taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("ListAll/{projectId}")]
        public IActionResult GetTasks([FromRoute] int projectId)
        {
            var tasks = _taskService.GetRelatedTasks(projectId);
            return Ok(_mapper.Map<List<TaskMV>>(tasks));
        }



        [HttpPost]
        [Route("Add")]
        public IActionResult AddTask([FromBody] TaskMV model)
        {   
            var result = _taskService.AddTask(_mapper.Map<DAL.Models.Task>(model));
             if (result > 0)
            {
                return Ok(new { status = 1, data = result });
            }
            else
            {
                return BadRequest("Failed to add task");
            }
        }

    }
}
