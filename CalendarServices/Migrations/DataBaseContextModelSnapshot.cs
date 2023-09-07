﻿// <auto-generated />
using System;
using CalendarServices.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CalendarServices.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CalendarServices.Model.Calendar", b =>
                {
                    b.Property<int>("Calendar_Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Calendar_Deleted");

                    b.Property<DateTime>("Calendar_ReservationDate");

                    b.Property<int?>("Customer_Id");

                    b.Property<int?>("Service_Id");

                    b.HasKey("Calendar_Id");

                    b.ToTable("Calendars");
                });

            modelBuilder.Entity("CalendarServices.Model.Customer", b =>
                {
                    b.Property<int>("Customer_Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Calendar_Id");

                    b.Property<string>("Customer_Description");

                    b.Property<string>("Customer_Email");

                    b.Property<string>("Customer_Name");

                    b.Property<string>("Customer_Phone");

                    b.HasKey("Customer_Id");

                    b.HasIndex("Calendar_Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CalendarServices.Model.HairDresserService", b =>
                {
                    b.Property<int>("Service_Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Calendar_Id");

                    b.Property<string>("Service_Name");

                    b.Property<decimal>("Service_Price");

                    b.HasKey("Service_Id");

                    b.HasIndex("Calendar_Id");

                    b.ToTable("HairDressers");
                });

            modelBuilder.Entity("CalendarServices.Model.Customer", b =>
                {
                    b.HasOne("CalendarServices.Model.Calendar", "Calendar")
                        .WithMany("Customer")
                        .HasForeignKey("Calendar_Id");
                });

            modelBuilder.Entity("CalendarServices.Model.HairDresserService", b =>
                {
                    b.HasOne("CalendarServices.Model.Calendar", "Calendar")
                        .WithMany("HairDresserService")
                        .HasForeignKey("Calendar_Id");
                });
#pragma warning restore 612, 618
        }
    }
}
