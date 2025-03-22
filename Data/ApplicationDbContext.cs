using Microsoft.EntityFrameworkCore;
using train_odata_controller_sever.Models;

namespace train_odata_controller_sever.Data
{
    public class ApplicationDbContext (DbContextOptions options) :DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
    }
}
