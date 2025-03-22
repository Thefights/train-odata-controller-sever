using Microsoft.EntityFrameworkCore;

namespace train_odata_controller_sever.Data
{
    public class ApplicationDbContext (DbContextOptions options) :DbContext(options)
    {
        //public DbSet<Train> Trains { get; set; } = null!;
    }
}
