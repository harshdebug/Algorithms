using System;
public class HeapSort
{
	int heapSize;
	int[] heap;	

	int Parent(int i)
	{
		return (i - 1) / 2;
	}

	int Left(int i)
	{
		return 2 * i + 1;
	}

	int Right(int i)
	{
		return 2 * i + 2;
	}

	// assume Left(i) & Right(i) are max heaps but i might be smaller
	void Sink(int i)
	{
		int largest = i;
		int left = Left(i);
		int right = Right(i);
		if (left < heapSize && heap[left] > heap[largest])
		{
			largest = left;
		}
		if (right < heapSize && heap[right] > heap[largest])
		{
			largest = right;
		}
		if (largest != i)
		{
			int temp = heap[i];
			heap[i] = heap[largest];
			heap[largest] = temp;
			this.Sink(largest);
		}
	}

	// using Sink in bottom up manner to build max heap
	void BuildMaxHeap()
	{
		int bottom = heap.Length - 1;
		for (int i = Parent(bottom); i >= 0; i--)
		{
			this.Sink(i);
		}
	}

    void Swap(int a, int b)
    {
        int temp = this.heap[a];
        heap[a] = heap[b];
        heap[b] = temp;
    }	

	void PrintArray(int[] arr)
	{
		for (int i = 0; i < arr.Length; i++)
		{
			Console.Write(arr[i] + " ");
		}

		Console.WriteLine();
	}

	public void Sort(int[] arr)
	{
		this.heap = arr;
		this.heapSize = arr.Length;
		this.BuildMaxHeap();
		for (int i = heap.Length - 1; i > 0; i--)
		{
			this.Swap(i, 0);
			this.heapSize = heapSize - 1;
			this.Sink(0);
		}
	}

	public static void Main()
	{
		int[] inp0 = new int[] { 3, 5, 1, 4, 2 };
		int[] inp1 = { 5 };
		int[] inp2 = { 5, 1 };
		int[] inp3 = { 5, 3, 7 };
		int[] inp4 = { 5, -2, 11, 3, 10, 12, 18, 21, 1, 6 };

		HeapSort s = new HeapSort();
        s.Sort(inp0);
        s.Sort(inp1);
        s.Sort(inp2);
        s.Sort(inp3);
        s.Sort(inp4);
        s.PrintArray(inp0);
        s.PrintArray(inp1);
        s.PrintArray(inp2);
        s.PrintArray(inp3);
        s.PrintArray(inp4);
	}
}