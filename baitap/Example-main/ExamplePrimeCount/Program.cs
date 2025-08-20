public class Program
{
    public static void Main(string[] args)
    {
        int count = 0;
        int number = 2;
        while (count < 20)
        {
            if (IsPrime(number))
            {
                Console.WriteLine($"{number}");
                count++;
            }
            number++;   
        }
    }
    static bool IsPrime(int n)
    {
        if (n < 2) return false;
        for (var i = 2; i < Math.Sqrt(n); i++)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }
}