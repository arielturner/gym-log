namespace GymLog.Common
{
    public class ExerciseDto
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; } = string.Empty;
        public int ExerciseCategoryId { get; set; }
        public int BodyPartId { get; set; }
        public int EstimatedOneRepMax { get; set; }
    }
}
