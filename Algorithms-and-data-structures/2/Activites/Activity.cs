using System;
using System.Collections.Generic;
using System.Text;

namespace Activites
{
    class Activity
    {
        public string Name { get; set; }
        public int Start { get; set; }
        public int End { get; set; }

        public override string ToString()
        {
            return Name + String.Format($"[{Start}, {End})");
        }
    }
}
