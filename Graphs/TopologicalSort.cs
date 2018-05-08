using System;
using System.Collections.Generic;
using System.Text;
using Graphs;

public class TopSort
{
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

    public void PrintTopologicalSort(Graph g)
    {
        Stack<Vertex> stk = new Stack<Vertex>();
        HashSet<Vertex> visited = new HashSet<Vertex>();

        foreach (Vertex v in g.map.Values)
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
   
    public static void Main()
    {
        TopSort srt = new TopSort();
        srt.Test();
    }

    public void Test()
    {
        Graph g = new Graph();

        Vertex one = g.AddVertex(1);
        Vertex two = g.AddVertex(2);
        Vertex three = g.AddVertex(3);
        Vertex four = g.AddVertex(4);
        Vertex five = g.AddVertex(5);
        Vertex six = g.AddVertex(6);
        Vertex seven = g.AddVertex(7);

        g.AddEdge(one, two, true);
        g.AddEdge(one, four, true);
        g.AddEdge(two, three, true);
        g.AddEdge(three, five, true);
        g.AddEdge(four, two, true);
        g.AddEdge(four, six, true);
        g.AddEdge(five, seven, true);

        Console.WriteLine("DFS");
        PrintDFS(one);


        Console.WriteLine("BFS");
        PrintBFS(one);

        Console.WriteLine("Topological Sort");
        PrintTopologicalSort(g);


    }


}