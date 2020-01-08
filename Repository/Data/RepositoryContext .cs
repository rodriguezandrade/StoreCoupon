﻿using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<CouponBook> CouponBooks { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<OwnerStore> OwnersStores { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
