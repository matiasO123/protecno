﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Protecno.Models;

#nullable disable

namespace Protecno.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250509041756_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.4");

            modelBuilder.Entity("Protecno.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("Protecno.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("rolID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("user")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("rolID");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Protecno.Models.Usuario", b =>
                {
                    b.HasOne("Protecno.Models.Rol", "rol")
                        .WithMany()
                        .HasForeignKey("rolID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("rol");
                });
#pragma warning restore 612, 618
        }
    }
}
