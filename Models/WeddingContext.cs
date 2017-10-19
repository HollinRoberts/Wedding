using Microsoft.EntityFrameworkCore;

 
namespace Wedding.Models
{
    public class WeddingContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public WeddingContext(DbContextOptions<WeddingContext> options) : base(options) { }
        public DbSet<User> user { get; set; }
        public DbSet<WeddingPlan> weddings { get; set; }
        public DbSet<Guestlist> guestlist { get; set; }
    }
}
