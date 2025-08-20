using System;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        int rows = 4;
        int cols = 3;
        int[,] arr = new int[rows, cols];
        Random rnd = new Random();

        // Khởi tạo mảng với giá trị ngẫu nhiên
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                arr[i, j] = rnd.Next(0, 101);
            }
        }

        // Hiển thị mảng
        Console.WriteLine("Mảng số nguyên 4x3:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(arr[i, j] + "\t");
            }
            Console.WriteLine();
        }

        // Tính tổng các phần tử
        int sum = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                sum += arr[i, j];
            }
        }
        Console.WriteLine("Tổng các phần tử trong mảng: " + sum);
    }
}
