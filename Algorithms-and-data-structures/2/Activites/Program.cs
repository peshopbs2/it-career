using System;
using System.Collections.Generic;
using System.Linq;

namespace Activites
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Activity> activities = new List<Activity>();
            //a1 1 3
            string[] input = Console.ReadLine().Split(' ');
            while (input[0] != "END")
            {
                activities.Add(new Activity()
                {
                    Name = input[0],
                    Start = int.Parse(input[1]),
                    End = int.Parse(input[2])
                });
                input = Console.ReadLine().Split(' ');
            }

            Queue<Activity> queueActivities = new Queue<Activity>();
            activities = activities.OrderBy(item => item.End).ToList();
            Console.WriteLine($"Printed order: {string.Join(", ", activities)}");
            Activity selectedActivity = activities.First();
            queueActivities.Enqueue(selectedActivity);

            foreach (var currentActivity in activities)
            {
                if (currentActivity.Start >= selectedActivity.End)
                {
                    queueActivities.Enqueue(currentActivity);
                    selectedActivity = currentActivity;
                }
            }

            Console.WriteLine("Best probable:" + string.Join(", ", queueActivities));
        }
    }
}
