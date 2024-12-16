﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TwoOne.Persistence.Configurations.AspNet;

public class IdentityUserLoginConfiguration : IEntityTypeConfiguration<IdentityUserLogin<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder)
    {
        builder.ToTable("UserLogins", "admin");
    }
}
