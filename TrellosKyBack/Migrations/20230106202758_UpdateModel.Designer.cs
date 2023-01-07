﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrellosKyBackAPI.Infrastructure;

namespace TrellosKyBackAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230106202758_UpdateModel")]
    partial class UpdateModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrelloskyBack.Domain.Models.TaskT", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeTaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeTaskId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TrelloskyBack.Domain.Models.TypeTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeTasks");
                });

            modelBuilder.Entity("TrelloskyBack.Domain.Models.TaskT", b =>
                {
                    b.HasOne("TrelloskyBack.Domain.Models.TypeTask", "TypeTask")
                        .WithMany("Tasks")
                        .HasForeignKey("TypeTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeTask");
                });

            modelBuilder.Entity("TrelloskyBack.Domain.Models.TypeTask", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
