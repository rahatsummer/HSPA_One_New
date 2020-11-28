using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dtos
{
    public class CityDto
    {
         public int Id{get;set;}
        
        [Required]
        public string Name {get;set;}

        public string Country {get;set;}

       
    }
}