//in so nguyen to trong 1 khoang xac dinh
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Nhap so a");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Nhap so b");
        int b = Convert.ToInt32(Console.ReadLine());
        int count=0;
        for (var i = a; i <= b; i++)
        {
            if(IsPrime(i))
            {
                Console.WriteLine($"{i}");
                count+=1;
            }
        }
        Console.WriteLine($"So Nguyen to gom {count} so");
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