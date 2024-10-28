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
            .HasMaxLength(155);
        
        builder.HasOne(i => i.Degree)
            .WithMany()
            .HasForeignKey(i => i.DegreeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(i => i.Warehouse)
            .WithMany()
            .HasForeignKey(i => i.WarehouseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}