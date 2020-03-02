using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShipOps.Web.Migrations
{
    public partial class FirstDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    Pro = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    DatePublication = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Adress = table.Column<string>(nullable: false),
                    Postal_Code = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Usa_Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Port_Name = table.Column<string>(maxLength: 20, nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VesselTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type_Vessel = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VesselTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewImageEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageUrl = table.Column<string>(nullable: true),
                    NewId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewImageEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewImageEntity_News_NewId",
                        column: x => x.NewId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Terminals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Terminal_Name = table.Column<string>(nullable: false),
                    Max_Loa = table.Column<string>(nullable: false),
                    Max_Beam = table.Column<string>(nullable: false),
                    Max_Draft = table.Column<string>(nullable: false),
                    Displacement = table.Column<string>(nullable: false),
                    Water_Density = table.Column<string>(nullable: false),
                    Working_hours = table.Column<string>(nullable: false),
                    Type_Cargo = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    PortId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Terminals_Ports_PortId",
                        column: x => x.PortId,
                        principalTable: "Ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vessels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Vessel_Name = table.Column<string>(maxLength: 30, nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    VesselTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vessels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vessels_VesselTypes_VesselTypeId",
                        column: x => x.VesselTypeId,
                        principalTable: "VesselTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineUps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Vessel = table.Column<string>(maxLength: 20, nullable: false),
                    Eta = table.Column<DateTime>(nullable: false),
                    Etb = table.Column<DateTime>(nullable: false),
                    Etc = table.Column<DateTime>(nullable: false),
                    Etd = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Cargo = table.Column<string>(nullable: false),
                    Quantity = table.Column<string>(nullable: false),
                    Laycan = table.Column<string>(nullable: false),
                    Pol_Pod = table.Column<string>(nullable: false),
                    Shipper_Consignee = table.Column<string>(nullable: false),
                    Cargo_Charterer = table.Column<string>(nullable: false),
                    Agency = table.Column<string>(nullable: false),
                    TerminalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineUps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineUps_Terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Voys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Voy_number = table.Column<int>(nullable: false),
                    Account = table.Column<string>(maxLength: 50, nullable: false),
                    Laycan = table.Column<string>(nullable: false),
                    Contract = table.Column<string>(maxLength: 50, nullable: false),
                    Cargo = table.Column<string>(maxLength: 50, nullable: false),
                    Sf = table.Column<string>(maxLength: 50, nullable: false),
                    Pol = table.Column<string>(maxLength: 50, nullable: false),
                    Facility = table.Column<string>(maxLength: 50, nullable: false),
                    Pod = table.Column<string>(maxLength: 50, nullable: false),
                    Cargo_Charterer = table.Column<string>(maxLength: 50, nullable: false),
                    Owner_Charterer = table.Column<string>(maxLength: 50, nullable: false),
                    Shipper = table.Column<string>(maxLength: 50, nullable: false),
                    Consignee = table.Column<string>(maxLength: 50, nullable: false),
                    Latitude = table.Column<string>(nullable: false),
                    Altitude = table.Column<string>(nullable: false),
                    LastKnowPosition = table.Column<DateTime>(nullable: false),
                    Eta = table.Column<DateTime>(nullable: false),
                    Etb = table.Column<DateTime>(nullable: false),
                    Etc = table.Column<DateTime>(nullable: false),
                    Etd = table.Column<DateTime>(nullable: false),
                    CompanyId = table.Column<int>(nullable: true),
                    PortId = table.Column<int>(nullable: true),
                    VesselId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voys_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voys_Ports_PortId",
                        column: x => x.PortId,
                        principalTable: "Ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voys_Vessels_VesselId",
                        column: x => x.VesselId,
                        principalTable: "Vessels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Opinions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Qualification = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    VoyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opinions_Voys_VoyId",
                        column: x => x.VoyId,
                        principalTable: "Voys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name_status = table.Column<string>(maxLength: 50, nullable: false),
                    Arrival = table.Column<DateTime>(nullable: false),
                    Anchored = table.Column<DateTime>(nullable: false),
                    Pob = table.Column<DateTime>(nullable: false),
                    AllFast = table.Column<DateTime>(nullable: false),
                    Commenced = table.Column<DateTime>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false),
                    VoyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statuses_Voys_VoyId",
                        column: x => x.VoyId,
                        principalTable: "Voys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VoysImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    VoyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoysImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoysImages_Voys_VoyId",
                        column: x => x.VoyId,
                        principalTable: "Voys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alert_Description = table.Column<string>(nullable: false),
                    Alert_Date = table.Column<DateTime>(nullable: false),
                    StatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alerts_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Holds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Hold_Number = table.Column<int>(nullable: false),
                    Actual_Quantity = table.Column<double>(nullable: false),
                    Max_Quantity = table.Column<double>(nullable: false),
                    Is_Full = table.Column<bool>(nullable: false),
                    Is_Empty = table.Column<bool>(nullable: false),
                    First_Charge = table.Column<DateTime>(nullable: false),
                    Last_Charge = table.Column<DateTime>(nullable: false),
                    StatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holds_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlertImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    AlertId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlertImages_Alerts_AlertId",
                        column: x => x.AlertId,
                        principalTable: "Alerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlertImages_AlertId",
                table: "AlertImages",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_StatusId",
                table: "Alerts",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Holds_StatusId",
                table: "Holds",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LineUps_TerminalId",
                table: "LineUps",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_NewImageEntity_NewId",
                table: "NewImageEntity",
                column: "NewId");

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_VoyId",
                table: "Opinions",
                column: "VoyId");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_VoyId",
                table: "Statuses",
                column: "VoyId");

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_PortId",
                table: "Terminals",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_Vessels_VesselTypeId",
                table: "Vessels",
                column: "VesselTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Voys_CompanyId",
                table: "Voys",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Voys_PortId",
                table: "Voys",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_Voys_VesselId",
                table: "Voys",
                column: "VesselId");

            migrationBuilder.CreateIndex(
                name: "IX_VoysImages_VoyId",
                table: "VoysImages",
                column: "VoyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlertImages");

            migrationBuilder.DropTable(
                name: "Holds");

            migrationBuilder.DropTable(
                name: "LineUps");

            migrationBuilder.DropTable(
                name: "NewImageEntity");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Opinions");

            migrationBuilder.DropTable(
                name: "VoysImages");

            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "Terminals");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Voys");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Ports");

            migrationBuilder.DropTable(
                name: "Vessels");

            migrationBuilder.DropTable(
                name: "VesselTypes");
        }
    }
}
