using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrellosKyBackAPI.ViewModels.Task;

namespace TrellosKyBackAPI.Queries.Task
{
    public interface ITaskQueries
    {
        Task<List<TaskViewModel>> GetAllAsync();
        Task<TaskViewModel> FindByIdAsync(int taskId);
    }
}
