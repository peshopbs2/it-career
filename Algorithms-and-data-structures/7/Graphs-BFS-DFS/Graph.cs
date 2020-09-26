using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BFS
{
    class Graph //the whole graph represented by list of neighbours
    {
        public Dictionary<int, Node> Nodes { get; private set; }
        public bool IsOriented { get; private set; }
        private List<Node> DFSTraversalResult;
        private Dictionary<Node, bool> dfsUsed;

        public Graph(bool isOriented = false)
        {
            Nodes = new Dictionary<int, Node>();
            IsOriented = isOriented;
        }
        public bool Exists(int vertex)
        {
            return Nodes.ContainsKey(vertex);
        }

        public void Print()
        {
            foreach (var item in Nodes.Values)
            {
                Console.Write($"{item.Value}: ");
                item.PrintNeighbours();
            }
        }

        public void AddEdge(int alpha, int beta, bool another = true)
        {
            if (Exists(alpha))
            {
                Nodes[alpha].AddNeighbour(beta);
            } else
            {
                Node node = this.AddVertex(alpha); //node is the created Alpha node
                node.AddNeighbour(beta);
            }

            if (!IsOriented && another)
            {
                AddEdge(beta, alpha, false);
            }
        }

        public Node AddVertex(int vertex)
        {
            Nodes.Add(vertex, new Node(this, vertex));
            return Nodes[vertex];
        }

        public List<Node> DFS(Node start)
        {
            DFSTraversalResult = new List<Node>();
            dfsUsed = new Dictionary<Node, bool>();
            DFSTraversal(start);
            return DFSTraversalResult;
        }

        private void DFSTraversal(Node node)
        {
            dfsUsed.Add(node, true);
            DFSTraversalResult.Add(node);

            foreach (Node item in node.Neighbours)
            {
                bool isUsed = false;
                dfsUsed.TryGetValue(item, out isUsed);

                if (!isUsed)
                {
                    DFSTraversal(item);
                }
            }
        }

        public List<Node> BFS(Node start)
        {
            Queue<Node> queue = new Queue<Node>();
            List<Node> traversal = new List<Node>();
            Dictionary<Node, bool> used = new Dictionary<Node, bool>();

            queue.Enqueue(start);
            used.Add(start, true);

            while (queue.Count > 0) //while the queue is not empty
            {
                Node top = queue.Dequeue();
                traversal.Add(top); //добавяне към списъка на обходените елементи
                foreach (Node item in top.Neighbours)
                {
                    bool isUsed = false;
                    used.TryGetValue(item, out isUsed);
                    if (!isUsed)
                    {
                        queue.Enqueue(item);
                        used.Add(item, true);
                    }
                }
            }

            return traversal;
        }

        public class Node //1 vertex
        {
            public int Value { get; private set; }
            public IReadOnlyList<Node> Neighbours { get; private set; }
            private Graph graph;

            public Node(Graph graph, int value)
            {
                this.Neighbours = new List<Node>();
                this.Value = value;
                this.graph = graph;
            }

            public void AddNeighbour(int value)
            {
                Node neighbour;
                if (this.graph.Exists(value))
                {
                    neighbour = this.graph.Nodes[value];
                }
                else
                {
                    neighbour = this.graph.AddVertex(value);
                }

                this.Neighbours = 
                    this.Neighbours.Append(neighbour).ToList();
            }

            public void PrintNeighbours()
            {
                foreach (var item in this.Neighbours)
                {
                    Console.Write(item.Value + ", ");
                }
                Console.WriteLine();
            }
        }

    }
}
