﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using BasicService.Api.Models;

namespace BasicService.Api.Migrations
{
    [DbContext(typeof(BasicServiceDbContext))]
    [Migration("20190407173239_ActionItems_create")]
    partial class ActionItems_create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BasicService.Api.Models.ActionItemModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CompletionDate");

                    b.Property<string>("Description");

                    b.Property<DateTime>("DueDate");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("State");

                    b.Property<string>("Tags");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("ActionItems");
                });

            modelBuilder.Entity("BasicService.Api.Models.GroupEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("BasicService.Api.Models.PersonEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("BasicService.Api.Models.PersonGroupRelation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("GroupId");

                    b.Property<long>("MemberId");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("MemberId");

                    b.ToTable("PersonGroupRelation");
                });

            modelBuilder.Entity("BasicService.Api.Models.BasicServiceEntryModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Actual");

                    b.Property<int>("Elapsed");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Planned");

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("State");

                    b.Property<string>("Tags");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("BasicServiceEntries");
                });

            modelBuilder.Entity("BasicService.Api.Models.PersonGroupRelation", b =>
                {
                    b.HasOne("BasicService.Api.Models.GroupEntity", "Group")
                        .WithMany("MemberRelations")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BasicService.Api.Models.PersonEntity", "Member")
                        .WithMany("GroupRelations")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
