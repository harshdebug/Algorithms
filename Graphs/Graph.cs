using System;
using System.Collections.Generic;
namespace Graphs
{
    public class Vertex
    {
        public int id;
        public char label;
        public List<Vertex> adjList = new List<Vertex>();

        public Vertex(int id)
        {
            this.id = id;
        }
    }

    public class Edge
    {
        public Vertex v1;
        public Vertex v2;
        public bool directional;
        public int weight;

        public Edge(Vertex a, Vertex b, bool directed = false, int weight = 0)
        {
            this.v1 = a;
            this.v2 = b;
            this.directional = directed;
            this.weight = weight;
        }
    }

    public class Graph
    {
        public Graph()
        {
        }

        public Dictionary<int, Vertex> allVertex = new Dictionary<int, Vertex>();
        public List<Edge> allEdges = new List<Edge>();

        public Vertex AddVertex(int id)
        {
            Vertex v = new Vertex(id);
            allVertex.Add(id, v);
            return v;
        }

        public void AddEdge(Vertex v1, Vertex v2, bool directed = false, int weight = 0)
        {
            Edge e = new Edge(v1, v2, directed, weight);
            allEdges.Add(e);

            v1.adjList.Add(v2);
            if (!directed)
            {
                v2.adjList.Add(v1);
            }
        }
    }
}
