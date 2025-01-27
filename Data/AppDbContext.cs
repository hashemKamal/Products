using Microsoft.EntityFrameworkCore;
using ProductsCRUD.Data.Models;


namespace ProductsCRUD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<ProductCRUD> Products { get; set; }
    }

}