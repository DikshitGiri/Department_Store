using DepartmentStore.Models;
using Microsoft.EntityFrameworkCore;


namespace DepartmentStore.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Register> register { get; set; }
        public DbSet<Login> login { get; set; }
        public DbSet<Entry> entry { get; set; }
    }
}
