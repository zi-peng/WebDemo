using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebDemo.Controllers
{
    //需要验证JWT
    [Authorize]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        //不需要验证JWT
        [HttpGet("Index")]
        public IActionResult Index()
        {
            string a = "";
            return Ok(a);
        }        
        [HttpGet("Get")]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary ="111"
            })
            .ToArray();
        }
    }
}
