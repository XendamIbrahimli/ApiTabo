using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabo.Entities;

namespace Tabo.Configurations
{
    public class WordConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.Property(x => x.Text)
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsRequired();
            builder.HasOne(x => x.Language)
                .WithMany(x => x.Words)
                .HasForeignKey(x => x.LanguageCode)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.BannedWords)
                .WithOne(x => x.Word)
                .HasForeignKey(x => x.WordId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
