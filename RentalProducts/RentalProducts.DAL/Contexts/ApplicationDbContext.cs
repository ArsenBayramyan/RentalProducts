using Microsoft.EntityFrameworkCore;
using RentalProducts.DAL.Models;

namespace RentalProducts.DAL.Contexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
