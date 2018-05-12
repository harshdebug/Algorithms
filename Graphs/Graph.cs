using System;
using System.Collections.Generic;
namespace Graphs
{
	public class Vertex
	{
		public int id;
		public char label;
		public List<Vertex> adjList = new List<Vertex>();
        public List<Edge> adjEdge = new List<Edge>();

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

		public Edge(Vertex a, Vertex b, int weight = 0, bool directed = false)
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

		public Vertex AddVertex(int id, char lable = ' ')
		{
			Vertex v = new Vertex(id);
			allVertex.Add(id, v);
            v.label = lable;
			return v;
		}

		public void AddEdge(Vertex v1, Vertex v2, int weight = 0, bool directed = false)
		{
			Edge e = new Edge(v1, v2, weight, directed);
			allEdges.Add(e);

			v1.adjList.Add(v2);
            v1.adjEdge.Add(e);
			if (!directed)
			{
				v2.adjList.Add(v1);
                v2.adjEdge.Add(e);
			}
		}

        public Vertex GetAdjVertexForEdge(Vertex cur, Edge e)
        {
            if(e.v1 == cur)
            {
                return e.v2;
            }
            return e.v1;
        }
	}
}
