using GymLog.Common.Enums;

namespace GymLog.BLL.Services
{
    public interface IOneRepMaxEstimator
    {
        public double GetEstimate(double weight, int reps, WeightUnit unit);
    }
}
