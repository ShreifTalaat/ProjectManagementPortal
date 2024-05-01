using AutoMapper;
using BLL.Interfaces;
using BLL.ModelViews;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public IActionResult GetProjects()
        {
            var projects = _projectService.GetProjects();
            return Ok(_mapper.Map<List<ProjectMV>>(projects));
        }

        [HttpPost]
        public IActionResult AddProject([FromBody] ProjectMV model)
        {
            var result = _projectService.AddProject(_mapper.Map<Project>(model));
            return result > 0 ? Ok(result) : BadRequest("Failed to add project");
        }
    }
}
