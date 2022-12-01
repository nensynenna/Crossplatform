using System;
using System.Collections.Generic;

namespace Lab3
{
	internal class Program
	{
		internal static class RectangularArrays
		{
			public static int[][] RectangularIntArray(int size1, int size2)
			{
				int[][] newArray = new int[size1][];
				for (int array1 = 0; array1 < size1; array1++)
				{
					newArray[array1] = new int[size2];
				}

				return newArray;
			}
		}
		public static int[][] Selector(string file)
		{
			return File.ReadAllText(Path.GetFullPath(file)).Split(Array.Empty<string>(), StringSplitOptions.RemoveEmptyEntries).Select((s, i) => new { N = int.Parse(s), I = i }).GroupBy(at => at.I / 5, at => at.N, (k, g) => g.ToArray()).ToArray();

		}
		public static int[][] LastLine(string file)
		{
			return File.ReadLines(file).Last().Split(Array.Empty<string>(), StringSplitOptions.RemoveEmptyEntries).Select((s, i) => new { N = int.Parse(s), I = i }).GroupBy(at => at.I / 5, at => at.N, (k, g) => g.ToArray()).ToArray();

		}
		public static void Remover(string fileIn, string fileOut, int line)
		{
			var linesList = File.ReadAllLines(Path.GetFullPath(fileIn)).ToList();
			linesList.RemoveAt(line);
			File.WriteAllLines(fileOut, linesList.ToArray());
		}
		public static void Processing(int n, int[][] lastLine, Queue<int> q)
		{
			int i;
			int j;
			int s;
			int f;
			int[][] matrix = RectangularArrays.RectangularIntArray(n, n);
			int[] d = new int[n];
			for (i = 0; i < n; i++)
			{
				d[i] = 1000000000;
			}

			matrix = Selector("INPUT.txt");


			s = lastLine[0][0];
			f = lastLine[0][1];
			s--;
			f--;
			d[s] = 0;
			q.Enqueue(s);
			while (q.Count > 0)
			{
				i = q.Peek();
				q.Dequeue();
				for (j = 0; j < n; ++j)
				{
					if (matrix[i][j] != 0 && d[j] > d[i] + 1)
					{
						d[j] = d[i] + 1;
						q.Enqueue(j);
					}
				}
			}
			if (d[f] < 1000000000)
			{
				File.WriteAllText("OUTPUT.txt", Convert.ToString(d[f]));
				Console.Write("Output data: {0}", d[f]);
			}
			else
			{
				File.WriteAllText("OUTPUT.txt", Convert.ToString(-1));
				Console.Write("Output data: {0}", -1);
			}
		}
		static void Main(string[] args)
		{

			Queue<int> q = new Queue<int>();

			File.WriteAllText("INPUT.txt", Convert.ToString("5 \n0 1 0 0 1 \n1 0 1 0 0 \n0 1 0 0 0 \n0 0 0 0 0 \n1 0 0 0 0 \n3 5"));

			string matrixInput = File.ReadAllText(Path.GetFullPath("INPUT.txt"));
			Console.WriteLine("Input data: \n{0}", matrixInput);

			string number = File.ReadLines(Path.GetFullPath("INPUT.txt")).First();
			int n = Int32.Parse(number);

			Remover("INPUT.txt", "INPUT.txt", 0);

			var lastLine = LastLine("INPUT.txt");

			Remover("INPUT.txt", "INPUT.txt", (File.ReadAllLines("INPUT.txt").ToList()).Count() - 1);

			Processing(n, lastLine, q);

			File.WriteAllText("INPUT.txt", Convert.ToString("5 \n0 1 0 0 1 \n1 0 1 0 0 \n0 1 0 0 0 \n0 0 0 0 0 \n1 0 0 0 0 \n3 5"));
		}
	}
}