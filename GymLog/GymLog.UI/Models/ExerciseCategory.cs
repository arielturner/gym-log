using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymLog.UI.Models;

public partial class ExerciseCategory
{
    [Display(Name = "ID")]
    public int ExerciseCategoryId { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Name")]
    public string? ExerciseCategoryName { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}
