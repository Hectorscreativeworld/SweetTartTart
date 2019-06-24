﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using sweettarttart;

namespace sweettarttart.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SweetTartTartApi.Model.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("ManagerName");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("SweetTartTartApi.Model.SweetTartTart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOrdered");

                    b.Property<int?>("LocationId");

                    b.Property<string>("Name");

                    b.Property<int>("NumberInStock");

                    b.Property<int>("Price");

                    b.Property<int>("SKU");

                    b.Property<string>("ShortDescription");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("TartItems");
                });

            modelBuilder.Entity("SweetTartTartApi.Model.SweetTartTart", b =>
                {
                    b.HasOne("SweetTartTartApi.Model.Location", "Location")
                        .WithMany("Items")
                        .HasForeignKey("LocationId");
                });
#pragma warning restore 612, 618
        }
    }
}
