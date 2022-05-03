using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Student 
    {
       
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FristName { get; set; }

        [MaxLength(100)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }


    }
}
