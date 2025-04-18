using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GymLog.Common.DTOs;

public class BodyPartDto
{
    public int BodyPartId { get; set; }

    public string BodyPartName { get; set; } = null!;

    [JsonIgnore]
    public string CreatedBy { get; set; } = null!;

    [JsonIgnore]
    public string UpdatedBy { get; set; } = null!;
}
