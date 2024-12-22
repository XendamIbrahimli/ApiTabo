using Microsoft.EntityFrameworkCore;
using Tabo.Entities;

namespace Tabo.DAL
{
    public class TaboDbContext:DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<BannedWord> BannedWords { get; set; }
        public DbSet<Game> Games { get; set; }
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


                modelBuilder.Entity<Word>(w =>
                {
                    w.Property(x => x.Text)
                        .IsRequired()
                        .HasMaxLength(32);
                    w.HasOne(x => x.Language)
                        .WithMany(x => x.Words)
                        .HasForeignKey(x => x.LanguageCode)
                        .OnDelete(DeleteBehavior.Restrict);
                    w.HasMany(x => x.BannedWords)
                        .WithOne(x => x.Word)
                        .HasForeignKey(x => x.WordId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

                modelBuilder.Entity<Language>(l =>
                {
                    l.HasMany(x => x.Games)
                        .WithOne(x => x.Language)
                        .HasForeignKey(x => x.LanguageCode)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
