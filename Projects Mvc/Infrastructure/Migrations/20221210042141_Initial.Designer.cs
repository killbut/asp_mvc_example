﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20221210042141_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PerformerId")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PerformerId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Job", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyCustomer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyExecutor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ManagerForeignKey")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ManagerForeignKey");

                    b.ToTable("Project", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Worker", (string)null);
                });

            modelBuilder.Entity("ProjectWorker", b =>
                {
                    b.Property<int>("ProjectsId")
                        .HasColumnType("int");

                    b.Property<int>("WorkersId")
                        .HasColumnType("int");

                    b.HasKey("ProjectsId", "WorkersId");

                    b.HasIndex("WorkersId");

                    b.ToTable("ProjectWorker", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Job", b =>
                {
                    b.HasOne("Core.Entities.Worker", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Core.Entities.Worker", "Performer")
                        .WithMany("Jobs")
                        .HasForeignKey("PerformerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Core.Entities.Project", null)
                        .WithMany("Jobs")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Author");

                    b.Navigation("Performer");
                });

            modelBuilder.Entity("Core.Entities.Project", b =>
                {
                    b.HasOne("Core.Entities.Worker", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerForeignKey")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("ProjectWorker", b =>
                {
                    b.HasOne("Core.Entities.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Worker", null)
                        .WithMany()
                        .HasForeignKey("WorkersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Project", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("Core.Entities.Worker", b =>
                {
                    b.Navigation("Jobs");
                });
#pragma warning restore 612, 618
        }
    }
}
