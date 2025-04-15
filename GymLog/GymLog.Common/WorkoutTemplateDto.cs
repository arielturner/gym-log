namespace GymLog.Common
{
    public class WorkoutTemplateDto
    {
        public int WorkoutTemplateId { get; set; }
        public string WorkoutTemplateName { get; set; } = string.Empty;
        public int WorkoutProgramId { get; set; }
        public int Week { get; set; }
        public int Day { get; set; }
    }
}
