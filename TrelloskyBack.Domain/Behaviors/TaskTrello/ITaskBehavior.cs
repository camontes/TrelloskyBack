using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrelloskyBack.Domain.Models;

namespace TrelloskyBack.Domain.Behaviors.TaskTrello
{
    public interface ITaskBehavior
    {
        Task CreateTaskAsync(TaskT task);
        Task UpdateTaskAsync(TaskT task);
        Task DeleteTaskAsync(TaskT task);
    }
}
