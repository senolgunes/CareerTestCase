using CareerTestCase.DAL.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace CareerTestCase.DAL
{
    public class DataContext: DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Cv> Cvs { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Experince> Experincies { get; set; }
        public virtual DbSet<Job> Jops { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Apply> Applies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Cv>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_Cvs_1");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CvName).HasMaxLength(50);

                entity.Property(e => e.JobName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                  .WithOne(p => p.Cvs)
                  .HasForeignKey<Cv>(d => d.UserId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Cvs_Users");
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.Property(e => e.DepartmanName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StarDate).HasColumnType("datetime");

                entity.Property(e => e.UniversityName)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Cvs)
                    .WithMany(p => p.Educations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Educations_Cvs");
            });

            modelBuilder.Entity<Experince>(entity =>
            {
                entity.Property(e => e.ConpanyName).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Cvs)
                   .WithMany(p => p.Experincies)
                   .HasForeignKey(d => d.UserId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Experincies_CVs");
            });
           
            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ExpirationTime).HasColumnType("datetime");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Jops)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Jops_Company");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });
            modelBuilder.Entity<Apply>(entity =>
            {
                entity.Property(e => e.JopId).HasColumnName("Jop_id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Jop)
                    .WithMany(r => r.Applies)
                    .HasForeignKey(d => d.JopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Applies_Jop");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Applies)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Applies_User");
            });
        }
    }
}
