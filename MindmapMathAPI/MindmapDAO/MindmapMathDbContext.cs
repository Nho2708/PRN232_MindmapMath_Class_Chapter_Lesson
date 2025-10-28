using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MindmapBO.Models;

namespace MindmapBO.Data;

public partial class MindmapMathDbContext : DbContext
{
    public MindmapMathDbContext()
    {
    }

    public MindmapMathDbContext(DbContextOptions<MindmapMathDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chapter> Chapters { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Models.Math> Maths { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString =
                "Server=switchback.proxy.rlwy.net;Port=35539;Database=railway;" +
                "User Id=root;Password=wkzEOkNgSkVYSEuvAgCqqqqeqhdkvNcB;" +
                "SslMode=Required;AllowPublicKeyRetrieval=True;";

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Chapter>(entity =>
        {
            entity.HasKey(e => e.ChapterId).HasName("PK__Chapter__0893A36AF475BD20");

            entity.ToTable("Chapter");

            entity.Property(e => e.ChapterName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(250);

            entity.HasOne(d => d.Class).WithMany(p => p.Chapters)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK_Chapter_Class");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Class__CB1927C09F7667A3");

            entity.ToTable("Class");

            entity.Property(e => e.ClassName).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.OrderIndex).HasMaxLength(10);

            entity.HasOne(d => d.Math).WithMany(p => p.Classes)
                .HasForeignKey(d => d.MathId)
                .HasConstraintName("FK_Class_Math");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.LessonId).HasName("PK__Lesson__B084ACD0E3F46627");

            entity.ToTable("Lesson");

            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.LessonName).HasMaxLength(100);

            entity.HasOne(d => d.Chapter).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.ChapterId)
                .HasConstraintName("FK_Lesson_Chapter");
        });

        modelBuilder.Entity<Models.Math>(entity =>
        {
            entity.HasKey(e => e.MathId).HasName("PK__Math__86E7F4F8672149C1");

            entity.ToTable("Math");

            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.SubjectName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
