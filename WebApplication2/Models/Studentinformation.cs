using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Studentinformation
    {
        [Key]
        [ForeignKey("Student")]
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

    }
}
