using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymLog.UI.Models;

public partial class BodyPart
{
    [Display(Name = "ID")]
    public int BodyPartId { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Body Part Name")]
    public string BodyPartName { get; set; }

    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    [StringLength(50)]
    public string? UpdatedBy { get; set; }

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}
