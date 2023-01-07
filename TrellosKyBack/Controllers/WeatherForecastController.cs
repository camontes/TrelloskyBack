using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrelloskyBack.Domain.Models;
using TrellosKyBackAPI.Infrastructure;
using TrellosKyBackAPI.ViewModels.TypeTask;

namespace TrellosKyBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        protected readonly ApplicationDbContext _context;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<List<TypeTaskViewModel>> Get()
        {
            List<TypeTaskViewModel> lstType = await  _context.TypeTasks
                                                       .Select(x => new TypeTaskViewModel() { 
                                                           Id = x.Id,
                                                           Description = x.Description
                                                       })
                                                       .ToListAsync();

            return lstType;
        }
    }
}
