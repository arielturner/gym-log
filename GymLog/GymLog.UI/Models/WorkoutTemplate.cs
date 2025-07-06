using System;
using System.Collections.Generic;

namespace GymLog.UI.Models;

public partial class WorkoutTemplate
{
    public int WorkoutTemplateId { get; set; }

    public string WorkoutTemplateName { get; set; } = null!;

    public int WorkoutProgramId { get; set; }

    public int Week { get; set; }

    public int Day { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public virtual WorkoutProgram WorkoutProgram { get; set; } = null!;

    public virtual ICollection<WorkoutTemplateExercise> WorkoutTemplateExercises { get; set; } = new List<WorkoutTemplateExercise>();
}
