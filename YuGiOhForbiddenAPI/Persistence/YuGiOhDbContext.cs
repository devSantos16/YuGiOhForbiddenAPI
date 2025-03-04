using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using YuGiOhForbiddenAPI.Entities;
using YuGiOhForbiddenAPI.Model;

namespace YuGiOhForbiddenAPI.Persistence
{
    public class YuGiOhDbContext : DbContext
    {
        internal readonly static string ConnectionString = "Server=NEL_289\\SQLEXPRESS; Database=YuGiOhForbiddenAPI; Integrated Security=True; trustServerCertificate=true";

        public DbSet<Card> Card { get; set; }
        public DbSet<Monster> Monster { get; set; }
        public DbSet<Trap> Trap { get; set; }
        public DbSet<Equip> Equip { get; set; }
        public DbSet<Field> Field { get; set; }
        public DbSet<Magic> Magic { get; set; }
        public DbSet<Ritual> Ritual { get; set; }

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
                .HasValue<Trap>("Trap")
                .HasValue<Field>("Field")
                .HasValue<Magic>("Magic")
                .HasValue<Ritual>("Ritual");

        }

        public static DbContextOptions<YuGiOhDbContext> GetDbContextOptions()
        {
            return new DbContextOptionsBuilder<YuGiOhDbContext>()
                .UseSqlServer(ConnectionString)
                .Options;
        }
    }
}
