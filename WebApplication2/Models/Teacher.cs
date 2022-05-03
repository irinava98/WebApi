using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

    }
}
