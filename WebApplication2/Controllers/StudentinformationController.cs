using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class StudentinformationController: GenericController<Studentinformation>
    {
        public StudentinformationController(StudentInformationService service) : base(service)
        {
        }
    }
}
