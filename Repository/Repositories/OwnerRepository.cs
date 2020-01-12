using Repository.Data;
using Repository.Models;
using Repository.Repositories.Interfaces;
using Repository.Repositories.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
     public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        
        public OwnerRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
        }
    }
}
