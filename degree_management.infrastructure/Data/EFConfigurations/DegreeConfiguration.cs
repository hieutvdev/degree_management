using degree_management.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace degree_management.infrastructure.Data.EFConfigurations;

public class DegreeConfiguration : IEntityTypeConfiguration<Degree>
{
    public void Configure(EntityTypeBuilder<Degree> builder)
    {
        builder.HasKey(c => c.Id);
      
        builder.Property(c => c.Code).HasMaxLength(50).IsRequired();
        builder.Property(c => c.CreditsRequired).IsRequired();
        builder.Property(c => c.Status).IsRequired();
        builder.Property(c=>c.Description).HasMaxLength(250);
    }
}