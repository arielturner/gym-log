using System;
using System.Collections.Generic;

namespace GymLog.Common;

public partial class WorkoutTemplateExerciseSet
{
    public int WorkoutTemplateExerciseSetId { get; set; }

    public int WorkoutTemplateExerciseId { get; set; }

    public int Set { get; set; }

    public int Reps { get; set; }

    public int Intensity { get; set; }

    public virtual WorkoutTemplateExercise WorkoutTemplateExercise { get; set; } = null!;
}
