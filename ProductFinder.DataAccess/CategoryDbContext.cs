using System;
using Microsoft.EntityFrameworkCore;
using ProductFinder.Entities;

namespace ProductFinder.DataAccess
{
	public class CategoryDbContext : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost; Database=ProductDb; uid=SA; pwd=reallyStrongPwd123; TrustServerCertificate=true");


        }

        public DbSet<Category> Categories { get; set; }
    }
}

