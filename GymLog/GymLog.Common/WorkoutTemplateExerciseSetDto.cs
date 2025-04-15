
namespace GymLog.Common
{
    public class WorkoutTemplateExerciseSetDto
    {
        public int WorkoutTemplateExerciseSetId { get; set; }
        public int WorkoutTemplateExerciseId { get; set; }
        public int Set { get; set; }
        public int Reps { get; set; }
        public int Intensity { get; set; }
    }
}
