using System;
using System.Collections.Generic;
using System.Text;

namespace JobDistribution
{
    class Job
    {
        public int Id { get; set; }
        public int Deadline { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return string.Format($"j{Id}");
        }
    }
}
