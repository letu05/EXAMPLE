

public class Program
{
    public static void Main(string[] args)
    {
        int rows = 4;
        int cols = 3;
        int[,] arr = new int[rows, cols];
        Random rand = new Random();
        int sum = 0;

        // Gán giá trị ngẫu nhiên cho mảng và tính tổng
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                arr[i, j] = rand.Next(0, 101); // Số ngẫu nhiên từ 0 đến 100
                sum += arr[i, j];
            }
        }

        // Hiển thị mảng ra màn hình
        Console.WriteLine("Mảng số nguyên 4x3:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(arr[i, j] + "\t");
            }
            Console.WriteLine();
        }

        // Hiển thị tổng của mảng
        Console.WriteLine("Tổng các phần tử trong mảng: " + sum);
    }
}
