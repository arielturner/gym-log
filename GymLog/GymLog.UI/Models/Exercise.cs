using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymLog.UI.Models;

public partial class Exercise
{
    [Display(Name = "ID")]
    public int ExerciseId { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Name")]
    public string? ExerciseName { get; set; }

    [Required]
    [Display(Name = "Exercise Category")]
    public int ExerciseCategoryId { get; set; }

    [Required]
    [Display(Name = "Body Part")]
    public int BodyPartId { get; set; }

    [Display(Name = "Estimated 1RM")]
    public int? EstimatedOneRepMax { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    [Display(Name = "Body Part")]
    public virtual BodyPart? BodyPart { get; set; }

    [Display(Name = "Category")]
    public virtual ExerciseCategory? ExerciseCategory { get; set; }

    public virtual ICollection<WorkoutTemplateExercise> WorkoutTemplateExercises { get; set; } = new List<WorkoutTemplateExercise>();
}
