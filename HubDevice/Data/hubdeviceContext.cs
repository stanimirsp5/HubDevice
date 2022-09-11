using System;
using HubDevice.Models;
using Microsoft.EntityFrameworkCore;

namespace HubDevice.Data
{
    //dotnet ef dbcontext scaffold "Host=localhost;Database=hubdevice;Username=stanimir;" Npgsql.EntityFrameworkCore.PostgreSQL
    public partial class hubdeviceContext : DbContext
    {
        public hubdeviceContext()
        {
        }

        public hubdeviceContext(DbContextOptions<hubdeviceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Station> Stations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=hubdevice;Username=stanimir;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("devices");

                entity.HasIndex(e => e.Id, "unique_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .HasColumnName("name");

                entity.Property(e => e.Stationid).HasColumnName("stationid");

                entity.Property(e => e.Temperature).HasColumnName("temperature");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.Stationid)
                    .HasConstraintName("fk_stationdevice");
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.ToTable("stations");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Connecteddevices).HasColumnName("connecteddevices");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
