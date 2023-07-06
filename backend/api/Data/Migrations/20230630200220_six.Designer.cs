﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(apiContext))]
    [Migration("20230630200220_six")]
    partial class six
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("api.Data.Models.PermissionType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("active")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("permissionTypes");
                });

            modelBuilder.Entity("api.Data.Models.RolePermission", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("active")
                        .HasColumnType("int");

                    b.Property<int>("permissionTypeId")
                        .HasColumnType("int");

                    b.Property<int>("roleTypeId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("permissionTypeId");

                    b.HasIndex("roleTypeId");

                    b.ToTable("rolePermissions");
                });

            modelBuilder.Entity("api.Data.Models.RoleType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("active")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("roleTypes");
                });

            modelBuilder.Entity("api.Data.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("active")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passwordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("regDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("api.Data.Models.UserPermission", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("active")
                        .HasColumnType("int");

                    b.Property<int>("permissionTypeId")
                        .HasColumnType("int");

                    b.Property<int>("roleTypeId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("permissionTypeId");

                    b.HasIndex("roleTypeId");

                    b.HasIndex("userId");

                    b.ToTable("userPermissions");
                });

            modelBuilder.Entity("api.Data.Models.UserRole", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("roleTypeId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("roleTypeId");

                    b.HasIndex("userId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("api.Data.Models.RolePermission", b =>
                {
                    b.HasOne("api.Data.Models.PermissionType", "PermissionType")
                        .WithMany("RolePermissions")
                        .HasForeignKey("permissionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Data.Models.RoleType", "RoleType")
                        .WithMany("RolePermissions")
                        .HasForeignKey("roleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PermissionType");

                    b.Navigation("RoleType");
                });

            modelBuilder.Entity("api.Data.Models.UserPermission", b =>
                {
                    b.HasOne("api.Data.Models.PermissionType", "PermissionType")
                        .WithMany("userPermissions")
                        .HasForeignKey("permissionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Data.Models.RoleType", "RoleType")
                        .WithMany()
                        .HasForeignKey("roleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Data.Models.User", "User")
                        .WithMany("userPermissions")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PermissionType");

                    b.Navigation("RoleType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Data.Models.UserRole", b =>
                {
                    b.HasOne("api.Data.Models.RoleType", "RoleType")
                        .WithMany("UserRoles")
                        .HasForeignKey("roleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Data.Models.User", "User")
                        .WithMany("userRoles")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoleType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Data.Models.PermissionType", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("userPermissions");
                });

            modelBuilder.Entity("api.Data.Models.RoleType", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("api.Data.Models.User", b =>
                {
                    b.Navigation("userPermissions");

                    b.Navigation("userRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
