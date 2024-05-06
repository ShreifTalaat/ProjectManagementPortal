using DAL.Models;

namespace BLL.Interfaces
{
    public interface ITask
    {
        int AddTask(DAL.Models.Task model);
        List<DAL.Models.Task> GetRelatedTasks(int ProjecId);

    }
}
