
namespace GymLog.BLL.Services
{
    public interface IExercisesService
    {
        IEnumerable<Exercise> GetExercisesByBodyPartId(int bodyPartId);
    }
}