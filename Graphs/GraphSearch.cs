using System;
using System.Collections.Generic;
public class Graph
{
    public Dictionary<int, Vertex> vertices = new Dictionary<int, Vertex>();

    public class Vertex
    {
        public int id;
        public List<Vertex> adjList = new List<Vertex>();
        public Vertex(int id)
        {
            this.id = id;
        }
    }

    public Vertex GetVertex(int id)
    {
        return this.vertices[id];
    }

    public void AddEdge(int source, int destination)
    {
        Vertex s = this.GetVertex(source);
        Vertex d = this.GetVertex(destination);
        s.adjList.Add(d);
    }

    public Vertex AddVertex(int id)
    {
        Vertex v = new Vertex(id);
        this.vertices.Add(id, v);
        return v;
    }

    public void PrintDFS(int vertexId)
    {
        Console.Write("DepthFirstSearch: ");
        HashSet<int> visited = new HashSet<int>();
        this.PrintDFS(vertexId, visited);
        Console.WriteLine();
    }

    public void PrintBFS(int vertexId)
    {
        Console.Write("BreadthFirstSearch: ");
        HashSet<int> visited = new HashSet<int>();
        this.PrintBFS(vertexId, visited);
        Console.Out.WriteLine();
    }

    public void PrintDFS(int vertexId, HashSet<int> visited)
    {
        if (visited.Contains(vertexId))
        {
            return;
        }

        visited.Add(vertexId);
        Console.Out.Write(vertexId + " -> ");
        Vertex current = this.GetVertex(vertexId);
        foreach (Vertex adj in current.adjList)
        {
            this.PrintDFS(adj.id, visited);
        }
    }

    public void PrintBFS(int vertexId, HashSet<int> visited)
    {
        Queue<int> q = new Queue<int>();
        q.Enqueue(vertexId);

        while (q.Count > 0)
        {
            int curId = q.Dequeue();
            if (visited.Contains(curId))
            {
                continue;
            }

            visited.Add(curId);
            Vertex current = this.GetVertex(curId);
            Console.Out.Write(curId + " -> ");
            foreach (Vertex adj in current.adjList)
            {
                if (!visited.Contains(adj.id))
                {
                    q.Enqueue(adj.id);
                }
            }
        }
    }

    public static void Main()
    {
        Graph g = new Graph();

        Vertex one = g.AddVertex(1);
        Vertex two = g.AddVertex(2);
        Vertex three = g.AddVertex(3);
        Vertex four = g.AddVertex(4);
        Vertex five = g.AddVertex(5);
        Vertex six = g.AddVertex(6);

        one.adjList.Add(two);
        one.adjList.Add(four);
        two.adjList.Add(three);
        three.adjList.Add(five);
        four.adjList.Add(two);
        four.adjList.Add(six);
        five.adjList.Add(one);

        g.PrintDFS(1);
        g.PrintBFS(1);
    }
}
