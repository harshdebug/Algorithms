using System;

public class MergeSort
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

        int mid = (left + right) / 2;
        this.Sort(arr, left, mid);
        this.Sort(arr, mid + 1, right);
        this.Merge(arr, left, mid, right);
    }

    public void Merge(int[] arr, int left, int mid, int right)
    {
        int[] temp = new int[right - left + 1];
        for (int i = left; i <= right; i++)
        {
            temp[i - left] = arr[i];
        }

        int l = left; int r = mid + 1; int k = left;
        while (l <= mid && r <= right)
        {
            if (temp[l - left] > temp[r - left])
            {
                arr[k++] = temp[r++ - left];
            }
            else
            {
                arr[k++] = temp[l++ - left];
            }
        }

        while (l <= mid)
        {
            arr[k++] = temp[l++ - left];
        }
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

        MergeSort s = new MergeSort();
        s.Sort(inp1);
        s.Sort(inp2);
        s.Sort(inp3);
        s.Sort(inp4);

        s.PrintArray(inp1);
        s.PrintArray(inp2);
        s.PrintArray(inp3);
        s.PrintArray(inp4);
    }
}