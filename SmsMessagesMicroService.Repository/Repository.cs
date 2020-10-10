using Microsoft.EntityFrameworkCore;
using SmsMessagesMicroService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmsMessagesMicroService.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MessagesDbContext Context;

        public Repository(MessagesDbContext context)
        {
            Context = context;
        }

        public async Task<T> GetById(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
    }
}
