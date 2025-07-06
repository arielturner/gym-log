using System;
using System.Collections.Generic;

namespace GymLog.UI.Models;

public partial class ExerciseCategory
{
    public int ExerciseCategoryId { get; set; }

    public string ExerciseCategoryName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}
