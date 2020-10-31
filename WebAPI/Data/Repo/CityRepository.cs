using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Data.Repo
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext dc;
        public CityRepository(DataContext dc)
        {
            this.dc = dc;

        }
        public void AddCity(City city)
        {
           dc.Cities.Add(city);
        }

        public void DeleteCity(int CityId)
        {
            var cityToDelete = dc.Cities.Find(CityId);
            dc.Cities.Remove(cityToDelete);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await dc.Cities.ToListAsync();
        }
    
    }
}