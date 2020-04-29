using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using Repository.Repositories.Interfaces;
using Repository.Repositories.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserDetailRepository : RepositoryBase<UserDetail>, IUserDetailRepository
    {
        public UserDetailRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        //Call Stored Procedures StpGetOwners
        public async Task<IQueryable<UserDetail>> GetOwners()
        {
            var query = await this.RepositoryContext.UserDetails.FromSqlRaw("stpGetOwners").ToListAsync();
            return query.AsQueryable();
        }
    }
}
