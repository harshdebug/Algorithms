using System;
using System.Collections.Generic;

class Puzzles
{
     // min coins to total if reachable otherwise -1
    int MinCoins(int[] coins, int total)
    {
        if(total <=0)
        {
            return -1;
        }

        int min = -1;
       
        for (int i = 0; i < coins.Length; i++)
        {
            if (coins[i] == total)
            {
                return 1;
            }
            else if(total > coins[i])
            {
                int curMin = 1 + MinCoins(coins, total - coins[i]);
                if (curMin != 0 )
                {
                    if(min == -1 || curMin < min)
                    {
                        min = curMin;
                    }
                }
            }
        }
        return min; 
    }

    //Input:
    //1. array of integers, such as {1, 2 ,3}
    //2. target integer, such as 5

    //Output:
    //get all combinations of array elements that add to the target, for example:
    //1+1+1+1+1 => 5
    //2 + 3 => 5; // 3 + 2 is regarded as duplicate
    //1 + 1 + 3 => 5

    // instance var to store all combinations
    List<List<int>> allCombinations = new List<List<int>>();


    void GetAllComb(int[] arr, int target)
    {
        Array.Sort(arr);
        List<int> lst = new List<int>();
        GetAllCombRec(arr, target, lst, 0);
    }

    void GetAllCombRec(int[] arr, int target, List<int> lst, int idx)
    {
        for (int i = idx; i < arr.Length; i++)
        {
            lst.Add(arr[i]);
            if(arr[i] == target)
            {
                List<int> result = new List<int>(lst);
                allCombinations.Add(result);
            }
            else if(arr[i] < target)
            {
                GetAllCombRec(arr, target - arr[i], lst, i);
            }
            lst.RemoveAt(lst.Count -1); //common mistake to use Remove instead of RemoveAt
        }
    }


    // Given a target and possible options minimize waste e.g: 180, [100,30,20] 
    // how would you minimize for 47, [100,30,20]
    public List<int> bestOption;
    public int waste = Int32.MaxValue;

    void GetBestOption(int[] arr, int target, List<int> lst)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            lst.Add(arr[i]);

            if(target == arr[i])
            {
                if((waste == 0 && bestOption.Count > lst.Count) || waste > 0)
                {
                    bestOption = new List<int>(lst);
                    waste = 0;
                }
            }
            else if(target < arr[i])
            {
                if (waste > (arr[i] - target))
				{
					bestOption = new List<int>(lst);
					waste = arr[i] - target;
				}
            }
            else 
            {
                GetBestOption(arr, target - arr[i], lst);
            }
            lst.RemoveAt(lst.Count -1);
        }
    }


	//  Trapped Water
	//  Input: arr[]   = {2, 0, 2}
	//  Output: 2
	//  Structure is like below
	//      | |
	//      |_|
	//  We can trap 2 units of water in the middle gap.
	//  Input: arr[]   = {3, 0, 0, 2, 0, 4}
	//  Output: 10
    int TrappedWater(int[] arr)
    {
        int[] maxLeft = new int[arr.Length];
        int[] maxRight = new int[arr.Length];

        maxLeft[0] = arr[0];
        maxRight[arr.Length - 1] = arr[arr.Length - 1];

        for (int i = 1; i < arr.Length; i++)
        {
            maxLeft[i] = Math.Max(maxLeft[i - 1], arr[i]);
        }
        for (int i = arr.Length - 2; i >= 0; i--)
        {
            maxRight[i] = Math.Max(arr[i], maxRight[i + 1]);
        }

        int total = 0;

        for (int i = 1; i < arr.Length - 1; i++)
        {
            total += Math.Min(maxLeft[i], maxRight[i]) - arr[i];
        }
        return total;
    }

	public static void Main(string[] args)
	{
		Puzzles mc = new Puzzles();

		int[] coins = { 2, 5, 10 };
		int m = mc.MinCoins(coins, 53);
		Console.WriteLine("MinCoins: " + m);

		int[] arr = { 1, 2, 3 };
		mc.GetAllComb(arr, 5);

		Console.Write("All Combinations to total");
        foreach (List<int> l in mc.allCombinations)
        {
            Console.WriteLine();
            foreach (int x in l)
            {
                Console.Write(x + " ");
            }
        }

		int[] ar2 = { 20, 30, 100 };
		List<int> lst = new List<int>();
		mc.GetBestOption(ar2, 47, lst);
		Console.WriteLine();
		Console.Write("Best Option: ");
		foreach (int i in mc.bestOption)
		{
			Console.Write(i + " ");
		}

		int[] arr3 = { 3, 0, 0, 2, 0, 4 };
		int tw = mc.TrappedWater(arr3);
		Console.WriteLine();
		Console.Write("Trapped Water = " + tw);
		int j = m;
	}

}

