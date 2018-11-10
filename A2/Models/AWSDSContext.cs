using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace A2.Models
{
    public partial class AWSDSContext : DbContext
    {
        public AWSDSContext()
        {
        }

        public AWSDSContext(DbContextOptions<AWSDSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appoinment> Appoinment { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=lab2db.ca3varswh4ez.us-east-2.rds.amazonaws.com; database=AWSDS; User ID=root;Password=rootroot;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appoinment>(entity =>
            {
                entity.Property(e => e.AppoinmentId)
                    .HasColumnName("AppoinmentID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AppoinmentCoz)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AppoinmentDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AppoinmentTime)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId)
                    .IsRequired()
                    .HasColumnName("StudentID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherId)
                    .IsRequired()
                    .HasColumnName("TeacherID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Appoinment)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appoinment_Student");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Appoinment)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appoinment_Teacher");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseCode);

                entity.Property(e => e.CourseCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CourseTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId)
                    .IsRequired()
                    .HasColumnName("StudentID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherId)
                    .IsRequired()
                    .HasColumnName("TeacherID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Student");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Teacher");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LoginName);

                entity.Property(e => e.LoginName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.LoginNameNavigation)
                    .WithOne(p => p.Login)
                    .HasForeignKey<Login>(d => d.LoginName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Login_Student");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.RatingId)
                    .HasColumnName("RatingID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Comment)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId)
                    .IsRequired()
                    .HasColumnName("StudentID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rating_Student");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Program)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.TeacherId)
                    .HasColumnName("TeacherID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.School)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherResume)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
