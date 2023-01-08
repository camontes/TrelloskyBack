using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrelloskyBack.Domain.Models;
using TrelloskyBack.Domain.Repositories.TaskTrello;

namespace TrellosKyBackAPI.Infrastructure.Repositories.TaskTrello
{
    public class TaskRepository : ITaskRepository
    {
        protected readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateTaskAsync(TaskT task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(TaskT task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(TaskT task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

    }
}
