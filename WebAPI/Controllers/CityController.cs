
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Data.Repo;
using WebAPI.Models;
//using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly DataContext dc;
        private readonly ICityRepository repo;
        public CityController(DataContext dc, ICityRepository repo)
        {
            this.repo = repo;
            this.dc = dc;
        }

        // GET api/city
        [HttpGet("")]
        public async Task<IActionResult> GetCities()
        {
            var cities = await repo.GetCitiesAsync();
            return Ok(cities);
        }

        // POST api/city/add?cityname=Miami
        // POST api/city/add/Los Angles
        // [HttpPost("add")]
        // [HttpPost("add/{cityname}")]

        // public async Task<IActionResult> AddCity(string cityName)
        // {
        //     City city = new City();
        //     city.Name = cityName;
        //     await dc.Cities.AddAsync(city);
        //     await dc.SaveChangesAsync();
        //     return Ok(city);
        // }

        // POST api/city/post -- post the data in json format

        [HttpPost("post")]
        public async Task<IActionResult> AddCity(City city)
        {
            
             repo.AddCity(city);
            await repo.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {

            repo.DeleteCity(id);
            await repo.SaveAsync();
            return Ok(id);
        }


    }
}