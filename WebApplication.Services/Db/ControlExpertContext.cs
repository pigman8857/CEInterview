using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication.Services.Model
{
    /*
     * -Add DbContext from existing Db schema
    Scaffold-DbContext "Server=localhost;Database=ControlExpert;Trusted_Connection=True;" 
    Microsoft.EntityFrameworkCore.SqlServer -OutputDir Model -ContextDir Db
    */

    //Data Feeding & Migration
    /*-Create Entity Has data in OnModelCreating
     * -Run Add-Migration SeedControlExpertDb in Package manager console, it will use OnModelCreating.
     * -Run Update-Database in package manager console.
     */
    public partial class ControlExpertContext : DbContext
    {
        public ControlExpertContext()
        {
        }

        public ControlExpertContext(DbContextOptions<ControlExpertContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<VehicleModel> VehicleModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=ControlExpert;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .ValueGeneratedNever();

                entity.Property(e => e.ManufacturerName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<VehicleModel>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .ValueGeneratedNever();

                entity.Property(e => e.ManufacturerId)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ModelName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.VehicleModel)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VehicleMo__Manuf__2B3F6F97");
            });

            var manufacturers = Db.GetManufacturers();

            modelBuilder.Entity<Manufacturer>().HasData(manufacturers.ToArray());
               
            var vehicleModels = Db.GetModels();

            modelBuilder.Entity<VehicleModel>().HasData(vehicleModels.ToArray());
          
        }
    }
}
