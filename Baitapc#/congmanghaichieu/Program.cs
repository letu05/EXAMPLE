public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Nhap so phan tu cua mang: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[,] arr = new int[n, n];
        Console.WriteLine("Nhap cac phan tu cua mang: ");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"arr[{i},{j}] = ");
                arr[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        Console.WriteLine("Ma tran vua nhap la: ");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(arr[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Tong cac phan tu tren duong cheo chinh la: ");
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += arr[i, i];
        }
        Console.WriteLine(sum);
    }
    
}