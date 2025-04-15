using System;
using System.Collections.Generic;

namespace GymLog.Common;

public partial class WorkoutProgram
{
    public int WorkoutProgramId { get; set; }

    public string WorkoutProgramName { get; set; } = null!;

    public virtual ICollection<WorkoutTemplate> WorkoutTemplates { get; set; } = new List<WorkoutTemplate>();
}
