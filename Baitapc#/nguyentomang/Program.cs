public class Program
{
    public static void Main(string[] args)
    {
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        int sum = 0;
        for (int i = a; i <= b; i++)
        {
            if (IsValid(i))
            {
                Console.WriteLine(i);
                sum += i;
            }
        }
        Console.WriteLine("Sum = " + sum);
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