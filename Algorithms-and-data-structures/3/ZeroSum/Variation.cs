using System;
using System.Collections.Generic;
using System.Text;

namespace ZeroSum
{
    class Variation //TODO: make Variation generic by using Variation<T>
    {
        public Variation()
        {
            this.Elements = new List<bool>();
        }

        public Variation(List<bool> elements)
        {
            this.Elements = elements;
        }

        public List<bool> Elements { get; set; }
        public int Count { get
            {
                return Elements.Count;
            }
        }

        public int Sum(int[] numbers)
        {
            int result = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                result += (Elements[i] ? 1 : -1) * numbers[i];
            }

            return result;
        }

        public override string ToString()
        {
            string result = "";
            foreach (var item in Elements)
            {
                result += (item ? "+" : "-");
            }

            return result;
        }
    }
}
