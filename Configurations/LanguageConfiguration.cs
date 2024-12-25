using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabo.Entities;

namespace Tabo.Configurations
{
    public class LanguageConfiguration:IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder) 
        {
            builder.HasKey(x => x.Code);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Code).IsFixedLength(true).HasMaxLength(3);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(32);
            builder.Property(x => x.Icon).HasMaxLength(128);
        }
    }
}
