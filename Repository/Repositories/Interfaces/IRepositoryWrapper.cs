
using Repository.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICategoryRepository Category { get; }

        List<SubCategory> GetSubCategoriess();
        void save();
    }
}
