using degree_management.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace degree_management.infrastructure.Data.EFConfigurations;

public class InvetoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Quantity)
            .IsRequired();

        builder.Property(i => i.IssueDate)
            .IsRequired();

        builder.Property(i => i.Status)
            .IsRequired();

        builder.Property(i => i.Description)
            .HasMaxLength(255);
    }
}