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


    List<Edge> PrimsMST(Graph g)
    {
        Dictionary<int, Edge> map = new Dictionary<int, Edge>();
        MinHeapMap<Vertex> queue = new MinHeapMap<Vertex>();

        List<Edge> mst = new List<Edge>();

        List<Vertex> allVertex = new List<Vertex>(g.allVertex.Values);
        Vertex start = allVertex[0];

        foreach(Vertex v in allVertex)
        {
            queue.Enqueue(v, int.MaxValue);
        }

        queue.UpdatePriority(start, 0);
        HashSet<Vertex> visited = new HashSet<Vertex>();
        visited.Add(start);


        while(queue.Count() > 0)
        {
            Vertex cur = queue.Dequeue();
            visited.Add(cur);
            if(map.ContainsKey(cur.id))
            {
                mst.Add(map[cur.id]);
            }

            foreach (Edge e in cur.adjEdge)
            {
                Vertex adj = g.GetAdjVertexForEdge(cur, e);
                if (!visited.Contains(adj) && queue.GetPriority(adj) > e.weight)
                {
                    queue.UpdatePriority(adj, e.weight);
                    if(!map.ContainsKey(adj.id))
                    {
                        map.Add(adj.id, e);
                    }
                    else
                    {
                        map[adj.id] = e;
                    }
                }
            }
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

        List<Edge> kmst = this.KruskalMST(g);
        List<Edge> mst = this.PrimsMST(g);
        foreach (Edge ed in mst)
        {
            Console.WriteLine(ed.v1.id + " " + ed.v2.id);
        }
        Console.WriteLine();
    }

    public static void Main()
    {
        MST ms = new MST();
        ms.TestMst();
    }


}

