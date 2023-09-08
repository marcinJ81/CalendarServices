﻿// <auto-generated />
using System;
using CalendarServices.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CalendarServices.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230908054852_add status table")]
    partial class addstatustable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<TimeSpan>("Calendar_TimeService");

                    b.Property<int?>("Customer_Id");

                    b.Property<int?>("Service_Id");

                    b.Property<int>("Ss_id");

                    b.HasKey("Calendar_Id");

                    b.HasIndex("Customer_Id");

                    b.HasIndex("Service_Id");

                    b.HasIndex("Ss_id");

                    b.ToTable("Calendars");
                });

            modelBuilder.Entity("CalendarServices.Model.Customer", b =>
                {
                    b.Property<int>("Customer_Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Customer_Description");

                    b.Property<string>("Customer_Email");

                    b.Property<string>("Customer_Name");

                    b.Property<string>("Customer_Phone");

                    b.HasKey("Customer_Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CalendarServices.Model.HairDresserService", b =>
                {
                    b.Property<int>("Service_Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Service_Name");

                    b.Property<decimal>("Service_Price");

                    b.HasKey("Service_Id");

                    b.ToTable("HairDressers");
                });

            modelBuilder.Entity("CalendarServices.Model.StatusOfTheService", b =>
                {
                    b.Property<int>("Ss_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ss_Status");

                    b.HasKey("Ss_id");

                    b.ToTable("StatusOfTheServices");
                });

            modelBuilder.Entity("CalendarServices.Model.Calendar", b =>
                {
                    b.HasOne("CalendarServices.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("Customer_Id");

                    b.HasOne("CalendarServices.Model.HairDresserService", "HairDresserService")
                        .WithMany()
                        .HasForeignKey("Service_Id");

                    b.HasOne("CalendarServices.Model.StatusOfTheService", "StatusOfTheService")
                        .WithMany()
                        .HasForeignKey("Ss_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
