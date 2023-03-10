using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrelloskyBack.Domain.Behaviors.TaskTrello;
using TrelloskyBack.Domain.Models;
using TrellosKyBackAPI.Commands.Task;
using TrellosKyBackAPI.Queries.Task;
using TrellosKyBackAPI.ViewModels.Task;

namespace TrellosKyBackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskQueries _Queries;
        private readonly ITaskBehavior _Behavior;
        private readonly IMapper _mapper;

        public TaskController(
            ITaskQueries Queries,
            ITaskBehavior Behavior,
            IMapper mapper
            )
        {
            _Queries = Queries;
            _Behavior = Behavior;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ///
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<TaskViewModel>>> GetAllAsync()
        {
            List<TaskViewModel> lstTask = new List<TaskViewModel>();

            lstTask = await _Queries.GetAllAsync();

            return lstTask;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        /// 
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Route("FindByIdAsync/{taskId}")]
        public async Task<ActionResult<TaskViewModel>> FindByIdAsync(int taskId)
        {
            TaskViewModel task = await  _Queries.FindByIdAsync(taskId);

            return task;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="createTaskCommand"></param>
        /// <returns></returns>
        /// 
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost]
        [Route("CreateTask")]
        [ProducesResponseType(204)]
        public async Task<TaskViewModel> CreateTaskAsync(CreateTaskCommand createTaskCommand)
        {
            TaskT newTask = _mapper.Map<TaskT>(createTaskCommand);

            await _Behavior.CreateTaskAsync(newTask);

            TaskViewModel taskViewModel = await _Queries.FindByIdAsync(newTask.Id);

            return taskViewModel;

        }


        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPut]
        [Route("UpdateTask")]
        [ProducesResponseType(204)]
        public async Task<TaskViewModel> UpdateTaskAsync(UpdateTaskCommand updateTaskCommand)
        {
            TaskT existingTask = _mapper.Map<TaskT>(updateTaskCommand);

            await _Behavior.UpdateTaskAsync(existingTask);

            TaskViewModel taskViewModel = await _Queries.FindByIdAsync(existingTask.Id);

            return taskViewModel;

        }


        [EnableCors("_myAllowSpecificOrigins")]
        [HttpDelete]
        [Route("DeleteTask")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<int>> DeleteTaskAsync(int id)
        {
            TaskViewModel existingTask = await  _Queries.FindByIdAsync(id);

            if (existingTask == null)
            {
                return NotFound("Task not found");
            }

            TaskT deleteTask = _mapper.Map<TaskT>(existingTask);

            await _Behavior.DeleteTaskAsync(deleteTask);

            return id;
        }

    }
}
