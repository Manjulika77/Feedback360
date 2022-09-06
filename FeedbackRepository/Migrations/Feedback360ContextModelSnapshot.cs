﻿// <auto-generated />
using System;
using FeedbackRepository.RepoModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FeedbackRepository.Migrations
{
    [DbContext(typeof(Feedback360Context))]
    partial class Feedback360ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FeedbackRepository.RepoModel.RoleDetail", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("RoleID");

                    b.ToTable("RoleDetails");
                });

            modelBuilder.Entity("FeedbackRepository.RepoModel.UserDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("PasswordChangeDate")
                        .HasColumnType("datetime");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("ID");

                    b.ToTable("UserDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
