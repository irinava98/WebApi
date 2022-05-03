using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class TeacherCourse
    {

        [Required]
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }


        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; }
    }
}
