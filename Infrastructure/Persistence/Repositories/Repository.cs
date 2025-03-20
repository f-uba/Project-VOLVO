using Application.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    internal class Repository<T>(AppDbContext context) : IRepository<T> where T : class
    {
        protected AppDbContext _context = context;

        public virtual async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual IQueryable<T> Get()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
        }
    }
}
