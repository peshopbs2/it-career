using System;
using System.Collections.Generic;
using System.Text;

namespace MagnetTape
{
    class Operation
    {
        public int Id { get; set; }
        public int Length { get; set; }
        public double Probability { get; set; }
        public double Ratio
        {
            get
            {
                return Probability / Length;
            }
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
