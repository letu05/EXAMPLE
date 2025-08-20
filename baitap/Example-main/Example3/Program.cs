class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(" nhap ho va ten");
        string hoten = Console.ReadLine();
        Console.WriteLine("Nhap tuo");
        int tuoi = Convert.ToInt32(Console.ReadLine());
        //
        Console.WriteLine($"Ho va ten{hoten} va tuoi la {tuoi}");
    }
}