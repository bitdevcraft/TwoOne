// Copyright (c) Ryan Capio.
// All Rights Reserved.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwoOne.Domain.Metadata;

namespace TwoOne.Persistence.Configurations.Metadata;

public class ObjectMetadataConfiguration : IEntityTypeConfiguration<ObjectMetadata>
{
    public void Configure(EntityTypeBuilder<ObjectMetadata> builder)
    {
        builder.ToTable("ObjectMetadata", "metadata");
    }
}
