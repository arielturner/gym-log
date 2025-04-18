﻿using System;
using System.Collections.Generic;

namespace GymLog.Common.DTOs;

public class BodyPartDto
{
    public int BodyPartId { get; set; }

    public string BodyPartName { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public string UpdatedBy { get; set; } = null!;
}
