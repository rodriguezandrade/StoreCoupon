using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Repositories.Utils
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }

        private protected RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public async Task<IQueryable<T>> FindAll()
        {
            var query = await this.RepositoryContext.Set<T>().AsNoTracking().ToListAsync();
            return query.AsQueryable();
        }

        public async Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            var query = await this.RepositoryContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
            return query.AsQueryable();
        }

        public async void Create(T entity)
        {
            await RepositoryContext.Set<T>().AddAsync(entity);
            SaveChanges();
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
            SaveChanges();
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
            SaveChanges();
        }

        public void SaveChanges()
        {
            RepositoryContext.SaveChanges();
        }
    }
}
