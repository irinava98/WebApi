using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
   
        public class Course 
        {
           
            public int Id { get; set; }

            [Required]
            [MaxLength(250)]
            public string Name { get; set; }

            public string Description { get; set; }

            [Required]
            public int Credits { get; set; }

        }
   
}
