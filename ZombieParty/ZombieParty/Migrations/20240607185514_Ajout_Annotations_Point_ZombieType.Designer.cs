﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZombieParty.Models.Data;

#nullable disable

namespace ZombieParty.Migrations
{
    [DbContext(typeof(ZombiePartyDbContext))]
    [Migration("20240607185514_Ajout_Annotations_Point_ZombieType")]
    partial class Ajout_Annotations_Point_ZombieType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ZombieParty.Models.Zombie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<string>("ShortDEsc")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ZombieTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ZombieTypeId");

                    b.ToTable("Zombie");
                });

            modelBuilder.Entity("ZombieParty.Models.ZombieType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("ZombieType");
                });

            modelBuilder.Entity("ZombieParty.Models.Zombie", b =>
                {
                    b.HasOne("ZombieParty.Models.ZombieType", "ZombieType")
                        .WithMany()
                        .HasForeignKey("ZombieTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ZombieType");
                });
#pragma warning restore 612, 618
        }
    }
}
