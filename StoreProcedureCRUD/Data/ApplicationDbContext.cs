using Microsoft.EntityFrameworkCore;
using StoreProcedureCRUD.Models;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace StoreProcedureCRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
