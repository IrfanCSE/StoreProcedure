using Microsoft.EntityFrameworkCore;

namespace test
{
    public class AppDbContextcopy : DbContext
    {
        // public AppDbContext(DbContextOptions options) : base(options)
        // {
        // }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer("Server=localhost;Database=master;User ID=SA;Password=Irfan@1996;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;");
        }
    }
}