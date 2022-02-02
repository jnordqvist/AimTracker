﻿// <auto-generated />
using System;
using DSU22_Team4.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DSU22_Team4.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220201093819_new Athlete")]
    partial class newAthlete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DSU22_Team4.Models.Poco.Athlete", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Athlete");
                });

            modelBuilder.Entity("DSU22_Team4.Models.Poco.Serie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Stance")
                        .HasColumnType("text");

                    b.Property<string>("TrainingSessionId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TrainingSessionId");

                    b.ToTable("Serie");
                });

            modelBuilder.Entity("DSU22_Team4.Models.Poco.Shot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Result")
                        .HasColumnType("text");

                    b.Property<int?>("SerieId")
                        .HasColumnType("integer");

                    b.Property<int>("ShotNr")
                        .HasColumnType("integer");

                    b.Property<string>("TimeToFire")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SerieId");

                    b.ToTable("Shot");
                });

            modelBuilder.Entity("DSU22_Team4.Models.Poco.TrainingSession", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AthleteId")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("IbuId")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AthleteId");

                    b.ToTable("TrainingSession");
                });

            modelBuilder.Entity("DSU22_Team4.Models.Poco.Serie", b =>
                {
                    b.HasOne("DSU22_Team4.Models.Poco.TrainingSession", null)
                        .WithMany("Series")
                        .HasForeignKey("TrainingSessionId");
                });

            modelBuilder.Entity("DSU22_Team4.Models.Poco.Shot", b =>
                {
                    b.HasOne("DSU22_Team4.Models.Poco.Serie", null)
                        .WithMany("Shots")
                        .HasForeignKey("SerieId");
                });

            modelBuilder.Entity("DSU22_Team4.Models.Poco.TrainingSession", b =>
                {
                    b.HasOne("DSU22_Team4.Models.Poco.Athlete", null)
                        .WithMany("TrainingSession")
                        .HasForeignKey("AthleteId");
                });

            modelBuilder.Entity("DSU22_Team4.Models.Poco.Athlete", b =>
                {
                    b.Navigation("TrainingSession");
                });

            modelBuilder.Entity("DSU22_Team4.Models.Poco.Serie", b =>
                {
                    b.Navigation("Shots");
                });

            modelBuilder.Entity("DSU22_Team4.Models.Poco.TrainingSession", b =>
                {
                    b.Navigation("Series");
                });
#pragma warning restore 612, 618
        }
    }
}
