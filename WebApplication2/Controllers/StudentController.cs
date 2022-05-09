using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : GenericController<Student>
    {
        public StudentController(StudentService service) : base(service)
        {
        }
    }
}
