public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter integers one:");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter integers two:");
        int b = Convert.ToInt32(Console.ReadLine());
        PrintMax(a, b);
    }
    public static int Max( int a, int b)
    {
        return a > b ? a : b;
    }
    public static void PrintMax(int a, int b)
    {
        Console.WriteLine($"The maximum of {a} and {b} is: {Max(a, b)}");
    }
}