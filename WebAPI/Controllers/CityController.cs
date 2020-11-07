

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.Interfaces;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork uow;

        
        private readonly IMapper mapper;

        public CityController(IUnitOfWork uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
           
        }

        // GET api/city
        [HttpGet("")]
        public async Task<IActionResult> GetCities()
        {
            var cities = await uow.CityRepository.GetCitiesAsync();

            var citiesDto = mapper.Map<IEnumerable<CityDto>>(cities);

            // var citiesDto = from c in cities
            //                 select new CityDto()
            //                 {
            //                     Id = c.Id,
            //                     Name = c.Name,
            //                 };
            return Ok(citiesDto);
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
        public async Task<IActionResult> AddCity(CityDto cityDto)
        {
            var city = mapper.Map<City>(cityDto); // Now City is Destination & CityDto is the Source
            city.LastUpdatedBy = 1;
            city.LastUpdated = DateTime.Now;
            
            // var city = new City
            // {
            //     Name = cityDto.Name,
            //     LastUpdatedBy = 1,
            //     LastUpdated = DateTime.Now
            // };

            uow.CityRepository.AddCity(city);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {

            uow.CityRepository.DeleteCity(id);
            await uow.SaveAsync();
            return Ok(id);
        }


    }
}