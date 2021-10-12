using System;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataLayer.Models
{
    public partial class PMSContext : DbContext
    {
        public PMSContext()
        {
        }

        public PMSContext(DbContextOptions<PMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblDesignation> TblDesignation { get; set; }
        public virtual DbSet<TblEmployee> TblEmployee { get; set; }
        public virtual DbSet<TblEmployeeGoalMapping> TblEmployeeGoalMapping { get; set; }
        public virtual DbSet<TblGoal> TblGoal { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-9HO7024\\SQLEXPRESS;Database=PMS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblDesignation>(entity =>
            {
                entity.ToTable("Tbl_Designation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Designation).HasMaxLength(50);
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.ToTable("Tbl_Employee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasColumnName("EmailID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.TblEmployee)
                    .HasForeignKey(d => d.DesignationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Employee_Tbl_Designation");
            });

            modelBuilder.Entity<TblEmployeeGoalMapping>(entity =>
            {
                entity.ToTable("Tbl_EmployeeGoalMapping");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.HasOne(d => d.AssignByNavigation)
                    .WithMany(p => p.TblEmployeeGoalMappingAssignByNavigation)
                    .HasForeignKey(d => d.AssignBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_EmployeeGoalMapping_Tbl_Employee");

                entity.HasOne(d => d.AssignToNavigation)
                    .WithMany(p => p.TblEmployeeGoalMappingAssignToNavigation)
                    .HasForeignKey(d => d.AssignTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_EmployeeGoalMapping_Tbl_Employee1");
            });

            modelBuilder.Entity<TblGoal>(entity =>
            {
                entity.ToTable("Tbl_Goal");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Score).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
