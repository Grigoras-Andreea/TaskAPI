using for_task.Models;

namespace for_task.Services
{
    public interface ITaskCollectionService : ICollectionService<TaskModel>
    {
        Task<List<TaskModel>> GetTasksByStatus(string status);
    }
}
