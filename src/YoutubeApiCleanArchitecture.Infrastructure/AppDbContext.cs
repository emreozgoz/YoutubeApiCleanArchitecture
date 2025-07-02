using Microsoft.EntityFrameworkCore;
using YoutubeApiCleanArchitecture.Domain.Entities.Customers;
using YoutubeApiCleanArchitecture.Domain.Entities.InvoiceItems;
using YoutubeApiCleanArchitecture.Domain.Entities.Invoices;
using YoutubeApiCleanArchitecture.Domain.Entities.Product;

namespace YoutubeApiCleanArchitecture.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        protected AppDbContext() { }

        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Invoice> Invoices { get; set; } = null!;
        public DbSet<InvoiceItem> InvoiceItem { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
