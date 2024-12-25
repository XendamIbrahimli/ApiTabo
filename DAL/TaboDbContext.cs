using Microsoft.EntityFrameworkCore;
using Tabo.DTOs.BannedWords;
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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BannedWordCreateDto).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
