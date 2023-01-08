using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrelloskyBack.Domain.Models;
using TrelloskyBack.Domain.Repositories.TaskTrello;

namespace TrelloskyBack.Domain.Behaviors.TaskTrello
{
    public class TaskBehavior : ITaskBehavior
    {
        protected readonly ITaskRepository _repository;
        public TaskBehavior(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateTaskAsync(TaskT task)
        {
            if (task is null) throw new ArgumentNullException(nameof(task));

            await _repository.CreateTaskAsync(task);
        }

        public async Task UpdateTaskAsync(TaskT task)
        {
            if (task is null) throw new ArgumentNullException(nameof(task));

            await _repository.UpdateTaskAsync(task);
        }

        public async Task DeleteTaskAsync(TaskT task)
        {
            if (task is null) throw new ArgumentNullException(nameof(task));

            await _repository.DeleteTaskAsync(task);
        }

    }
}
