using System;
using System.Collections.Generic;
using System.Text;

public class Trie
{
    public class Node
    {
        public bool end;
        public Dictionary<char, Node> map;
        public Node()
        {
            this.end = false;
            this.map = new Dictionary<char, Node>();
        }
    }

    public Node root = new Node();

    public void Insert(string inp)
    {
        Node cur = root;
        for (int i = 0; i < inp.Length; i++)
        {
            if (cur.map.ContainsKey(inp[i]))
            {
                cur = cur.map[inp[i]];
            }
            else
            {
                Node n = new Node();
                cur.map.Add(inp[i], n);
                cur = n;
            }
        }

        cur.end = true;
    }

    public string LongestCommonPrefix()
    {
        StringBuilder sb = new StringBuilder();
        Node cur = root;

        while (cur.map.Count == 1)
        {
            foreach (char c in cur.map.Keys)
            {
                sb.Append(c);
                cur = cur.map[c];
            }
        }

        return sb.ToString();
    }

    public static void Main(string[] args)
    {
        Trie test = new Trie();
        test.Insert("flower");
        test.Insert("flow");
        test.Insert("fluid");
        test.Insert("flow chart");

        Console.WriteLine(test.LongestCommonPrefix());
    }
}