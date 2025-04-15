using System;
using System.Collections.Generic;

namespace GymLog.Common;

public partial class ExerciseCategory
{
    public int ExerciseCategoryId { get; set; }

    public string ExerciseCategoryName { get; set; } = null!;

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}
