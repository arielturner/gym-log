using System;
using System.Collections.Generic;

namespace GymLog.BLL;

public partial class WorkoutTemplateExerciseSet
{
    public int WorkoutTemplateExerciseSetId { get; set; }

    public int WorkoutTemplateExerciseId { get; set; }

    public int Set { get; set; }

    public int Reps { get; set; }

    public int Intensity { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public virtual WorkoutTemplateExercise WorkoutTemplateExercise { get; set; } = null!;
}
