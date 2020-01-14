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

        public RepositoryBase(RepositoryContext repositoryContext)
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
           await this.RepositoryContext.Set<T>().AddAsync(entity);
        }

        public async void Update(T entity)
        {
          this.RepositoryContext.Set<T>().Update(entity);
          await this.RepositoryContext.SaveChangesAsync();
        }

        public async void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
            await this.RepositoryContext.SaveChangesAsync();
        }

        public async Task SaveChange() {
            await RepositoryContext.SaveChangesAsync();
        }
    }
}
