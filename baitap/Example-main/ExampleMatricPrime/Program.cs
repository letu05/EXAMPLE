public class Program
{
     static void Main(string[] args)
    {
        int[,] a = {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 11, 12, 13, 14, 15 }
        };
        Console.WriteLine("Array elements:");
        for (var i = 0; i < a.GetLength(0); i++)
        {
            for (var j = 0; j < a.GetLength(1); j++)
            {
                Console.WriteLine($"Element at ({i}, {j}): {a[i, j]}");
            }
        }
        Console.WriteLine("Prime elements in the array:");
        for (var i = 0; i < a.GetLength(0); i++)
        {
            for (var j = 0; j < a.GetLength(1); j++)
            {
                if (isPrime(a[i, j]))
                {
                    Console.WriteLine($"Element at ({i}, {j}) is prime: {a[i, j]}");
                }
            }
        }
    }
   static bool  isPrime(int n)
    {
        if (n <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0) return false;
        }
        return true;
    }
}