using System;
using System.Collections.Generic;
using System.Text;

namespace TreeOperations
{
    class Tree<T>
    {
        public T Value { get; set; }
        public Tree<T> Parent { get; set; }
        public List< Tree<T> > Children { get; private set; }

        public Tree(T value, params Tree<T>[] children)
        {
            this.Value = value;
            this.Children = new List<Tree<T>>();
            foreach (Tree<T> child in children)
            {
                this.Children.Add(child);
            }
        }
    }
}
