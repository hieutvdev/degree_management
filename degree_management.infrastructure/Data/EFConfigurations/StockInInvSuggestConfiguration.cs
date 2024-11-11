using degree_management.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace degree_management.infrastructure.Data.EFConfigurations;

public class StockInInvSuggestConfiguration : IEntityTypeConfiguration<StockInInvSuggest>
{
    public void Configure(EntityTypeBuilder<StockInInvSuggest> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Code).HasMaxLength(50).IsRequired().IsUnicode();
    }
}

