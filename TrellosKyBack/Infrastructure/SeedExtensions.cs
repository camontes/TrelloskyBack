using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrelloskyBack.Domain.Models;

namespace TrellosKyBackAPI.Infrastructure
{
    public static class SeedExtensions
    {
        public static readonly TypeTask[] TypeTasksSeed = new TypeTask[] {
            new TypeTask
            {
                Id = 1,
                Description =  "Todo",
            },
             new TypeTask
            {
                Id = 2,
                Description =  "InProgress",
            },
              new TypeTask
            {
                Id = 3,
                Description =  "Finished",
            }
        };

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeTask>().HasData(
               TypeTasksSeed
            );
        }
    }
}
