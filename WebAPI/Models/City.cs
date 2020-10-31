using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class City
    {
        public int Id{get;set;}
        
        [Required]
        public string Name {get;set;}

        public DateTime LastUpdated {get;set;}

        public int LastUpdatedBy {get;set;}
    }
}