using System;

namespace DotNetTool.Labs;

public class Lab1
{

    private readonly string inputFile = "INPUT.txt";
    private readonly string outputFile = "OUTPUT.txt";

    public Lab1(string inputFileName, string outputFileName)
    {
        this.inputFile = inputFileName;
        this.outputFile = outputFileName;
    }
    public Lab1() { }

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
    public void Main()
    {
        try
        {
            prepareFile();
            string text = File.ReadAllText(Path.GetFullPath(inputFile));
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
                File.WriteAllText(outputFile, Convert.ToString(sum));
            }
            else
            {
                Console.WriteLine("Number of products 'n' must be smaller than 32.");
            }

        }
        catch
        {
            Console.WriteLine("Oops, something went wrong.\nPlease, a check is the txt file available and data is in the correct format and try again.");
        }
    }
    private void prepareFile()
    {
        string[] lines =
        {
            "4"
        };
        File.WriteAllLines(inputFile, lines);
    }
}

public class Lab2
{
    private readonly string inputFile = "INPUT.txt";
    private readonly string outputFile = "OUTPUT.txt";

    public Lab2(string inputFileName, string outputFileName)
    {
        this.inputFile = inputFileName;
        this.outputFile = outputFileName;
    }
    public Lab2() { }

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

    public void Main()
    {
        prepareFile();
        try
        {
            string number = File.ReadAllText(Path.GetFullPath(inputFile));
            int n = Int32.Parse(number);
            Console.WriteLine("Number is {0}", number);
            int numb = Counter(n);
            Console.WriteLine("Number of variants is {0}", numb);
            File.WriteAllText(outputFile, Convert.ToString(numb));
        }
        catch (Exception ex)
        {
            throw new ArgumentOutOfRangeException("Oops, something went wrong.\n", ex);
        }
    }

    private void prepareFile()
    {
        string[] lines =
        {
            "6"
        };
        File.WriteAllLines(inputFile, lines);
    }
}

public class Lab3
{
    private readonly string inputFile = "INPUT.txt";
    private readonly string outputFile = "OUTPUT.txt";

    public Lab3(string inputFileName, string outputFileName)
    {
        this.inputFile = inputFileName;
        this.outputFile = outputFileName;
    }
    public Lab3() { }


    public class RectangularArrays
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

    public int[][] Selector(string file)
    {
        return File.ReadAllText(Path.GetFullPath(file)).Split(Array.Empty<string>(), StringSplitOptions.RemoveEmptyEntries).Select((s, i) => new { N = int.Parse(s), I = i }).GroupBy(at => at.I / 5, at => at.N, (k, g) => g.ToArray()).ToArray();
    }

    public int[][] LastLine(string file)
    {
        return File.ReadLines(file).Last().Split(Array.Empty<string>(), StringSplitOptions.RemoveEmptyEntries).Select((s, i) => new { N = int.Parse(s), I = i }).GroupBy(at => at.I / 5, at => at.N, (k, g) => g.ToArray()).ToArray();
    }

    public void Remover(string fileIn, string fileOut, int line)
    {
        var linesList = File.ReadAllLines(Path.GetFullPath(fileIn)).ToList();
        linesList.RemoveAt(line);
        File.WriteAllLines(fileOut, linesList.ToArray());
    }

    public void Processing(int n, int[][] lastLine, Queue<int> q)
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

        matrix = Selector(inputFile);


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
            File.WriteAllText(outputFile, Convert.ToString(d[f]));
            Console.Write("Output data: {0}", d[f]);
        }
        else
        {
            File.WriteAllText("OUTPUT.txt", Convert.ToString(-1));
            Console.Write("Output data: {0}", -1);
        }
    }

    public void Main()
    {
        try
        {
            Queue<int> q = new Queue<int>();
            prepareFile();

            string matrixInput = File.ReadAllText(Path.GetFullPath(inputFile));
            Console.WriteLine("Input data: \n{0}", matrixInput);

            string number = File.ReadLines(Path.GetFullPath(inputFile)).First();
            int n = Int32.Parse(number);

            Remover(inputFile, inputFile, 0);

            var lastLine = LastLine(inputFile);

            Remover(inputFile, inputFile, (File.ReadAllLines(inputFile).ToList()).Count() - 1);

            Processing(n, lastLine, q);
            prepareFile();
        }
        catch (Exception ex)
        {
            throw new ArgumentOutOfRangeException("Oops, something went wrong.\n", ex);
        }
    }

    private void prepareFile()
    {
        string[] lines =
        {
            "5 \n0 1 0 0 1 \n1 0 1 0 0 \n0 1 0 0 0 \n0 0 0 0 0 \n1 0 0 0 0 \n3 5"
        };
        File.WriteAllLines(inputFile, lines);
    }

}

