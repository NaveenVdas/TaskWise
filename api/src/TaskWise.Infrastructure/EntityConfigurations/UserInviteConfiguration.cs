using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskWise.Domain.DomainModels;

namespace TaskWise.Infrastructure.EntityConfigurations;

public sealed class UserInviteConfiguration : IEntityTypeConfiguration<UserInvite>
{
    public void Configure(EntityTypeBuilder<UserInvite> builder)
    {
        builder.ToTable("UserInvite");
        builder.HasKey(e => e.Id)
            .HasName("PK_UserInvite_Id");

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
        builder.Property(e => e.Role)
            .IsRequired();
        builder.Property(e => e.Token)
            .IsRequired();
        builder.Property(e => e.InvitedBy)
            .IsRequired();
        builder.Property(e => e.InvitedAt)
            .HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.ExpiresAt)
            .IsRequired();
        builder.Property(e => e.IsValid);
        builder.Property(e => e.IsAccepted);
    }
}
