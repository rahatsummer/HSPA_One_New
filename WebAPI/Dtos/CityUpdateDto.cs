using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dtos
{
    public class CityUpdateDto
    {
        
        
        [Required]
        public string Name {get;set;}

        

       
    }
}