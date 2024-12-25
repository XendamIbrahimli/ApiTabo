using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabo.Entities;

namespace Tabo.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasOne(x => x.Language)
                        .WithMany(x => x.Games)
                        .HasForeignKey(x => x.LanguageCode)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
