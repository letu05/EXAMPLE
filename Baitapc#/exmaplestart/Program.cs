using System.Data;

public class Program
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("*");
        Console.WriteLine("**");
        Console.WriteLine("***");
        Console.WriteLine("****");
        Console.WriteLine("*****");
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(j);
            }
            Console.WriteLine();
        }

    }
}