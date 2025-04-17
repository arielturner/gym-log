using System;
using System.Collections.Generic;
using GymLog.Common;
using Microsoft.EntityFrameworkCore;

namespace GymLog.DAL;

public partial class GymLogContext : DbContext
{
    public GymLogContext()
    {
    }

    public GymLogContext(DbContextOptions<GymLogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BodyPart> BodyParts { get; set; }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<ExerciseCategory> ExerciseCategories { get; set; }

    public virtual DbSet<WorkoutProgram> WorkoutPrograms { get; set; }

    public virtual DbSet<WorkoutTemplate> WorkoutTemplates { get; set; }

    public virtual DbSet<WorkoutTemplateExercise> WorkoutTemplateExercises { get; set; }

    public virtual DbSet<WorkoutTemplateExerciseSet> WorkoutTemplateExerciseSets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BodyPart>(entity =>
        {
            entity.ToTable("BodyPart");

            entity.HasIndex(e => e.BodyPartName, "UQ_BodyPart_BodyPartName").IsUnique();

            entity.Property(e => e.BodyPartName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.ToTable("Exercise");

            entity.HasIndex(e => e.ExerciseName, "UQ_Exercise_ExerciseName").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ExerciseName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.BodyPart).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.BodyPartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exercise_BodyPart");

            entity.HasOne(d => d.ExerciseCategory).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.ExerciseCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exercise_ExerciseCategory");
        });

        modelBuilder.Entity<ExerciseCategory>(entity =>
        {
            entity.ToTable("ExerciseCategory");

            entity.HasIndex(e => e.ExerciseCategoryName, "UQ_ExerciseCategory_ExerciseCategoryName").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ExerciseCategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WorkoutProgram>(entity =>
        {
            entity.ToTable("WorkoutProgram");

            entity.HasIndex(e => e.WorkoutProgramName, "UQ_WorkoutProgram_WorkoutProgramName").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WorkoutProgramName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WorkoutTemplate>(entity =>
        {
            entity.ToTable("WorkoutTemplate");

            entity.HasIndex(e => e.WorkoutTemplateName, "UQ_WorkoutTemplate_WorkoutTemplateName").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WorkoutTemplateName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.WorkoutProgram).WithMany(p => p.WorkoutTemplates)
                .HasForeignKey(d => d.WorkoutProgramId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkoutTemplate_WorkoutProgram");
        });

        modelBuilder.Entity<WorkoutTemplateExercise>(entity =>
        {
            entity.ToTable("WorkoutTemplateExercise");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Exercise).WithMany(p => p.WorkoutTemplateExercises)
                .HasForeignKey(d => d.ExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkoutTemplateExercise_Exercise");

            entity.HasOne(d => d.WorkoutTemplate).WithMany(p => p.WorkoutTemplateExercises)
                .HasForeignKey(d => d.WorkoutTemplateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkoutTemplateExercise_WorkoutTemplate");
        });

        modelBuilder.Entity<WorkoutTemplateExerciseSet>(entity =>
        {
            entity.ToTable("WorkoutTemplateExerciseSet");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.WorkoutTemplateExercise).WithMany(p => p.WorkoutTemplateExerciseSets)
                .HasForeignKey(d => d.WorkoutTemplateExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkoutTemplateExerciseSet_WorkoutTemplateExercise");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
