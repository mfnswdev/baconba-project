﻿// <auto-generated />
using System;
using BaconBA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BaconBA.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240602234258_initialMigration")]
    partial class initialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("BaconBA.Domain.AnimalEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CheckoutDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Eartag")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GenitorEartag")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<string>("MatriarchEartag")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Eartag")
                        .IsUnique();

                    b.ToTable("Animals", (string)null);
                });

            modelBuilder.Entity("BaconBA.Domain.WeightEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AnimalEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnimalId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("WeightDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("WeightValue")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("AnimalEntityId");

                    b.ToTable("WeightEntity");
                });

            modelBuilder.Entity("BaconBA.Domain.WeightEntity", b =>
                {
                    b.HasOne("BaconBA.Domain.AnimalEntity", null)
                        .WithMany("Weights")
                        .HasForeignKey("AnimalEntityId");
                });

            modelBuilder.Entity("BaconBA.Domain.AnimalEntity", b =>
                {
                    b.Navigation("Weights");
                });
#pragma warning restore 612, 618
        }
    }
}
