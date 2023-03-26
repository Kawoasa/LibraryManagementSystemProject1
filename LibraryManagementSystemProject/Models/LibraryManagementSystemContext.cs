using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemProject.Models;

public partial class LibraryManagementSystemContext : DbContext
{
    public LibraryManagementSystemContext()
    {
    }

    public LibraryManagementSystemContext(DbContextOptions<LibraryManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BooksIssue> BooksIssues { get; set; }

    public virtual DbSet<Librarian> Librarians { get; set; }

    public virtual DbSet<ReturnBook> ReturnBooks { get; set; }

    public virtual DbSet<ReturnTbl> ReturnTbls { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentDepartment> StudentDepartments { get; set; }

    public virtual DbSet<StudetnSemester> StudetnSemesters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=KASA;uid=kasa;pwd=Yeuem123;database=LibraryManagementSystem;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");

            entity.Property(e => e.BookId).ValueGeneratedNever();
            entity.Property(e => e.Author).HasMaxLength(100);
            entity.Property(e => e.BookName).HasMaxLength(100);
            entity.Property(e => e.Publisher).HasMaxLength(100);
        });

        modelBuilder.Entity<BooksIssue>(entity =>
        {
            entity.HasKey(e => e.IssuNumber);

            entity.ToTable("BooksIssue");

            entity.Property(e => e.IssuNumber).ValueGeneratedNever();
            entity.Property(e => e.IssueDate).HasColumnType("date");
            entity.Property(e => e.StdDeparment).HasMaxLength(100);
            entity.Property(e => e.StdName).HasMaxLength(100);
            entity.Property(e => e.StdPhone)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.BookIssuedNavigation).WithMany(p => p.BooksIssues)
                .HasForeignKey(d => d.BookIssued)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BooksIssue_Book");

            entity.HasOne(d => d.Std).WithMany(p => p.BooksIssues)
                .HasForeignKey(d => d.StdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BooksIssue_Student");
        });

        modelBuilder.Entity<Librarian>(entity =>
        {
            entity.HasKey(e => e.LibId);

            entity.ToTable("Librarian");

            entity.Property(e => e.LibId).ValueGeneratedNever();
            entity.Property(e => e.LibName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LibPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LibPhone)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ReturnBook>(entity =>
        {
            entity.HasKey(e => e.ReturnNum);

            entity.ToTable("ReturnBook");

            entity.Property(e => e.ReturnNum).ValueGeneratedNever();
            entity.Property(e => e.IssueDate).HasColumnType("date");
            entity.Property(e => e.ReturnDate).HasColumnType("date");
            entity.Property(e => e.StdDepartment).HasMaxLength(100);
            entity.Property(e => e.StdName).HasMaxLength(100);
            entity.Property(e => e.StdPhone)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Std).WithMany(p => p.ReturnBooks)
                .HasForeignKey(d => d.StdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReturnBook_Student");
        });

        modelBuilder.Entity<ReturnTbl>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ReturnTbl");

            entity.Property(e => e.IssueDate).HasColumnType("date");
            entity.Property(e => e.ReturnDate).HasColumnType("date");
            entity.Property(e => e.StdDept).HasMaxLength(100);
            entity.Property(e => e.StdName).HasMaxLength(100);
            entity.Property(e => e.Stdphone).HasMaxLength(100);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StdId);

            entity.ToTable("Student");

            entity.Property(e => e.StdId).ValueGeneratedNever();
            entity.Property(e => e.StdName).HasMaxLength(50);
            entity.Property(e => e.StdPhone)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.StdDeparmentNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.StdDeparment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_StudentDepartment");

            entity.HasOne(d => d.StdSemesterNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.StdSemester)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_StudetnSemester");
        });

        modelBuilder.Entity<StudentDepartment>(entity =>
        {
            entity.HasKey(e => e.StdDepartmentId);

            entity.ToTable("StudentDepartment");

            entity.Property(e => e.StdDepartmentId)
                .ValueGeneratedNever()
                .HasColumnName("StdDepartmentID");
            entity.Property(e => e.StdDepartmentName).HasMaxLength(100);
        });

        modelBuilder.Entity<StudetnSemester>(entity =>
        {
            entity.HasKey(e => e.StdSemesterId);

            entity.ToTable("StudetnSemester");

            entity.Property(e => e.StdSemesterId).ValueGeneratedNever();
            entity.Property(e => e.StdSemesterName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
