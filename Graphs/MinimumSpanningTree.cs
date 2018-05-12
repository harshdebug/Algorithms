using System;
using System.Collections.Generic;
using Graphs;

public class MST
{
    public MST()
    {
    }

    List<Edge> KruskalMST(Graph g)
    {
        EdgeComparer ec = new EdgeComparer();
        List<Edge> allEdges = g.allEdges;
        allEdges.Sort(ec);

        DisjointSet ds = new DisjointSet();
        foreach (Vertex v in g.allVertex.Values)
        {
            ds.MakeSet(v.id);
        }

        List<Edge> mst = new List<Edge>();
        foreach (Edge e in allEdges)
        {
            int p1 = ds.FindSet(e.v1.id);
            int p2 = ds.FindSet(e.v2.id);

            if (p1 == p2)
            {
                continue;
            }

            mst.Add(e);
            ds.Union(p1, p2);
        }

        return mst;
    }

    public class EdgeComparer : IComparer<Edge>
    {
        public int Compare(Edge e1, Edge e2)
        {
            return e1.weight.CompareTo(e2.weight);
        }
    }

    public void TestMst()
    {
        Graph g = new Graph();

        Vertex a = g.AddVertex(1, 'A');
        Vertex b = g.AddVertex(2, 'B');
        Vertex c = g.AddVertex(3, 'C');
        Vertex d = g.AddVertex(4, 'D');
        Vertex e = g.AddVertex(5, 'E');
        Vertex f = g.AddVertex(6, 'F');

        g.AddEdge(a, b, 3);
        g.AddEdge(a, d, 1);
        g.AddEdge(b, c, 1);
        g.AddEdge(b, d, 3);
        g.AddEdge(d, c, 1);
        g.AddEdge(d, e, 6);
        g.AddEdge(c, e, 5);
        g.AddEdge(c, f, 4);
        g.AddEdge(f, e, 2);

        List<Edge> mst = this.KruskalMST(g);
        foreach (Edge ed in mst)
        {
            Console.WriteLine(ed.v1.id + " " + ed.v2.id);
        }
    }

    public static void Main()
    {
        MST ms = new MST();
        ms.TestMst();
    }


}

