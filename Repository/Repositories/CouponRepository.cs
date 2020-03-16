using Repository.Data;
using Repository.Models;
using Repository.Repositories.Interfaces;
using Repository.Repositories.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
     public class CouponRepository : RepositoryBase<Coupon>, ICouponRepository
    {
        public CouponRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
