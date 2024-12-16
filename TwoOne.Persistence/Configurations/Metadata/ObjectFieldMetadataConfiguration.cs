// Copyright (c) Ryan Capio.
// All Rights Reserved.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwoOne.Domain.Metadata;

namespace TwoOne.Persistence.Configurations.Metadata;

public class ObjectFieldMetadataConfiguration : IEntityTypeConfiguration<ObjectFieldMetadata>
{
    public void Configure(EntityTypeBuilder<ObjectFieldMetadata> builder)
    {
        builder.ToTable("ObjectFieldMetadata", "metadata");
    }
}
