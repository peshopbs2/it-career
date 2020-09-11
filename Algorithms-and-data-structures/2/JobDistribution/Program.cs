using System;
using System.Collections.Generic;
using System.Linq;

namespace JobDistribution
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Job> jobs = new List<Job>();
            int jobsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < jobsCount; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                jobs.Add(new Job()
                {
                    Id = int.Parse(input[0]),
                    Deadline = int.Parse(input[1]),
                    Price = double.Parse(input[2])
                });
            }

            jobs = jobs.OrderByDescending(item => item.Price).ToList();
            var selectedJob = jobs.First();
            List<Job> solution = new List<Job>();
            solution.Add(selectedJob);
            foreach (var job in jobs)
            {
                if (job.Deadline > selectedJob.Deadline)
                {
                    selectedJob = job;
                    solution.Add(job);
                }
            }

            Console.WriteLine(string.Join(", ", solution));
            Console.WriteLine(solution.Sum(item => item.Price));
        }
    }
}
