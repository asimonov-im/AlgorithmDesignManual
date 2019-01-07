namespace AlgorithmDesign.Algorithms
{
    using System.Collections.Generic;
    using AlgorithmDesign.Data_Structures;

    public static partial class JobScheduling
    {
        public static List<Interval<int>> Exhaustive(List<Interval<int>> jobs)
        {
            // Pre-sort jobs by interval start, to make verifying the
            // potential solutions easier.
            jobs.Sort();

            List<Interval<int>> bestSolution = new List<Interval<int>>();
            foreach (var jobSubset in jobs.GetSubsets())
            {
                if (IsValid(jobSubset) && jobSubset.Count > bestSolution.Count)
                {
                    bestSolution = jobSubset;
                }
            }

            return bestSolution;
        }

        private static bool IsValid(List<Interval<int>> jobs)
        {
            for (int i = 1; i < jobs.Count; ++i)
            {
                if (!Interval<int>.AreDisjoint(jobs[i - 1], jobs[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
