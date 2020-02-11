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

        public async Task<IQueryable<SubCategoryDto>> Get() {
            DataTable ownerDT = new DataTable();
            _contex.Database.OpenConnection();
            SqlConnection conn = (SqlConnection)_contex.Database.GetDbConnection();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.spSubCategories_GetInfo";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ownerDT);
            List<SubCategoryDto> subCategories = new List<SubCategoryDto>();
            foreach (DataRow dr in ownerDT.Rows) {
                SubCategoryDto sc = new SubCategoryDto();
                sc.Id = (Guid)dr["Id"];
                sc.Name = dr["Name"].ToString();
                sc.Description = dr["Description"].ToString();
                sc.Category = dr["Category"].ToString();
                subCategories.Add(sc);
  
            }
            
            conn.Close();
            return subCategories.AsQueryable();
        }
    }
}
