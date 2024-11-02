using degree_management.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace degree_management.infrastructure.Data.EFConfigurations;

public class DegreeTypeConfiguration : IEntityTypeConfiguration<DegreeType>
{
    public void Configure(EntityTypeBuilder<DegreeType> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Code).HasMaxLength(50).IsRequired().IsUnicode();
        builder.Property(c => c.Name).HasMaxLength(50).IsRequired().IsUnicode();
        builder.Property(c => c.Active).IsRequired();
        builder.Property(c => c.Duration).IsRequired();
        builder.Property(c => c.Level).IsRequired();
        builder.Property(c => c.Description).HasMaxLength(250);
    }
}