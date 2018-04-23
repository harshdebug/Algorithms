using System;
using System.Collections.Generic;

public class PriorityQueue<T>
{
    public PriorityQueue()
    {
    }

    public class Data
    {
        public T item;
        public int priority;

        public Data(T item, int pr)
        {
            this.item = item;
            this.priority = pr;
        }
    }

    List<Data> lst = new List<Data>();


    int Left(int i)
    {
        return 2 * i + 1;
    }

    int Right(int i)
    {
        return 2 * i + 2;
    }

    int Parent(int i)
    {
        return (i - 1) / 2;
    }

    public void Enqueue(T item, int priority)
    {
        Data d = new Data(item, priority);
        lst.Add(d);
        int i = lst.Count - 1;
        int p = Parent(i);
        while(p>=0 && lst[p].priority < lst[i].priority)
        {
            Swap(p, i);
            i = p;
            p = Parent(p);
        }
    }

    void Swap(int a, int b)
    {
        Data temp = lst[a];
        lst[a] = lst[b];
        lst[b] = temp;
    }

    public T Dequeue()
    {
        Swap(0, lst.Count - 1);
        Data d = lst[lst.Count - 1];
        lst.RemoveAt(lst.Count-1);
        Sink(0);
        return d.item;
    }

    public void Sink(int i)
    {
        if(i>=lst.Count)
        {
            return;
        }
        int l = Left(i);
        int r = Right(i);

        int max = i;

        if(l<lst.Count && lst[l].priority > lst[max].priority)
        {
            max = l;
        }
        if(r<lst.Count && lst[r].priority > lst[max].priority)
        {
            max = r;
        }

        if(max != i)
        {
            Swap(i, max);
            Sink(max);
        }
    }    
}

public class PriorityQueue
{
    public static void Main(string[] args)
    {
        PriorityQueue<string> pq = new PriorityQueue<string>();
        pq.Enqueue("Bob", 5);
        pq.Enqueue("Rob", 10);
        pq.Enqueue("Mike", 6);
        pq.Enqueue("Tina", 3);
        pq.Enqueue("Andy", 2);
        pq.Enqueue("Judy", 9);

        int ct = 6;
        while (ct > 0)
        {
            Console.WriteLine(pq.Dequeue());
            ct--;
        }
    }
}
