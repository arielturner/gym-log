using System;
using System.Collections.Generic;

namespace GymLog.UI.Models;

public partial class Exercise
{
    public int ExerciseId { get; set; }

    public string ExerciseName { get; set; } = null!;

    public int ExerciseCategoryId { get; set; }

    public int BodyPartId { get; set; }

    public int? EstimatedOneRepMax { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public virtual BodyPart BodyPart { get; set; } = null!;

    public virtual ExerciseCategory ExerciseCategory { get; set; } = null!;

    public virtual ICollection<WorkoutTemplateExercise> WorkoutTemplateExercises { get; set; } = new List<WorkoutTemplateExercise>();
}
