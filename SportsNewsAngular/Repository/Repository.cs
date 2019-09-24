using System.Collections.Generic;
using System.Threading.Tasks;
using SportsNewsAngular.Models;
using Microsoft.EntityFrameworkCore;

namespace SportsNewsAngular.Repository
{
    public class Repository<ApplicationDbContext> : IRepository where ApplicationDbContext : DbContext
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext dbcontext)
        {
            context = dbcontext;
        }

        public async Task CreateAsync<T>(T entity) where T : Entity
        {
            context.Set<T>().Add(entity);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : Entity
        {
            context.Set<T>().Remove(entity);

            await context.SaveChangesAsync();
        }

        public async Task<List<T>> FindAll<T>() where T : Entity
        {
            var entity = await context.Set<T>().ToListAsync();
            return entity;
        }

        public async Task<T> FindById<T>(int id) where T : Entity
        {
            return await context.Set<T>().FirstOrDefaultAsync(i => i.Id == id && i.IsShow == true);
        }

        public async Task<List<T>> FindShowed<T>() where T : Entity
        {
            var entity = await context.Set<T>().ToListAsync();
            return entity.FindAll(e => e.IsShow == true);
        }

        public async Task UpdateAsync<T>(T entity) where T : Entity
        {
            context.Set<T>().Update(entity);

            await context.SaveChangesAsync();
        }
    }
}
