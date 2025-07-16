public class Program
{
    public static void Main(string[] args)
    {
        float with;
        float height;
        Console.WriteLine("Nhap gia tri chieu rong");
        with = Convert.ToInt32(Console.ReadLine());
        height = Convert.ToInt32(Console.ReadLine());
        float arena = with * height;
        Console.WriteLine($"Gia tri dien tich la {with} {height} = {arena}");
    }
}