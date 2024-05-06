using DAL.Models;

namespace BLL.Interfaces
{
    public interface IProjectService
    {
        List<Project> GetProjects();
        int AddProject(Project model);
    }
}
