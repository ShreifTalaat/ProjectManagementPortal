using AutoMapper;
using BLL.Interfaces;
using BLL.ModelViews;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("ListAll")]

        public IActionResult GetProjects()
        {
            var projects = _projectService.GetProjects();
            return Ok(_mapper.Map<List<ProjectMV>>(projects));
        }

        [HttpPost]
        [Route("Add")]

        public IActionResult AddProject([FromBody] ProjectMV model)
        {
            var result = _projectService.AddProject(_mapper.Map<Project>(model));
            if (result == -3)
            {
                return Ok(new { data= -3, message = "Project with the same name already exists" });
            }
            else if (result > 0)
            {
                return Ok(new { status = 1, data = result });
            }
            else
            {
                return BadRequest("Failed to add project");
            }
        }

    }
}
