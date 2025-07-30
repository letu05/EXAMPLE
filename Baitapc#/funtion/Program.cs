public class Program
{
    public static void Main(string[] args)
    {
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        int max = Max(a, b);
        Console.WriteLine(max);
    }
    public static int Max(int a, int b)
    {
        return a > b ? a : b;
    }
}