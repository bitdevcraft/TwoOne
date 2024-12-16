﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TwoOne.Persistence;

#nullable disable

namespace TwoOne.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241216105132_AddAuditable")]
    partial class AddAuditable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("app")
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", "admin");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", "admin");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", "admin");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", "app");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", "admin");
                });

            modelBuilder.Entity("TwoOne.Domain.Common.Auditable.Audit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ChangeDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Operation")
                        .HasColumnType("text");

                    b.Property<string>("RecordId")
                        .HasColumnType("text");

                    b.Property<string>("TableName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Audits", "audit");
                });

            modelBuilder.Entity("TwoOne.Domain.Common.Auditable.AuditEntry", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AuditId")
                        .HasColumnType("integer");

                    b.Property<string>("FieldName")
                        .HasColumnType("text");

                    b.Property<string>("NewValue")
                        .HasColumnType("text");

                    b.Property<string>("OldValue")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuditId");

                    b.ToTable("AuditEntries", "audit");
                });

            modelBuilder.Entity("TwoOne.Domain.Entities.Authorizations.Permissions.Permission", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ActionId")
                        .HasColumnType("text");

                    b.Property<bool>("CanCreate")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanDelete")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanEdit")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanRead")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedById")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("ObjectFieldMetadataId")
                        .HasColumnType("text");

                    b.Property<string>("ObjectMetadataId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedById")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("ObjectFieldMetadataId");

                    b.HasIndex("ObjectMetadataId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UpdatedById");

                    b.ToTable("Permissions", "admin");
                });

            modelBuilder.Entity("TwoOne.Domain.Entities.Authorizations.Permissions.PermissionAction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PermissionActions", "admin");
                });

            modelBuilder.Entity("TwoOne.Domain.Entities.Authorizations.Roles.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedById")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedById")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById")
                        .IsUnique();

                    b.HasIndex("DeletedById")
                        .IsUnique();

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.HasIndex("UpdatedById")
                        .IsUnique();

                    b.ToTable("Roles", "admin");

                    b.HasData(
                        new
                        {
                            Id = "7db8bdb6-8ffe-4f73-903f-fe0424d52e10",
                            ConcurrencyStamp = "a5d00a4a-b72e-4211-8098-dcac05b0bd4c",
                            IsDeleted = false,
                            Name = "SystemAdministrator",
                            NormalizedName = "SYSTEMADMINISTRATOR"
                        },
                        new
                        {
                            Id = "530b21d4-4dd9-4749-9444-ee1384d37d38",
                            ConcurrencyStamp = "a13f3674-ced6-4170-9c50-932042c95c20",
                            IsDeleted = false,
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "c79c336b-5210-411e-b8c5-f6f210d06204",
                            ConcurrencyStamp = "ae4f6b31-2dfb-414e-921b-ba0bd7b3c0e9",
                            IsDeleted = false,
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("TwoOne.Domain.Entities.Users.RefreshTokens.RefreshToken", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsRevoked")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("RevokedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("RefreshTokens", "admin");
                });

            modelBuilder.Entity("TwoOne.Domain.Entities.Users.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedById")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("Mobile")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedById")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById")
                        .IsUnique();

                    b.HasIndex("DeletedById")
                        .IsUnique();

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("RoleId");

                    b.HasIndex("UpdatedById")
                        .IsUnique();

                    b.ToTable("Users", "admin");

                    b.HasData(
                        new
                        {
                            Id = "e63a9b1c-2f89-406e-a5dc-d6ebe5cdf05a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6cbc178c-fc8f-4bf5-804d-f53d0ecc08e8",
                            Email = "sysadmin@localhost.com",
                            EmailConfirmed = false,
                            IsDeleted = false,
                            LastName = "System Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "SYSADMIN@LOCALHOST.COM",
                            NormalizedUserName = "SYSADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEBKACsKm3AX6dpFSreTG787HyFUB7JG52sfWOk4iVqkHXs+BYXkq9xeRaRZtt1ULzw==",
                            PhoneNumberConfirmed = false,
                            RoleId = "7db8bdb6-8ffe-4f73-903f-fe0424d52e10",
                            SecurityStamp = "4597baac-a47d-49c9-a236-74aa96817989",
                            TwoFactorEnabled = false,
                            UserName = "SysAdmin"
                        },
                        new
                        {
                            Id = "52f9a82a-e4b6-4f67-ae91-2e173aa21a1a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4c03f2a5-291a-49ae-8af1-0c256374a325",
                            Email = "admin@localhost.com",
                            EmailConfirmed = false,
                            IsDeleted = false,
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@LOCALHOST.COM",
                            NormalizedUserName = "DEMOADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEKdtKuFrgIu61Jnxy2w4sZZzsxQq/p0ldbQNVvvujXGzK+Slk02ZMwv67ZdA1YiTSQ==",
                            PhoneNumberConfirmed = false,
                            RoleId = "530b21d4-4dd9-4749-9444-ee1384d37d38",
                            SecurityStamp = "7f069c5b-5de4-4167-8a0c-48c3dfaf7c63",
                            TwoFactorEnabled = false,
                            UserName = "DemoAdmin"
                        },
                        new
                        {
                            Id = "a901fdf4-edcb-4b6d-9a65-40df5b062f24",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "044ad136-1682-4a03-994e-71250a73dd30",
                            Email = "user@localhost.com",
                            EmailConfirmed = false,
                            IsDeleted = false,
                            LastName = "User",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@LOCALHOST.COM",
                            NormalizedUserName = "DEMOUSER",
                            PasswordHash = "AQAAAAIAAYagAAAAEPZ1yZkiPE2RveHNPZmDbYi32VWbFIKt9O8hoKsBMnVhjAbBmtWTYTKYWU6ec2jKcA==",
                            PhoneNumberConfirmed = false,
                            RoleId = "c79c336b-5210-411e-b8c5-f6f210d06204",
                            SecurityStamp = "3e020684-17e3-4db2-803f-234c8341537a",
                            TwoFactorEnabled = false,
                            UserName = "DemoUser"
                        });
                });

            modelBuilder.Entity("TwoOne.Domain.Metadata.ObjectFieldMetadata", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedById")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsCollection")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsLookup")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPrimaryKey")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("ObjectMetadataId")
                        .HasColumnType("text");

                    b.Property<string>("RelatedObject")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedById")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("ObjectMetadataId");

                    b.HasIndex("UpdatedById");

                    b.ToTable("ObjectFieldMetadata", "app");
                });

            modelBuilder.Entity("TwoOne.Domain.Metadata.ObjectMetadata", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedById")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedById")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("UpdatedById");

                    b.ToTable("ObjectMetadata", "app");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("TwoOne.Domain.Entities.Authorizations.Roles.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TwoOne.Domain.Entities.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TwoOne.Domain.Entities.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("TwoOne.Domain.Entities.Authorizations.Roles.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TwoOne.Domain.Entities.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TwoOne.Domain.Entities.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TwoOne.Domain.Common.Auditable.AuditEntry", b =>
                {
                    b.HasOne("TwoOne.Domain.Common.Auditable.Audit", "Audit")
                        .WithMany("Changes")
                        .HasForeignKey("AuditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Audit");
                });

            modelBuilder.Entity("TwoOne.Domain.Entities.Authorizations.Permissions.Permission", b =>
                {
                    b.HasOne("TwoOne.Domain.Entities.Authorizations.Permissions.PermissionAction", "Action")
                        .WithMany()
                        .HasForeignKey("ActionId");

                    b.HasOne("TwoOne.Domain.Entities.Users.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("TwoOne.Domain.Entities.Users.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.HasOne("TwoOne.Domain.Metadata.ObjectFieldMetadata", "ObjectFieldMetadata")
                        .WithMany()
                        .HasForeignKey("ObjectFieldMetadataId");

                    b.HasOne("TwoOne.Domain.Metadata.ObjectMetadata", "ObjectMetadata")
                        .WithMany()
                        .HasForeignKey("ObjectMetadataId");

                    b.HasOne("TwoOne.Domain.Entities.Authorizations.Roles.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("TwoOne.Domain.Entities.Users.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");

                    b.Navigation("Action");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("ObjectFieldMetadata");

                    b.Navigation("ObjectMetadata");

                    b.Navigation("Role");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("TwoOne.Domain.Entities.Authorizations.Roles.Role", b =>
                {
                    b.HasOne("TwoOne.Domain.Entities.Users.User", "CreatedBy")
                        .WithOne()
                        .HasForeignKey("TwoOne.Domain.Entities.Authorizations.Roles.Role", "CreatedById");

                    b.HasOne("TwoOne.Domain.Entities.Users.User", "DeletedBy")
                        .WithOne()
                        .HasForeignKey("TwoOne.Domain.Entities.Authorizations.Roles.Role", "DeletedById");

                    b.HasOne("TwoOne.Domain.Entities.Users.User", "UpdatedBy")
                        .WithOne()
                        .HasForeignKey("TwoOne.Domain.Entities.Authorizations.Roles.Role", "UpdatedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("TwoOne.Domain.Entities.Users.RefreshTokens.RefreshToken", b =>
                {
                    b.HasOne("TwoOne.Domain.Entities.Users.User", "User")
                        .WithOne()
                        .HasForeignKey("TwoOne.Domain.Entities.Users.RefreshTokens.RefreshToken", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TwoOne.Domain.Entities.Users.User", b =>
                {
                    b.HasOne("TwoOne.Domain.Entities.Users.User", "CreatedBy")
                        .WithOne()
                        .HasForeignKey("TwoOne.Domain.Entities.Users.User", "CreatedById");

                    b.HasOne("TwoOne.Domain.Entities.Users.User", "DeletedBy")
                        .WithOne()
                        .HasForeignKey("TwoOne.Domain.Entities.Users.User", "DeletedById");

                    b.HasOne("TwoOne.Domain.Entities.Authorizations.Roles.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.HasOne("TwoOne.Domain.Entities.Users.User", "UpdatedBy")
                        .WithOne()
                        .HasForeignKey("TwoOne.Domain.Entities.Users.User", "UpdatedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("Role");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("TwoOne.Domain.Metadata.ObjectFieldMetadata", b =>
                {
                    b.HasOne("TwoOne.Domain.Entities.Users.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("TwoOne.Domain.Entities.Users.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.HasOne("TwoOne.Domain.Metadata.ObjectMetadata", "ObjectMetadata")
                        .WithMany("Fields")
                        .HasForeignKey("ObjectMetadataId");

                    b.HasOne("TwoOne.Domain.Entities.Users.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("ObjectMetadata");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("TwoOne.Domain.Metadata.ObjectMetadata", b =>
                {
                    b.HasOne("TwoOne.Domain.Entities.Users.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("TwoOne.Domain.Entities.Users.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.HasOne("TwoOne.Domain.Entities.Users.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("TwoOne.Domain.Common.Auditable.Audit", b =>
                {
                    b.Navigation("Changes");
                });

            modelBuilder.Entity("TwoOne.Domain.Entities.Authorizations.Roles.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TwoOne.Domain.Metadata.ObjectMetadata", b =>
                {
                    b.Navigation("Fields");
                });
#pragma warning restore 612, 618
        }
    }
}
