using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrellosKyBackAPI.Infrastructure;
using TrellosKyBackAPI.ViewModels.Task;

namespace TrellosKyBackAPI.Queries.Task
{
    public class TaskQueries : ITaskQueries
    {
        protected readonly ApplicationDbContext _context;

        public TaskQueries(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all data from Tasks table
        /// </summary>
        /// <returns></returns>
        public async Task<List<TaskViewModel>> GetAllAsync()
        {
            List<TaskViewModel> lstTask = new List<TaskViewModel>();

            lstTask = await _context.Tasks
                                    .Select(x => new TaskViewModel()
                                    {
                                        Id = x.Id,
                                        Description = x.Description,
                                        TypeTaskId = x.TypeTaskId
                                    })
                                    .ToListAsync();
                        

            return lstTask;
        }


        /// <summary>
        /// Search an element from Tasks table
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public async Task<TaskViewModel> FindByIdAsync(int taskId)
        {
            TaskViewModel task = await _context.Tasks
                                         .AsNoTracking()
                                         .Select(x => new TaskViewModel() { 
                                             Id  = x.Id,
                                             Description = x.Description,
                                             TypeTaskId = x.TypeTaskId
                                         })
                                         .FirstOrDefaultAsync(x => x.Id == taskId);

            return task;
        }
    }
}
