using GymLog.Common.Enums;

namespace GymLog.BLL.Services
{

    public class OneRepMaxEstimator : IOneRepMaxEstimator
    {
        private readonly Dictionary<int, double> _percentages = new()
        {
            { 1, 1 },
            { 2, 0.955 },
            { 3, 0.922 },
            { 4, 0.892 },
            { 5, 0.863 },
            { 6, 0.837 },
            { 7, 0.811 },
            { 8, 0.786 },
            { 9, 0.762 },
            { 10, 0.739 },
        };

        public double GetEstimate(double weight, int reps, WeightUnit unit)
        {
            if (reps is < 0 or > 10)
            {
                throw new ArgumentException("Reps must be between 1 and 10");
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Weight must be positive");
            }

            double estimatedOneRepMax = weight / _percentages[reps];
            double smallestWeightIncrement = unit == WeightUnit.Pounds ? 5 : 2.5;

            double roundedToNearestIncrement =
                Math.Round(estimatedOneRepMax / smallestWeightIncrement) * smallestWeightIncrement;

            return roundedToNearestIncrement;
        }
    }
}
