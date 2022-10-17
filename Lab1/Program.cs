
namespace Lab1 
{

    internal class Program
    {
        public static int C(int n, int k) //combinations formula
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
        static void Main(string[] args)
        {
            try
            {
                string text = File.ReadAllText(Path.GetFullPath("INPUT.txt"));
                int n = Int32.Parse(text);
                Console.WriteLine("Number of products = {0}", text);
                if (n < 32)
                {
                    int sum = 1;
                    for (int i = 2; i < n; i++)
                    {
                        sum += C(n, i); //sum of combinations
                    }
                    Console.WriteLine("Number of salads = {0}", sum);
                    File.WriteAllText("OUTPUT.txt",Convert.ToString(sum));
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
    }
}


