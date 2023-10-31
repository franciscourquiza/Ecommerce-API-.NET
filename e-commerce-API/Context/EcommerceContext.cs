using e_commerce_API.Data.Entities;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_API.Context
{
    public class EcommerceContext : DbContext
    {
        private readonly string _connectionString;
        public EcommerceContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString,
            sqliteOptionsAction: config => // Le decimos a EntityFramework que si la Base de Datos no está, la cree
            {
                config.MigrationsAssembly(Assembly.GetAssembly(typeof(EcommerceContext)).FullName);
            });
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<SuperAdmin> SuperAdmins { get; set; } 
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);
            base.OnModelCreating(modelBuilder);
        }

    }
}
