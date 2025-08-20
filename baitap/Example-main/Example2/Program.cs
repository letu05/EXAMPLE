//tinh dien tich hinh tron khi biet ban kinh

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Nhap ban kinh hinh tron");
        double r = Convert.ToDouble(Console.ReadLine());
        double S = MathF.PI * r * r;
        Console.WriteLine("Dien tich la" + S);
    }
}