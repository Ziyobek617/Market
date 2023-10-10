using Market.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Market.DbContexts;

public class AppDbContext : DbContext
{
    public DbSet<Order> orders {  get; set; }
    public DbSet<Customer> customers { get; set; }
    public DbSet<Product> products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost; Port=5432; Database=MarketDb; User Id=postgres; Password=Mahkamov");
    }
}
