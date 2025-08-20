public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Nhap tuoi cua ban");
        int age = Convert.ToInt32(Console.ReadLine());
        bool bigAge = age >= 18;
        Console.WriteLine($"Ban da du tuoi ket hon chua{bigAge}");
    }
}
