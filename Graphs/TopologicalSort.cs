using System;
using System.Collections.Generic;
using System.Text;

public class Graph
{
    Dictionary<int, Vertex> map = new Dictionary<int, Vertex>();
    List<Edge> lst = new List<Edge>();

    public class Vertex
    {
        public int id;
        public bool visited;
        public Vertex(int id)
        {
            this.id = id;
            this.visited = false;
        }

        public List<Vertex> adjList = new List<Vertex>();
    }

    public class Edge
    {
        public Vertex v1;
        public Vertex v2;
        public bool directed;

        public Edge(Vertex a, Vertex b, bool directed = true)
        {
            this.v1 = a;
            this.v2 = b;
            this.directed = directed;
        }
    }

    public Vertex AddVertex(int id)
    {
        Vertex v = new Vertex(id);
        this.map.Add(id, v);
        return v;
    }

    public void AddEdge(Vertex a, Vertex b, bool directed = true)
    {
        a.adjList.Add(b);

        if (!directed)
        {
            b.adjList.Add(a);
        }

        Edge e = new Edge(a, b, directed);
        this.lst.Add(e);
    }

    public void PrintDFS(Vertex v)
    {
        HashSet<Vertex> visited = new HashSet<Vertex>();
        PrintDFS(v, visited);
    }

    public void PrintDFS(Vertex v, HashSet<Vertex> visited)
    {
        visited.Add(v);
        Console.WriteLine(v.id);

        foreach (Vertex adj in v.adjList)
        {
            if (!visited.Contains(adj))
            {
                PrintDFS(adj, visited);
            }
        }
    }

    public void PrintBFS(Vertex v)
    {
        Queue<Vertex> q = new Queue<Vertex>();
        HashSet<Vertex> visited = new HashSet<Vertex>();

        visited.Add(v);
        q.Enqueue(v);

        while (q.Count > 0)
        {
            Vertex cur = q.Dequeue();
            Console.WriteLine(cur.id);
            foreach (Vertex adj in cur.adjList)
            {
                if (!visited.Contains(adj))
                {
                    visited.Add(adj);
                    q.Enqueue(adj);
                }
            }
        }
    }

    public void PrintTopologicalSort()
    {
        Stack<Vertex> stk = new Stack<Vertex>();
        HashSet<Vertex> visited = new HashSet<Vertex>();

        foreach (Vertex v in map.Values)
        {
            TopSortUtil(v, visited, stk);
        }

        while (stk.Count > 0)
        {
            Console.WriteLine(stk.Pop().id);
        }
    }

    public void TopSortUtil(Vertex v, HashSet<Vertex> visited, Stack<Vertex> stk)
    {
        if (visited.Contains(v))
        {
            return;
        }
        visited.Add(v);
        foreach (Vertex adj in v.adjList)
        {
            if (!visited.Contains(adj))
            {
                TopSortUtil(adj, visited, stk);
            }
        }
        stk.Push(v);
    }

    public void ResetVisited()
    {
        foreach (Vertex v in map.Values)
        {
            v.visited = false;
        }
    }


    public void Test()
    {
        Vertex one = AddVertex(1);
        Vertex two = AddVertex(2);
        Vertex three = AddVertex(3);
        Vertex four = AddVertex(4);
        Vertex five = AddVertex(5);
        Vertex six = AddVertex(6);
        Vertex seven = AddVertex(7);

        AddEdge(one, two, true);
        AddEdge(one, four, true);
        AddEdge(two, three, true);
        AddEdge(three, five, true);
        AddEdge(four, two, true);
        AddEdge(four, six, true);
        AddEdge(five, seven, true);

        Console.WriteLine("DFS");
        PrintDFS(one);
        ResetVisited();

        Console.WriteLine("BFS");
        PrintBFS(one);

        Console.WriteLine("Topological Sort");
        PrintTopologicalSort();

        ResetVisited();
    }

    public static void Main()
    {
        Graph g = new Graph();
        g.Test();
    }
}