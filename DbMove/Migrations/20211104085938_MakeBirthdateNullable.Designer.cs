﻿// <auto-generated />
using System;
using DbMove.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DbMove.Migrations
{
    [DbContext(typeof(MoveContext))]
    [Migration("20211104085938_MakeBirthdateNullable")]
    partial class MakeBirthdateNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DbMove.Models.Media", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("File")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("MediaUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("DbMove.Models.Move", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Latitude")
                        .HasPrecision(12, 9)
                        .HasColumnType("decimal(12,9)");

                    b.Property<decimal>("Longitude")
                        .HasPrecision(12, 9)
                        .HasColumnType("decimal(12,9)");

                    b.Property<long>("MediaId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("MoveDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SportId")
                        .HasColumnType("int");

                    b.Property<long?>("SportId1")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MediaId");

                    b.HasIndex("SportId1");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("DbMove.Models.MoveMover", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("MoveId")
                        .HasColumnType("bigint");

                    b.Property<long>("MoverId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MoveId");

                    b.HasIndex("MoverId");

                    b.ToTable("MoveMovers");
                });

            modelBuilder.Entity("DbMove.Models.Mover", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movers");
                });

            modelBuilder.Entity("DbMove.Models.Sport", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("DbMove.Models.Move", b =>
                {
                    b.HasOne("DbMove.Models.Media", "Media")
                        .WithMany("Moves")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbMove.Models.Sport", "Sport")
                        .WithMany("Moves")
                        .HasForeignKey("SportId1");

                    b.Navigation("Media");

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("DbMove.Models.MoveMover", b =>
                {
                    b.HasOne("DbMove.Models.Move", "Move")
                        .WithMany("MoveMovers")
                        .HasForeignKey("MoveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbMove.Models.Mover", "Mover")
                        .WithMany("MoveMovers")
                        .HasForeignKey("MoverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Move");

                    b.Navigation("Mover");
                });

            modelBuilder.Entity("DbMove.Models.Media", b =>
                {
                    b.Navigation("Moves");
                });

            modelBuilder.Entity("DbMove.Models.Move", b =>
                {
                    b.Navigation("MoveMovers");
                });

            modelBuilder.Entity("DbMove.Models.Mover", b =>
                {
                    b.Navigation("MoveMovers");
                });

            modelBuilder.Entity("DbMove.Models.Sport", b =>
                {
                    b.Navigation("Moves");
                });
#pragma warning restore 612, 618
        }
    }
}
