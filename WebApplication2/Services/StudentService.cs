using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class StudentService : IGenericService<Student>
    {
        private readonly SchoolSystemDbContext context;

        public StudentService(SchoolSystemDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await context.Students.ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await context.Students.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task Add(Student item)
        {
            context.Students.Add(item);
            await context.SaveChangesAsync();
        }

        public async Task Update(Student item)
        {
            var result = await context.Students.FirstOrDefaultAsync(x => x.Id == item.Id);
            if (result != null)
            {
                result.FristName=item.FristName;
                result.MiddleName=item.MiddleName; 
                result.LastName=item.LastName;
                result.Birthdate=item.Birthdate;
                await context.SaveChangesAsync();

            }
        }

        public async Task DeleteById(int id)
        {
            var result = await context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                context.Students.Remove(result);
                await context.SaveChangesAsync();
            }
        }
    }
}
