using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class TeacherController: GenericController<Teacher>
    {
        public TeacherController(TeacherService service) : base(service)
        {
        }
    }
}
