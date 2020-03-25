using Repository.Data;
using Repository.Models;
using Repository.Repositories.Interfaces;
using Repository.Repositories.Utils;

namespace Repository.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {

        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
