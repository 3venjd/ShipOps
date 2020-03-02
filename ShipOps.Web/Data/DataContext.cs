using Microsoft.EntityFrameworkCore;
using ShipOps.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipOps.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<AlertEntity> Alerts { get; set; }

        public DbSet<AlertImageEntity> AlertImages { get; set; }

        public DbSet<CompanyEntity> Companies { get; set; }

        public DbSet<HoldEntity> Holds { get; set; }

        public DbSet<LineUpEntity> LineUps { get; set; }

        public DbSet<NewEntity> News { get; set; }

        public DbSet<NewImageEntity> NewImages { get; set; }

        public DbSet<OfficeEntity> Offices { get; set; }

        public DbSet<OpinionEntity> Opinions { get; set; }

        public DbSet<PortEntity> Ports { get; set; }

        public DbSet<StatusEntity> Statuses { get; set; }

        public DbSet<TerminalEntity> Terminals { get; set; }

        public DbSet<TripDetailEntity> TripDetails { get; set; }

        public DbSet<VesselEntity> Vessels { get; set; }

        public DbSet<VesselTypeEntity> VesselTypes { get; set; }

        public DbSet<VoyEntity> Voys { get; set; }

        public DbSet<VoyImageEntity> VoysImages { get; set; }
    }
}
