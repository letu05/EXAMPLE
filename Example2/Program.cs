
// tính dien tich hinh tron
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Nhập bán kính hình tròn");
        double r = Convert.ToDouble(Console.ReadLine());
        double s = r * r * Math.PI;
        Console.WriteLine("Dien tich la " + s);

    }
}