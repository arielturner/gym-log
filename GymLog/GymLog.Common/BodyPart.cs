using System;
using System.Collections.Generic;

namespace GymLog.Common;

public partial class BodyPart
{
    public int BodyPartId { get; set; }

    public string BodyPartName { get; set; } = null!;

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}
