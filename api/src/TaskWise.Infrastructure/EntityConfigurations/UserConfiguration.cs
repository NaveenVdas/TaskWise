using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskWise.Domain.DomainModels;

namespace TaskWise.Infrastructure.EntityConfigurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(e => e.Id)
            .HasName("PK_User_Id");

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();
        builder.Property(e => e.FirstName)
            .HasMaxLength(100);
        builder.Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(e => e.PasswordHash)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(e => e.Role)
            .IsRequired();
        builder.Property(e => e.IsActive)
            .HasDefaultValueSql("1");
        builder.Property(e => e.CreatedBy)
            .IsRequired();
        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.UpdatedBy);
        builder.Property(e => e.UpdatedAt);

        builder.HasIndex(u => u.Email)
            .IsUnique()
            .HasDatabaseName("UQ_User_Email");
    }
}
