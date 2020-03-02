﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShipOps.Web.Data;

namespace ShipOps.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShipOps.Web.Data.Entities.AlertEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Alert_Date");

                    b.Property<string>("Alert_Description")
                        .IsRequired();

                    b.Property<int?>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Alerts");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.AlertImageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlertId");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AlertId");

                    b.ToTable("AlertImages");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.CompanyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<bool>("Pro");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.HoldEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Actual_Quantity");

                    b.Property<DateTime>("First_Charge");

                    b.Property<int>("Hold_Number");

                    b.Property<bool>("Is_Empty");

                    b.Property<bool>("Is_Full");

                    b.Property<DateTime>("Last_Charge");

                    b.Property<double>("Max_Quantity");

                    b.Property<int?>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Holds");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.LineUpEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Agency")
                        .IsRequired();

                    b.Property<string>("Cargo")
                        .IsRequired();

                    b.Property<string>("Cargo_Charterer")
                        .IsRequired();

                    b.Property<DateTime>("Eta");

                    b.Property<DateTime>("Etb");

                    b.Property<DateTime>("Etc");

                    b.Property<DateTime>("Etd");

                    b.Property<string>("Laycan")
                        .IsRequired();

                    b.Property<string>("Pol_Pod")
                        .IsRequired();

                    b.Property<string>("Quantity")
                        .IsRequired();

                    b.Property<string>("Shipper_Consignee")
                        .IsRequired();

                    b.Property<string>("Status")
                        .IsRequired();

                    b.Property<int?>("TerminalId");

                    b.Property<string>("Vessel")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("TerminalId");

                    b.ToTable("LineUps");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.NewEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatePublication");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.NewImageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl");

                    b.Property<int?>("NewId");

                    b.HasKey("Id");

                    b.HasIndex("NewId");

                    b.ToTable("NewImageEntity");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.OfficeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("Postal_Code")
                        .IsRequired();

                    b.Property<string>("Usa_Phone");

                    b.HasKey("Id");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.OpinionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<float>("Qualification");

                    b.Property<int?>("VoyId");

                    b.HasKey("Id");

                    b.HasIndex("VoyId");

                    b.ToTable("Opinions");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.PortEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Port_Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Ports");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.StatusEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AllFast");

                    b.Property<DateTime>("Anchored");

                    b.Property<DateTime>("Arrival");

                    b.Property<DateTime>("Commenced");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("Name_status")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("Pob");

                    b.Property<int?>("VoyId");

                    b.HasKey("Id");

                    b.HasIndex("VoyId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.TerminalEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Displacement")
                        .IsRequired();

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Max_Beam")
                        .IsRequired();

                    b.Property<string>("Max_Draft")
                        .IsRequired();

                    b.Property<string>("Max_Loa")
                        .IsRequired();

                    b.Property<int?>("PortId");

                    b.Property<string>("Terminal_Name")
                        .IsRequired();

                    b.Property<string>("Type_Cargo")
                        .IsRequired();

                    b.Property<string>("Water_Density")
                        .IsRequired();

                    b.Property<string>("Working_hours")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PortId");

                    b.ToTable("Terminals");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.TripDetailEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Altitude");

                    b.Property<DateTime>("Date");

                    b.Property<double>("Latitude");

                    b.Property<int?>("VoyId");

                    b.HasKey("Id");

                    b.HasIndex("VoyId");

                    b.ToTable("TripDetails");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.VesselEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl");

                    b.Property<int?>("VesselTypeId");

                    b.Property<string>("Vessel_Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("VesselTypeId");

                    b.ToTable("Vessels");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.VesselTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type_Vessel")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("VesselTypes");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.VoyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<double>("Altitude");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Cargo_Charterer")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Consignee")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Contract")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("Eta");

                    b.Property<DateTime>("Etb");

                    b.Property<DateTime>("Etc");

                    b.Property<DateTime>("Etd");

                    b.Property<string>("Facility")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("LastKnowPosition");

                    b.Property<double>("Latitude");

                    b.Property<string>("Laycan")
                        .IsRequired();

                    b.Property<string>("Owner_Charterer")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Pod")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Pol")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("PortId");

                    b.Property<string>("Sf")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Shipper")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("VesselId");

                    b.Property<int>("Voy_number");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PortId");

                    b.HasIndex("VesselId");

                    b.ToTable("Voys");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.VoyImageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int?>("VoyId");

                    b.HasKey("Id");

                    b.HasIndex("VoyId");

                    b.ToTable("VoysImages");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.AlertEntity", b =>
                {
                    b.HasOne("ShipOps.Web.Data.Entities.StatusEntity", "Status")
                        .WithMany("Alerts")
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.AlertImageEntity", b =>
                {
                    b.HasOne("ShipOps.Web.Data.Entities.AlertEntity", "Alert")
                        .WithMany("AlertImages")
                        .HasForeignKey("AlertId");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.HoldEntity", b =>
                {
                    b.HasOne("ShipOps.Web.Data.Entities.StatusEntity", "Status")
                        .WithMany("Holds")
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.LineUpEntity", b =>
                {
                    b.HasOne("ShipOps.Web.Data.Entities.TerminalEntity", "Terminal")
                        .WithMany("LineUps")
                        .HasForeignKey("TerminalId");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.NewImageEntity", b =>
                {
                    b.HasOne("ShipOps.Web.Data.Entities.NewEntity", "New")
                        .WithMany("NewImages")
                        .HasForeignKey("NewId");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.OpinionEntity", b =>
                {
                    b.HasOne("ShipOps.Web.Data.Entities.VoyEntity", "Voy")
                        .WithMany("Opinions")
                        .HasForeignKey("VoyId");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.StatusEntity", b =>
                {
                    b.HasOne("ShipOps.Web.Data.Entities.VoyEntity", "Voy")
                        .WithMany("Statuses")
                        .HasForeignKey("VoyId");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.TerminalEntity", b =>
                {
                    b.HasOne("ShipOps.Web.Data.Entities.PortEntity", "Port")
                        .WithMany("Terminals")
                        .HasForeignKey("PortId");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.TripDetailEntity", b =>
                {
                    b.HasOne("ShipOps.Web.Data.Entities.VoyEntity", "Voy")
                        .WithMany("TripDetails")
                        .HasForeignKey("VoyId");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.VesselEntity", b =>
                {
                    b.HasOne("ShipOps.Web.Data.Entities.VesselTypeEntity", "VesselType")
                        .WithMany("Vessels")
                        .HasForeignKey("VesselTypeId");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.VoyEntity", b =>
                {
                    b.HasOne("ShipOps.Web.Data.Entities.CompanyEntity", "Company")
                        .WithMany("Voys")
                        .HasForeignKey("CompanyId");

                    b.HasOne("ShipOps.Web.Data.Entities.PortEntity", "Port")
                        .WithMany("Voys")
                        .HasForeignKey("PortId");

                    b.HasOne("ShipOps.Web.Data.Entities.VesselEntity", "Vessel")
                        .WithMany("Voys")
                        .HasForeignKey("VesselId");
                });

            modelBuilder.Entity("ShipOps.Web.Data.Entities.VoyImageEntity", b =>
                {
                    b.HasOne("ShipOps.Web.Data.Entities.VoyEntity", "Voy")
                        .WithMany("Voyimages")
                        .HasForeignKey("VoyId");
                });
#pragma warning restore 612, 618
        }
    }
}
