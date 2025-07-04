class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("nhập họ và tên");
        string hoten = Console.ReadLine();
        Console.WriteLine("nhập tuổi");
        int tuoi = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Ho va Ten {hoten} và tuổi là {tuoi}");
    }
}