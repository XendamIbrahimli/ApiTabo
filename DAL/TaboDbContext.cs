using Microsoft.EntityFrameworkCore;
using Tabo.Entities;

namespace Tabo.DAL
{
    public class TaboDbContext:DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public TaboDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(b =>
            {
                b.HasKey(x=>x.Code);
                b.HasIndex(x => x.Name).IsUnique();
                b.Property(x => x.Code).IsFixedLength(true).HasMaxLength(3);
                b.Property(x=>x.Name).IsRequired().HasMaxLength(32);
                b.Property(x=>x.Icon).HasMaxLength(128);
                b.HasData(new Language
                {
                    Code = "az",
                    Name="Azerbaijan",
                    Icon= "https://cdn-icons-png.flaticon.com/512/330/330544.png"
                });

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
