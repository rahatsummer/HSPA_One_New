

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.Interfaces;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    [Authorize]
    public class CityController : BaseController
    {
        private readonly IUnitOfWork uow;

        
        private readonly IMapper mapper;

        public CityController(IUnitOfWork uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
           
        }

        [AllowAnonymous]

        // GET api/city
        [HttpGet("")]
        public async Task<IActionResult> GetCities()
        {
           
            var cities = await uow.CityRepository.GetCitiesAsync();

            var citiesDto = mapper.Map<IEnumerable<CityDto>>(cities);

           
            return Ok(citiesDto); 
        }

     

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

        [HttpPut("update/{id}")]
         public async Task<IActionResult> UpdateCity(int id, CityDto cityDto)
        {
            
                 if(id != cityDto.Id)
              return BadRequest("update not allowed");

            var cityFromDb = await uow.CityRepository.FindCity(id);
            if(cityFromDb == null)
                return BadRequest("update not allowed");

            cityFromDb.LastUpdatedBy = 1;
            cityFromDb.LastUpdated = DateTime.Now;
            mapper.Map(cityDto,cityFromDb);

            //throw new Exception("Some unknown error occured");
            await uow.SaveAsync();
            return StatusCode(200); 

        

           

        }

        [HttpPut("updateCityName/{id}")]
         public async Task<IActionResult> UpdateCity(int id, CityUpdateDto cityUpdateDto)
        {
            var cityFromDb = await uow.CityRepository.FindCity(id);
            cityFromDb.LastUpdatedBy = 1;
            cityFromDb.LastUpdated = DateTime.Now;
            mapper.Map(cityUpdateDto,cityFromDb);
            await uow.SaveAsync();
            return StatusCode(200); 

        }

        
        [HttpPatch("update/{id}")]
         public async Task<IActionResult> UpdateCityPatch(int id, JsonPatchDocument<City> cityToPatch)
        {
            var cityFromDb = await uow.CityRepository.FindCity(id);
            cityFromDb.LastUpdatedBy = 1;
            cityFromDb.LastUpdated = DateTime.Now;
            cityToPatch.ApplyTo(cityFromDb, ModelState);
            await uow.SaveAsync();
            return StatusCode(200); 

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