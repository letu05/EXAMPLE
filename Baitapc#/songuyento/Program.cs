public class Program
{
    public static void Main(string[] args)
    {
        int count = 0;
        int number = 2;
        while (count < 22)
        {
            if (IsValid(number))
            {
                count++;
                Console.WriteLine($"Prime number {count}: {number}");
            }
            number++;
        }

    }
    static bool IsValid(int s)
    {
        
        if (s < 2) return false;
        for (int i = 2; i <= Math.Sqrt(s); i++)
        {
            if (s % i == 0) return false;
        }
        return true;
    }
}