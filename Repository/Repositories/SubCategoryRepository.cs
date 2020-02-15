using Repository.Repositories.Interfaces;
using Repository.Models;
using Repository.Repositories.Utils;
using Repository.Data;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Models.Dtos;
using System.Linq;
using System.Data;
using System;
using System.Collections.Generic;

namespace Repository.Repositories
{
    public class SubCategoryRepository : RepositoryBase<SubCategory>, ISubCategoryRepository
    {
        RepositoryContext _contex;
        public SubCategoryRepository(RepositoryContext repositoryContex) : base(repositoryContex)
        {
            _contex = repositoryContex;
        }

         
    }
}
