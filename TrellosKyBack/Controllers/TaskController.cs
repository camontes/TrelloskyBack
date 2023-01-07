using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrellosKyBackAPI.Queries.Task;
using TrellosKyBackAPI.ViewModels.Task;

namespace TrellosKyBackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskQueries _Queries;
        private readonly IMapper _mapper;

        public TaskController(
            ITaskQueries Queries,
            IMapper mapper
            )
        {
            _Queries = Queries;
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

    }
}
