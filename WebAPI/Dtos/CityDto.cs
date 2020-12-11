using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dtos
{
    public class CityDto
    {
         public int Id{get;set;}
        
        [Required (ErrorMessage="Name is mandatory")]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(".*[a-zA-z]+.*", ErrorMessage = "Only numerics are not allowed")]
        public string Name {get;set;}

        [Required]
        [RegularExpression(".*[a-zA-z]+.*", ErrorMessage = "Only numerics are not allowed")]
        public string Country {get;set;}

       
    }
}