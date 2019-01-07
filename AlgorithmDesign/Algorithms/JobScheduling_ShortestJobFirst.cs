namespace AlgorithmDesign.Algorithms
{
    using System.Collections.Generic;
    using System.Linq;
    using AlgorithmDesign.Data_Structures;

    public static partial class JobScheduling
    {
        public static List<Interval<int>> ShortestJobFirst(List<Interval<int>> jobs)
        {
            jobs.Sort((a, b) => a.Length().CompareTo(b.Length()));

            var result = new List<Interval<int>>();
            while (jobs.Count > 0)
            {
                var nextJob = jobs.First();
                result.Add(nextJob);
                jobs.RemoveAll(j => !Interval<int>.AreDisjoint(nextJob, j));
            }

            return result;
        }

        public static int Length(this Interval<int> interval)
        {
            return interval.End - interval.Start;
        }
    }
}
