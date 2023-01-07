using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloskyBack.Domain.Models
{
    public class TypeTask
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        public List<TaskT> Tasks { get; set; }           
    }
}
