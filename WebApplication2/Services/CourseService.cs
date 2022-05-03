using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class CourseService
    {
        private readonly SchoolSystemDbContext context;

        public CourseService(SchoolSystemDbContext context)
        {
                this.context= context;
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
             return await context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseById(int id)
        {
            return await context.Courses.SingleOrDefaultAsync(c => c.Id == id);
        }
        
        public async Task AddCourse(Course course)
        {
            context.Courses.Add(course);
            await context.SaveChangesAsync();
         
        }

        public async Task UpdateCourse(Course course)
        {
            var result = await context.Courses.FirstOrDefaultAsync(x => x.Id == course.Id);
            if (result != null)
            {
                result.Name = course.Name;
                result.Description = course.Description;
                result.Credits = course.Credits;
                await context.SaveChangesAsync();
               
            }  
        }

        public async Task DeleteCourse(int id)
        {
            var result = await context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if(result!=null)
            {
                context.Courses.Remove(result);
                await context.SaveChangesAsync();
            }
        }

    }
}
