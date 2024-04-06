﻿// <auto-generated />
using System;
using GoalsetterChallenge.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoalsetterChallenge.Infrastructure.Migrations
{
    [DbContext(typeof(RentalDbContext))]
    [Migration("20240406184613_AddRemovedFieldToClient")]
    partial class AddRemovedFieldToClient
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GoalsetterChallenge.Domain.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmailAddress = "JohnDoe@gmail.com",
                            FirstName = "John",
                            IsRemoved = false,
                            LastName = "Doe",
                            PhoneNumber = "+54 9 11 3232 1212"
                        },
                        new
                        {
                            Id = 2,
                            EmailAddress = "JuanDoe@gmail.com",
                            FirstName = "Juan",
                            IsRemoved = false,
                            LastName = "Doe",
                            PhoneNumber = "+54 9 11 3232 1213"
                        },
                        new
                        {
                            Id = 3,
                            EmailAddress = "PeterEod@gmail.com",
                            FirstName = "Peter",
                            IsRemoved = false,
                            LastName = "Eod",
                            PhoneNumber = "+54 9 11 3232 1214"
                        });
                });

            modelBuilder.Entity("GoalsetterChallenge.Domain.Entities.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Rentals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = 1,
                            EndDate = new DateTime(2024, 4, 13, 15, 46, 13, 550, DateTimeKind.Local).AddTicks(9754),
                            IsRemoved = false,
                            StartDate = new DateTime(2024, 4, 6, 15, 46, 13, 550, DateTimeKind.Local).AddTicks(9749),
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 2,
                            ClientId = 2,
                            EndDate = new DateTime(2024, 4, 13, 15, 46, 13, 550, DateTimeKind.Local).AddTicks(9758),
                            IsRemoved = false,
                            StartDate = new DateTime(2024, 4, 6, 15, 46, 13, 550, DateTimeKind.Local).AddTicks(9757),
                            VehicleId = 6
                        },
                        new
                        {
                            Id = 3,
                            ClientId = 3,
                            EndDate = new DateTime(2024, 4, 13, 15, 46, 13, 550, DateTimeKind.Local).AddTicks(9759),
                            IsRemoved = false,
                            StartDate = new DateTime(2024, 4, 6, 15, 46, 13, 550, DateTimeKind.Local).AddTicks(9759),
                            VehicleId = 3
                        });
                });

            modelBuilder.Entity("GoalsetterChallenge.Domain.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("DailyPrice")
                        .HasColumnType("float");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Volkswagen",
                            DailyPrice = 10.01,
                            IsRemoved = false,
                            Model = "Golf",
                            Type = "Car",
                            Year = 2023
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Volkswagen",
                            DailyPrice = 9.0,
                            IsRemoved = true,
                            Model = "Up",
                            Type = "Small Car",
                            Year = 2023
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Volkswagen",
                            DailyPrice = 15.0,
                            IsRemoved = false,
                            Model = "Nivus",
                            Type = "Small SUV",
                            Year = 2023
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Volkswagen",
                            DailyPrice = 11.0,
                            IsRemoved = false,
                            Model = "Virtus",
                            Type = "Car",
                            Year = 2023
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Volkswagen",
                            DailyPrice = 11.0,
                            IsRemoved = false,
                            Model = "Polo",
                            Type = "Car",
                            Year = 2023
                        },
                        new
                        {
                            Id = 6,
                            Brand = "Volkswagen",
                            DailyPrice = 22.0,
                            IsRemoved = false,
                            Model = "Tiguan",
                            Type = "SUV",
                            Year = 2023
                        });
                });

            modelBuilder.Entity("GoalsetterChallenge.Domain.Entities.Rental", b =>
                {
                    b.HasOne("GoalsetterChallenge.Domain.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoalsetterChallenge.Domain.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Vehicle");
                });
#pragma warning restore 612, 618
        }
    }
}
