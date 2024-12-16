using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwoOne.Domain.Entities.Users.RefreshTokens;

namespace TwoOne.Persistence.Configurations.Authorizations.RefreshTokens;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens", "admin");
        builder.HasKey(rt => rt.Id);

        builder.HasOne(rt => rt.User)
            .WithOne()
            .HasForeignKey<RefreshToken>(rt => rt.UserId)
            .IsRequired(false);
    }
}
