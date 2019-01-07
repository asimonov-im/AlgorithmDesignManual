namespace AlgorithmDesign.Algorithms
{
    using System.Collections.Generic;
    using AlgorithmDesign.Data_Structures;

    public static partial class JobScheduling
    {
        public static List<Interval<int>> EarliestJobFirst(List<Interval<int>> jobs)
        {
            jobs.Sort();

            var result = new List<Interval<int>>();
            Interval<int>? lastJob = null;
            foreach (var job in jobs)
            {
                if (!lastJob.HasValue || Interval<int>.AreDisjoint(lastJob.Value, job))
                {
                    lastJob = job;
                    result.Add(job);
                }
            }

            return result;
        }
    }
}
