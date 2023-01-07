using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrelloskyBack.Domain.Models;
using TrellosKyBackAPI.ViewModels.Task;

namespace TrellosKyBackAPI.Mappings.Task
{
    public class TaskMappings : Profile
    {
        public TaskMappings()
        {
            CreateMap<TaskT, TaskViewModel>();
            CreateMap<TaskViewModel, TaskT>();
        }
    }
}
