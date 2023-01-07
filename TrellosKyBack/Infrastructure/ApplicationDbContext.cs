using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrelloskyBack.Domain.Models;

namespace TrellosKyBackAPI.Infrastructure
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<TypeTask> TypeTasks { get; set; }

        public DbSet<TaskT> Tasks{ get; set; }
    }
}
