using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrellosKyBackAPI.Commands.Task
{
    public class CreateTaskCommand
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int TypeTaskId { get; set; }
    }
}
