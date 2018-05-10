using System;
public class MathPuzzles
{
	public double MathPow(double x, int n)
	{
		if (n == 0)
		{
			return 1.0;
		}

		if (n < 0)
		{
			x = 1 / x;
			n = -1 * n;
		}

		double half = MathPow(x, n / 2);

		if (n % 2 == 0)
		{
			return half * half;
		}
		else
		{
			return half * half * x;
		}
	}

	public static void Main(string[] args)
	{
		MathPuzzles mc = new MathPuzzles();
		double ansRec;
		double ansItr;
        if (args.Length == 0)
		{
			ansRec = mc.MathPow(0.86429, 18);
			ansItr = mc.MathPowItr(0.86429, 18);
		}
		else
		{
			ansRec = mc.MathPow(Double.Parse(args[0]), Int32.Parse(args[1]));
			ansItr = mc.MathPowItr(Double.Parse(args[0]), Int32.Parse(args[1]));
		}
		Console.WriteLine(ansRec);
		Console.WriteLine(ansItr);
	}

	public double MathPowItr(double x, int n)
	{
		if (n == 0)
		{
			return 1.0;
		}

		long N = n;
		if (N < 0)
		{
			x = 1 / x;
			N = -1 * N;
		}

		double ans = 1;
		double cur = x;

		for (long i = N; i > 0; i /= 2)
		{
			if (i % 2 == 1)
			{
				ans = ans * cur;
			}
			cur = cur * cur;
		}

		return ans;
	}

}