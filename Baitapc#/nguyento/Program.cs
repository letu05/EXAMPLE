using System.Runtime.CompilerServices;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("hien thi so nguyen to");
        for (int i = 2; i < 100; i++)
        {
            if (isPrime(i))
            {
                Console.WriteLine("" + i);
            }
        }
        static bool isPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}