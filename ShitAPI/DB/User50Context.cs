using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShitAPI.DB;

public partial class User50Context : DbContext
{
    public User50Context()
    {
    }

    public User50Context(DbContextOptions<User50Context> options)
        : base(options)
    {
    }

    public virtual DbSet<InsuranceCompany> InsuranceCompanies { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=192.168.200.35;database=user50;user=user50;password=26643;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InsuranceCompany>(entity =>
        {
            entity.ToTable("InsuranceCompany");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.InsuranceAddress).HasMaxLength(100);
            entity.Property(e => e.InsuranceBik)
                .HasMaxLength(50)
                .HasColumnName("InsuranceBIK");
            entity.Property(e => e.InsuranceInn)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("InsuranceINN");
            entity.Property(e => e.InsuranceName).HasMaxLength(50);
            entity.Property(e => e.InsurancePc)
                .HasMaxLength(50)
                .HasColumnName("InsurancePC");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Status).HasMaxLength(10);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("Patient");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.DoB).HasColumnType("datetime");
            entity.Property(e => e.Ein)
                .HasMaxLength(50)
                .HasColumnName("EIN");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.InsuranceCompanyId).HasColumnName("InsuranceCompanyID");
            entity.Property(e => e.IpAddress).HasMaxLength(50);
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NumberInsurance).HasMaxLength(16);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(18);
            entity.Property(e => e.Surname).HasMaxLength(50);
            entity.Property(e => e.TypeInsurance).HasMaxLength(50);
            entity.Property(e => e.UserAgent).HasMaxLength(200);

            entity.HasOne(d => d.InsuranceCompany).WithMany(p => p.Patients)
                .HasForeignKey(d => d.InsuranceCompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patient_InsuranceCompany");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Service");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AverageDeviation).HasMaxLength(50);
            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Deadline).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
