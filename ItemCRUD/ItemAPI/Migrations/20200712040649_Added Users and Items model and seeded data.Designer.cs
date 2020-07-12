﻿// <auto-generated />
using ItemAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ItemAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200712040649_Added Users and Items model and seeded data")]
    partial class AddedUsersandItemsmodelandseededdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ItemAPI.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            Description = "IIS 7.0",
                            Rate = "20",
                            Title = "Web Server",
                            UnitType = "Hours"
                        },
                        new
                        {
                            ItemId = 2,
                            Description = "Designed a logo for app",
                            Rate = "100",
                            Title = "Logo Design",
                            UnitType = "PC"
                        },
                        new
                        {
                            ItemId = 3,
                            Description = "Php application for project management",
                            Rate = "20",
                            Title = "Application Development",
                            UnitType = "Hours"
                        });
                });

            modelBuilder.Entity("ItemAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Password = "test",
                            Role = "test",
                            Username = "test"
                        },
                        new
                        {
                            UserId = 2,
                            Password = "Admin",
                            Role = "Admin",
                            Username = "Admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
