using Microsoft.EntityFrameworkCore;
using YuGiOhForbiddenAPI.Entities;
using YuGiOhForbiddenAPI.Model;

namespace YuGiOhForbiddenAPI.Persistence
{
    public class YuGiOhDbContext : DbContext
    {
        public DbSet<Card> Card { get; set; }
        public DbSet<Monster> Monster { get; set; }
        public DbSet<Trap> Trap { get; set; }
        public DbSet<Equip> Equip { get; set; }

        public YuGiOhDbContext(DbContextOptions<YuGiOhDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Card>(e =>
            {
                e.HasKey(c => c.Id);
            });

            builder.Entity<Card>()
                .HasDiscriminator<string>("Type")
                .HasValue<Monster>("Monster")
                .HasValue<Equip>("Equip")
                .HasValue<Trap>("Trap");

        }
    }
}
