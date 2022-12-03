using System;

namespace WebApp.Labs;

// 4
public class Lab1
{
    public int C(int n, int k) //combinations formula
    {
        int p = 1;
        if (n == k)
        {
            return p;
        }
        else
        {
            for (int i = 1; i <= n - k; i++)
            {
                p *= (k + i) / i;
            }
            return p;
        }

    }
    public string Main(string text)
    {
        try
        {
            int n = Int32.Parse(text);
            Console.WriteLine("Number of products = {0}", text);
            if (n < 32)
            {
                int sum = 1;
                for (int i = 2; i < n; i++)
                {
                    sum += this.C(n, i); //sum of combinations
                }
                Console.WriteLine("Number of salads = {0}", sum);
                return Convert.ToString(sum);
            }
            else
            {
                Console.WriteLine("Number of products 'n' must be smaller than 32.");
                return "Number of products 'n' must be smaller than 32.";
            }

        }
        catch
        {
            Console.WriteLine("Oops, something went wrong.\nPlease, a check is the txt file available and data is in the correct format and try again.");
            return "Oops, something went wrong";
        }
    }
}

// 6
public class Lab2
{
   private int Counter(int number)
    {
        int sum = 0;
        if (1 <= number && number <= Int32.MaxValue)
        {
            if (number == 3)
            {
                sum = 1;
            }
            for (int i = 4; i < number; i++)
            {
                sum += (i % 2) + (i + 1) % 2;

            }
            return sum;
        }
        else
        {
            throw new ArgumentException("Number should be within 1 and 2147483647.");
        }
    }

    public string Main(string number)
    {
        try
        {
            int n = Int32.Parse(number);
            Console.WriteLine("Number is {0}", number);
            int numb = Counter(n);
            Console.WriteLine("Number of variants is {0}", numb);
            return Convert.ToString(numb);
        }
        catch (Exception ex)
        {
            throw new ArgumentOutOfRangeException("Oops, something went wrong.\n", ex);
        }
    }
}

// 5 0 1 0 0 1 1 0 1 0 0 0 1 0 0 0 0 0 0 0 0 1 0 0 0 0 3 5
public class Lab3
{
    public int[][] RectangularIntArray(int size1, int size2)
    {
        int[][] newArray = new int[size1][];
        for (int array1 = 0; array1 < size1; array1++)
        {
            newArray[array1] = new int[size2];
        }

        return newArray;
    }

    public string Main(string input)
    {
        int n;
        int i;
        int j;
        int k;
        int f;
        int s;
        string output = "";
        Queue<int> q = new Queue<int>();
        string[] inputArray = input.Split(" ");
        n = int.Parse(inputArray[0]);
        inputArray = inputArray.Skip(1).ToArray();
        int[,] tmpArray = new int[,] {
                                                                                                                                                                                                { 0, 1, 0, 0, 1 }, { 1, 0, 1, 0, 0 }, { 0, 1, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 1, 0, 0, 0, 0 }
        };
   
        int[][] a = RectangularIntArray(n, n);
        int[] d = new int[n];
        for (i = 0; i < n; ++i)
        {
            d[i] = 1000000000;
            for (j = 0; j < n; ++j)
            {
                a[i][j] = tmpArray[i, j];
                inputArray = inputArray.Skip(1).ToArray();
            }
        }
        s = int.Parse(inputArray[0]);
        f = int.Parse(inputArray[1]);
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
                if (a[i][j] != 0 && d[j] > d[i] + 1)
                {
                    d[j] = d[i] + 1;
                    q.Enqueue(j);
                }
            }
        }
        if (d[f] < 1000000000)
        {
            Console.Write(d[f]);
            output += d[f];
        }
        else
        {
            Console.Write(-1);
            output += "-1";
        }
        return output;

    }
}