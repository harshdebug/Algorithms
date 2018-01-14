using System;
// First try
public class QuickSort
{
	public void Sort(int[] arr)
	{
		this.Sort(arr, 0, arr.Length - 1);
	}

	public void Sort(int[] arr, int left, int right)
	{
		if (left >= right)
		{
			return;
		}

		int pivot = arr[right];
		int pivotPos = left;
		for (int i = left; i < right; i++)
		{
			if (arr[i] < pivot)
			{
				this.Swap(arr, i, pivotPos++);
			}
		}

		this.Swap(arr, right, pivotPos);
		this.Sort(arr, left, pivotPos - 1);
		this.Sort(arr, pivotPos + 1, right);
	}

	public void Swap(int[] arr, int x, int y)
	{
		int temp = arr[x];
		arr[x] = arr[y];
		arr[y] = temp;
	}

	public void PrintArray(int[] arr)
	{
		for (int i = 0; i < arr.Length; i++)
		{
			Console.Write(arr[i] + " ");
		}

		Console.WriteLine();
	}

	public static void Main()
	{
		int[] inp1 = { 5 };
		int[] inp2 = { 5, 1 };
		int[] inp3 = { 5, 3, 7 };
		int[] inp4 = { 5, -2, 11, 3, 10, 12, 18, 21, 1, 6 };

		QuickSort qs = new QuickSort();
		qs.Sort(inp1);
		qs.Sort(inp2);
		qs.Sort(inp3);
		qs.Sort(inp4);

		qs.PrintArray(inp1);
		qs.PrintArray(inp2);
		qs.PrintArray(inp3);
		qs.PrintArray(inp4);
	}

}
