using System;
using System.Collections.Generic;

public class HeapMap<T>
{	
    private class Item
	{
		public int priority;
		public T val;

        public Item(T val, int priority)
		{
			this.priority = priority;
			this.val = val;
		}
	}

	List<Item> lst = new List<Item>();
	Dictionary<T, int> dict = new Dictionary<T, int>();

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

	public void Enqueue(T val, int priority)
	{
		Item cur = new Item(val, priority);
		lst.Add(cur);
		dict.Add(val, lst.Count - 1);
		int i = lst.Count - 1;
		Swim(i);
	}

	public T Dequeue()
	{
        Item top = lst[0];
        Swap(0,lst.Count -1);
        lst.RemoveAt(lst.Count -1);
        Sink(0);		
		return top.val;
	}

	public void UpdatePriority(T val, int priority)
	{
		Item cur = lst[dict[val]];

		if (cur.priority > priority)
		{
			cur.priority = priority;
			Sink(dict[val]);
		}
		else if (cur.priority < priority)
		{
			cur.priority = priority;
			Swim(dict[val]);
		}
	}

    private void Swim(int i)
	{
		if (i == 0)
		{
			return;
		}

		Item cur = lst[i];

		int parent = Parent(i);

		if (cur.priority > lst[parent].priority)
		{
			Swap(i, parent);
			Swim(parent);
		}
	}

    private void Swap(int x, int y)
	{
		Item temp = lst[x];
		lst[x] = lst[y];
		lst[y] = temp;

        dict[lst[x].val] = x;
		dict[lst[y].val] = y;

	}

    private void Sink(int x)
	{
        int max = x;
		int left = Left(x);
		int right = Right(x);

		if (left < lst.Count && lst[left].priority > lst[max].priority)
		{
			max = left;
		}

		if (right < lst.Count && lst[right].priority > lst[max].priority)
		{
			max = right;
		}

		if (max != x)
		{
			Swap(x, max);
			Sink(max);
		}
	}   
}

public class HeapMapTest
{
	public static void Main(string[] args)
	{
		HeapMap<string> pq = new HeapMap<string>();
		pq.Enqueue("Bob", 5);
		pq.Enqueue("Rob", 10);
		pq.Enqueue("Mike", 6);
		pq.Enqueue("Tina", 3);
		pq.Enqueue("Andy", 2);
		pq.Enqueue("Judy", 9);

        pq.UpdatePriority("Tina", 10);
        pq.UpdatePriority("Rob",5);

		int ct = 6;
		while (ct > 0)
		{
			Console.WriteLine(pq.Dequeue());
			ct--;
		}		
        Console.WriteLine();
	}
}
