using Microsoft.EntityFrameworkCore;

namespace test
{
    public class AppDbContext : DbContext
    {
        // public AppDbContext(DbContextOptions options) : base(options)
        // {
        // }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer("Server=localhost;Database=master;User ID={user};Password={password};Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;");
        }
    }
}