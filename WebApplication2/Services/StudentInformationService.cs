using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class StudentInformationService: IGenericService<Studentinformation>
    {
        private readonly SchoolSystemDbContext context;

        public StudentInformationService(SchoolSystemDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Studentinformation>> GetAll()
        {
            return await context.Studentinformations.ToListAsync();
        }

        public async Task<Studentinformation> GetById(int id)
        {
            return await context.Studentinformations.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task Add(Studentinformation item)
        {
            context.Studentinformations.Add(item);
            await context.SaveChangesAsync();
        }

        public async Task Update(Studentinformation item)
        {
            var result = await context.Studentinformations.FirstOrDefaultAsync(x => x.Id == item.Id);
            if (result != null)
            {
                result.Id = item.Id;
                result.CreationDate = item.CreationDate;
                await context.SaveChangesAsync();

            }
        }

        public async Task DeleteById(int id)
        {
            var result = await context.Studentinformations.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                context.Studentinformations.Remove(result);
                await context.SaveChangesAsync();
            }
        }
    }
}
