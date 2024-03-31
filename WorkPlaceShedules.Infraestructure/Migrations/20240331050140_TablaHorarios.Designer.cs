﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkPlaceShedules.Infraestructure.Data;

#nullable disable

namespace WorkPlaceShedules.Infraestructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240331050140_TablaHorarios")]
    partial class TablaHorarios
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WorkPlaceShedules.Domain.Entities.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WorkPlaceShedules.Domain.Entities.UserWorkPlaceShedulesEntity", b =>
                {
                    b.Property<int>("UserWorkPlaceScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserWorkPlaceScheduleId"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("DateTime");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdminRequest")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Modifier")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("Schedule")
                        .HasColumnType("DateTime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WorkPlaceId")
                        .HasColumnType("int");

                    b.HasKey("UserWorkPlaceScheduleId");

                    b.ToTable("WorkPlaceShedules");
                });

            modelBuilder.Entity("WorkPlaceShedules.Domain.Entities.UsersEntity", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("DateTime");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Modifier")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WorkPlaceShedules.Domain.Entities.WorkGroupsEntity", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("DateTime");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("GroupDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Modifier")
                        .HasColumnType("varchar(50)");

                    b.HasKey("GroupId");

                    b.ToTable("WorkGroups");
                });

            modelBuilder.Entity("WorkPlaceShedules.Domain.Entities.WorkPlacesEntity", b =>
                {
                    b.Property<int>("WorkPlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkPlaceId"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("DateTime");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Modifier")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("WorkPlaceCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("WorkPlaceName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("WorkPlaceNumber")
                        .HasColumnType("int");

                    b.HasKey("WorkPlaceId");

                    b.ToTable("WorkPlaces");
                });

            modelBuilder.Entity("WorkPlaceShedules.Domain.Entities.UsersEntity", b =>
                {
                    b.HasOne("WorkPlaceShedules.Domain.Entities.RoleEntity", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WorkPlaceShedules.Domain.Entities.RoleEntity", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
