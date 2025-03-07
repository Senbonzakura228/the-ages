﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(TheAgesDBContext))]
    [Migration("20250221102626_building-placement")]
    partial class buildingplacement
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Data.Entities.Building.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("height")
                        .HasColumnType("integer");

                    b.Property<int>("width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("buildings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "StoneAgeHouse",
                            height = 2,
                            width = 2
                        });
                });

            modelBuilder.Entity("Data.Entities.City.CityBuilding", b =>
                {
                    b.Property<int>("UserCityMapId")
                        .HasColumnType("integer");

                    b.Property<int>("BuildingId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("XCoordinate")
                        .HasColumnType("integer");

                    b.Property<int>("YCoordinate")
                        .HasColumnType("integer");

                    b.HasKey("UserCityMapId", "BuildingId", "Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("CityBuilding");
                });

            modelBuilder.Entity("Data.Entities.City.CityExtension", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("XCoordinate")
                        .HasColumnType("integer");

                    b.Property<int>("YCoordinate")
                        .HasColumnType("integer");

                    b.Property<int>("height")
                        .HasColumnType("integer");

                    b.Property<int>("width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("CityExtension");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            XCoordinate = -15,
                            YCoordinate = 0,
                            height = 15,
                            width = 15
                        });
                });

            modelBuilder.Entity("Data.Entities.City.UserCityExtension", b =>
                {
                    b.Property<int>("CityMapId")
                        .HasColumnType("integer");

                    b.Property<int>("CityExtensionId")
                        .HasColumnType("integer");

                    b.HasKey("CityMapId", "CityExtensionId");

                    b.HasIndex("CityExtensionId");

                    b.ToTable("UserCityExtension");
                });

            modelBuilder.Entity("Data.Entities.City.UserCityMap", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("userCityMaps");
                });

            modelBuilder.Entity("Data.Entities.User.UserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("userAccounts");
                });

            modelBuilder.Entity("Data.Entities.User.UserGameData", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("userGameData");
                });

            modelBuilder.Entity("Data.Entities.City.CityBuilding", b =>
                {
                    b.HasOne("Data.Entities.Building.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.City.UserCityMap", "UserCityMap")
                        .WithMany("Buildings")
                        .HasForeignKey("UserCityMapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("UserCityMap");
                });

            modelBuilder.Entity("Data.Entities.City.UserCityExtension", b =>
                {
                    b.HasOne("Data.Entities.City.CityExtension", "CityExtension")
                        .WithMany()
                        .HasForeignKey("CityExtensionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.City.UserCityMap", "UserCityMap")
                        .WithMany("Extensions")
                        .HasForeignKey("CityMapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CityExtension");

                    b.Navigation("UserCityMap");
                });

            modelBuilder.Entity("Data.Entities.City.UserCityMap", b =>
                {
                    b.HasOne("Data.Entities.User.UserGameData", "UserGameData")
                        .WithOne("UserCityMap")
                        .HasForeignKey("Data.Entities.City.UserCityMap", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserGameData");
                });

            modelBuilder.Entity("Data.Entities.User.UserGameData", b =>
                {
                    b.HasOne("Data.Entities.User.UserAccount", "UserAccount")
                        .WithOne("GameData")
                        .HasForeignKey("Data.Entities.User.UserGameData", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("Data.Entities.City.UserCityMap", b =>
                {
                    b.Navigation("Buildings");

                    b.Navigation("Extensions");
                });

            modelBuilder.Entity("Data.Entities.User.UserAccount", b =>
                {
                    b.Navigation("GameData")
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.User.UserGameData", b =>
                {
                    b.Navigation("UserCityMap")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
