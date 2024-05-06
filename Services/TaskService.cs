using BLL.Interfaces;
using DAL.Models;

namespace BLL.Services
{
    public class TaskService :ITask
    {
        private readonly ProjectManagementDbContext _db;

        public TaskService(ProjectManagementDbContext db)
        {
            _db = db;
        }

        public int AddTask(DAL.Models.Task model)
        {
            int result = -1;
            try
            {
                _db.Tasks.Add(model);
                result = _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding task: {ex.Message}");
            }
            return result;
        }

        public List<DAL.Models.Task> GetRelatedTasks(int projectId)
        {
            try
            {
                return _db.Tasks.Where(t=>t.ProjectId==projectId).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting tasks: {ex.Message}");
            }
            return new List<DAL.Models.Task>();
        }
    }
}
