using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class CourseService:IGenericService<Course>
    {
        private readonly SchoolSystemDbContext context;

        public CourseService(SchoolSystemDbContext context)
        {
                this.context= context;
        }
       
        public async Task<IEnumerable<Course>> GetAll()
        {
            return await context.Courses.ToListAsync();
        }

        public async Task<Course> GetById(int id)
        {
            return await context.Courses.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task Add(Course item)
        {
            context.Courses.Add(item);
            await context.SaveChangesAsync();
        }

        public async Task Update(Course item)
        {
            var result = await context.Courses.FirstOrDefaultAsync(x => x.Id == item.Id);
            if (result != null)
            {
                context.Courses.Update(item);
                await context.SaveChangesAsync();

            }
        }

        public async Task DeleteById(int id)
        {
            var result = await context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                context.Courses.Remove(result);
                await context.SaveChangesAsync();
            }
        }
    }
}
