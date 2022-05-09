using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class TeacherService:IGenericService<Teacher>
    {
        private readonly SchoolSystemDbContext context;

        public TeacherService(SchoolSystemDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Teacher>> GetAll()
        {
            return await context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetById(int id)
        {
            return await context.Teachers.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task Add(Teacher item)
        {
            context.Teachers.Add(item);
            await context.SaveChangesAsync();
        }

        public async Task Update(Teacher item)
        {
            var result = await context.Teachers.FirstOrDefaultAsync(x => x.Id == item.Id);
            if (result != null)
            {
                result.FirstName = item.FirstName;
                result.MiddleName = item.MiddleName;
                result.LastName = item.LastName;
                result.Age = item.Age;
                result.IsActive = item.IsActive;
                await context.SaveChangesAsync();

            }
        }

        public async Task DeleteById(int id)
        {
            var result = await context.Teachers.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                context.Teachers.Remove(result);
                await context.SaveChangesAsync();
            }
        }
    }
}
