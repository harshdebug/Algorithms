using System;
using System.Collections.Generic;
public class DisjointSet
{
    public class Node
    {
        public int id;
        public int rank;
        public Node parent;
        public int setTotal = 0;

        public Node(int id)
        {
            this.id = id;
            this.rank = 0;
            this.parent = this;
            this.setTotal = 1;
        }
    }

    Dictionary<int, Node> map = new Dictionary<int, Node>();

    public void MakeSet(int id)
    {
        Node cur = new Node(id);
        map.Add(id, cur);
    }

    public void Union(int a, int b)
    {
        Node p1 = FindSet(map[a].id);
        Node p2 = FindSet(map[b].id);

        if (p1 == p2)
        {
            return;
        }

        if (p1.rank >= p2.rank)
        {
            p2.parent = p1;
            p1.setTotal += p2.setTotal;
            p1.rank = (p1.rank == p2.rank) ? p1.rank + 1 : p1.rank;
        }
        else
        {
            p1.parent = p2;
            p2.setTotal += p1.setTotal;
        }
    }

    Node FindSet(int nodeId)
    {
        Node n = map[nodeId];
        while (n.parent != n)
        {
            n = n.parent;
        }

        map[nodeId].parent = n;
        return n;
    }

    public static void Main()
    {
        DisjointSet set = new DisjointSet();

        // lets say we have 10 people, union represent who is friend with whom

        for (int i = 1; i <= 10; i++)
        {
            set.MakeSet(i);
        }
        set.Union(1, 2);
        set.Union(2, 4);
        set.Union(3, 9);
        set.Union(5, 6);
        set.Union(7, 8);
        set.Union(8, 9);
        set.Union(2, 5);

        int max = 0;

        foreach (Node n in set.map.Values)
        {
            int curMax = set.FindSet(n.id).setTotal;
            if (curMax > max)
            {
                max = curMax;
            }
        }

        Console.WriteLine("Max friend group size is " + max);
    }
}
