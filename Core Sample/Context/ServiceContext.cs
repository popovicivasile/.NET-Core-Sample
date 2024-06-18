using System;
using System.Collections.Generic;
using Core_Sample.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_Sample.Context;

public partial class ServiceContext : DbContext
{
    public ServiceContext()
    {
    }

    public ServiceContext(DbContextOptions<ServiceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Machine> Machines { get; set; }

    public virtual DbSet<MachinesAttirbute> MachinesAttirbutes { get; set; }

    public virtual DbSet<Maintenance> Maintenances { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configFileName = "Development";


        if (string.IsNullOrEmpty(configFileName))
        {
            throw new Exception("DEV-PROD Environment not found in environment variables");
        }

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile(configFileName != null ? $"appsettings.{configFileName}.json" : "appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("Service"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Machine>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FuelType).HasMaxLength(50);
            entity.Property(e => e.MachineSerial).HasMaxLength(50);
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Trademark).HasMaxLength(50);
            entity.Property(e => e.EngineHours);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.HasOne(d => d.Account)
              .WithMany(p => p.Machines)
              .HasForeignKey(d => d.AccountId)
              .OnDelete(DeleteBehavior.ClientSetNull); 

        });

        modelBuilder.Entity<MachinesAttirbute>(entity =>
        {
            entity.Property(e => e.Imei).HasColumnName("imei");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.Speed).HasColumnName("speed");
            entity.Property(e => e.Timestamp).HasColumnName("timestamp");
        });

        modelBuilder.Entity<Maintenance>(entity =>
        {
            entity.ToTable("Maintenance");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Maintenance)
                .HasForeignKey<Maintenance>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Maintenance_Machines");
        });

        modelBuilder.Entity<Account>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.maxMachines);
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<Account> Account { get; set; } = default!;
}
