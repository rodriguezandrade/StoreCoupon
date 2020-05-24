using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        { 
        }
        public DbSet<GeneralCategory> GeneralCategories { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<CouponDetail> CouponDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreCategoy> StoreCategories { get; set; }
        public DbSet<StoreCategoryDetail> StoresCategoryDetails { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
