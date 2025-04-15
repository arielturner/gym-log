using System;
using System.Collections.Generic;

namespace GymLog.Common;

public partial class WorkoutTemplateExercise
{
    public int WorkoutTemplateExerciseId { get; set; }

    public int WorkoutTemplateId { get; set; }

    public int ExerciseId { get; set; }

    public int Sequence { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public virtual Exercise Exercise { get; set; } = null!;

    public virtual WorkoutTemplate WorkoutTemplate { get; set; } = null!;

    public virtual ICollection<WorkoutTemplateExerciseSet> WorkoutTemplateExerciseSets { get; set; } = new List<WorkoutTemplateExerciseSet>();
}
