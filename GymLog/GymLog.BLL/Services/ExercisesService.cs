using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLog.BLL.Services
{
    public class ExercisesService : IExercisesService
    {
        private readonly GymLogContext _gymLogContext;

        public ExercisesService(GymLogContext gymLogContext)
        {
            _gymLogContext = gymLogContext;
        }

        public IEnumerable<Exercise> GetExercisesByBodyPartId(int bodyPartId)
        {
            return _gymLogContext.Exercises
                .Where(e => e.BodyPartId == bodyPartId)
                .ToList();
        }
    }
}
