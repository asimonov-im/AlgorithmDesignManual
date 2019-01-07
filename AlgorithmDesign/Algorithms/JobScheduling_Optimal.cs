namespace AlgorithmDesign.Algorithms
{
    using System.Collections.Generic;
    using AlgorithmDesign.Data_Structures;

    public static partial class JobScheduling
    {
        public static List<Interval<int>> Optimal(List<Interval<int>> jobs)
        {
            jobs.Sort((a, b) =>
            {
                int endCompare = a.End.CompareTo(b.End);
                return endCompare == 0 ? a.Start.CompareTo(b.Start) : endCompare;
            });

            var solution = new List<Interval<int>>();
            Interval<int>? lastJobTaken = null;
            foreach (var job in jobs)
            {
                if (!lastJobTaken.HasValue || Interval<int>.AreDisjoint(lastJobTaken.Value, job))
                {
                    lastJobTaken = job;
                    solution.Add(job);
                }
            }

            return solution;
        }
    }
}
