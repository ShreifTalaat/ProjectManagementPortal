using BLL.Interfaces;
using DAL.Models;

namespace BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ProjectManagementDbContext _db;

        public ProjectService(ProjectManagementDbContext db)
        {
            _db = db;
        }

        public int AddProject(Project model)
        {
            int result = -1;
            try
            {
                var existProject = _db.Projects.FirstOrDefault(u => u.Name.Trim() == model.Name.Trim());
                if (existProject != null)
                {
                    return -3;
                }
                _db.Projects.Add(model);
                result = _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding project: {ex.Message}");
            }
            return result;
        }

        public List<Project> GetProjects()
        {
            try
            {
                return _db.Projects.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting projects: {ex.Message}");
            }
            return new List<Project>();
        }
    }
}
