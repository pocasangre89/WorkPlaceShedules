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
    [Migration("20240328042125_AddUserAndRole")]
    partial class AddUserAndRole
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

                    b.Property<int>("UsersEntityPUserId")
                        .HasColumnType("int");

                    b.Property<int>("WorkGroupPGroupId")
                        .HasColumnType("int");

                    b.Property<int>("WorkPlaceId")
                        .HasColumnType("int");

                    b.Property<int>("WorkPlacesPWorkPlaceId")
                        .HasColumnType("int");

                    b.HasKey("UserWorkPlaceScheduleId");

                    b.HasIndex("UsersEntityPUserId");

                    b.HasIndex("WorkGroupPGroupId");

                    b.HasIndex("WorkPlacesPWorkPlaceId");

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
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Modifier")
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserCode")
                        .IsRequired()
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
                        .HasColumnType("varchar(500)");

                    b.Property<string>("GroupName")
                        .IsRequired()
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
                        .HasColumnType("varchar(50)");

                    b.Property<string>("WorkPlaceName")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<int>("WorkPlaceNumber")
                        .HasColumnType("int");

                    b.HasKey("WorkPlaceId");

                    b.ToTable("WorkPlaces");
                });

            modelBuilder.Entity("WorkPlaceShedules.Domain.Entities.UserWorkPlaceShedulesEntity", b =>
                {
                    b.HasOne("WorkPlaceShedules.Domain.Entities.UsersEntity", "UsersEntityP")
                        .WithMany()
                        .HasForeignKey("UsersEntityPUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkPlaceShedules.Domain.Entities.WorkGroupsEntity", "WorkGroupP")
                        .WithMany()
                        .HasForeignKey("WorkGroupPGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkPlaceShedules.Domain.Entities.WorkPlacesEntity", "WorkPlacesP")
                        .WithMany()
                        .HasForeignKey("WorkPlacesPWorkPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsersEntityP");

                    b.Navigation("WorkGroupP");

                    b.Navigation("WorkPlacesP");
                });

            modelBuilder.Entity("WorkPlaceShedules.Domain.Entities.UsersEntity", b =>
                {
                    b.HasOne("WorkPlaceShedules.Domain.Entities.RoleEntity", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

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
