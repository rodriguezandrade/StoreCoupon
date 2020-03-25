using Repository.Data;
using Repository.Models;
using Repository.Repositories.Interfaces;
using Repository.Repositories.Utils;
using System;

namespace Repository.Repositories
{
    public class CategoryRepository : RepositoryBase<CategoryStore>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
        }
    }
}
