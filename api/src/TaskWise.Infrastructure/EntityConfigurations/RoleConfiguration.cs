using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskWise.Domain.DomainModels;

namespace TaskWise.Infrastructure.EntityConfigurations;

public sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");
        builder.HasKey(e => e.Id)
            .HasName("PK_Role_Id");

        builder.Property(e => e.Id);
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(e => e.Deleted)
            .HasDefaultValueSql("0");
        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.CreatedBy)
            .IsRequired();
        builder.Property(e => e.UpdatedBy);
        builder.Property(e => e.UpdatedAt);

        builder.HasIndex(e => e.Name)
            .IsUnique()
            .HasDatabaseName("UQ_Role_Name");
    }
}
