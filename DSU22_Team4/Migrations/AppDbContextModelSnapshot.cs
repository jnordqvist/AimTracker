// <auto-generated />
using System;
using DSU22_Team4.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DSU22_Team4.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            modelBuilder.Entity("DSU22_Team4.Models.Poco.Athlete", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("MaxHeartRate")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Athlete");
                });

            modelBuilder.Entity("DSU22_Team4.Models.Poco.Geometry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<double>("Lat")
                        .HasColumnType("double precision");

                    b.Property<double>("Lon")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Geometry");
                });

            modelBuilder.Entity("DSU22_Team4.Models.Poco.Serie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<double>("AverageXCoord")
                        .HasColumnType("double precision");

                    b.Property<double>("AverageYCoord")
                        .HasColumnType("double precision");

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
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("HeartRate")
                        .HasColumnType("integer");

                    b.Property<string>("Result")
                        .HasColumnType("text");

                    b.Property<int>("SerieId")
                        .HasColumnType("integer");

                    b.Property<int>("ShotNr")
                        .HasColumnType("integer");

                    b.Property<string>("TimeToFire")
                        .HasColumnType("text");

                    b.Property<double>("X")
                        .HasColumnType("double precision");

                    b.Property<double>("Y")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("SerieId");

                    b.ToTable("Shot");
                });

            modelBuilder.Entity("DSU22_Team4.Models.Poco.Sleep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("AthleteId")
                        .HasColumnType("text");

                    b.Property<DateTime>("AwakeTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Quality")
                        .HasColumnType("text");

                    b.Property<DateTime>("SleepTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AthleteId");

                    b.ToTable("Sleep");
                });

            modelBuilder.Entity("DSU22_Team4.Models.Poco.TrainingSession", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("GeometryId")
                        .HasColumnType("integer");

                    b.Property<string>("IbuId")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GeometryId");

                    b.ToTable("TrainingSession");
                });

            modelBuilder.Entity("DSU22_Team4.Models.Poco.Serie", b =>
                {
                    b.HasOne("DSU22_Team4.Models.Poco.TrainingSession", null)
                        .WithMany("Results")
                        .HasForeignKey("TrainingSessionId");
                });

            modelBuilder.Entity("DSU22_Team4.Models.Poco.Shot", b =>
                {
                    b.HasOne("DSU22_Team4.Models.Poco.Serie", null)
                        .WithMany("Shots")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DSU22_Team4.Models.Poco.Sleep", b =>
                {
                    b.HasOne("DSU22_Team4.Models.Poco.Athlete", null)
                        .WithMany("Sleep")
                        .HasForeignKey("AthleteId");
                });

            modelBuilder.Entity("DSU22_Team4.Models.Poco.TrainingSession", b =>
                {
                    b.HasOne("DSU22_Team4.Models.Poco.Geometry", "Geometry")
                        .WithMany()
                        .HasForeignKey("GeometryId");

                    b.Navigation("Geometry");
                });

            modelBuilder.Entity("DSU22_Team4.Models.Poco.Athlete", b =>
                {
                    b.Navigation("Sleep");
                });

            modelBuilder.Entity("DSU22_Team4.Models.Poco.Serie", b =>
                {
                    b.Navigation("Shots");
                });

            modelBuilder.Entity("DSU22_Team4.Models.Poco.TrainingSession", b =>
                {
                    b.Navigation("Results");
                });
#pragma warning restore 612, 618
        }
    }
}
