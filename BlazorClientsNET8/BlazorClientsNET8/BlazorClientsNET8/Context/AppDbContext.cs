namespace BlazorClientsNET8.Context
{
    using BlazorClientsNET8.Shared.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ClientEntity> Clients { get; set; }
    }
}
