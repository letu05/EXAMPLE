using System.Linq.Expressions;

public class Program
{
    public static void Main(string[] args)
    {
        // Khai báo và khởi tạo mảng 3 chiều kích thước 2x3x4
        int[,,] arr = new int[2, 3, 4];

        // Gán giá trị cho từng phần tử
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 4; k++)
                {
                    arr[i, j, k] = i + j + k;
                }
            }
        }

        // In ra các phần tử của mảng 3 chiều
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 4; k++)
                {
                    Console.WriteLine($"arr[{i},{j},{k}] = {arr[i, j, k]}");
                }
            }
        }
        string[,] myArray = { { "A", "B", "C" }, { "D", "E", "F" }, { "lamdong", "ho chi minh", "phu tho" } };
    Console.WriteLine(myArray[2, 0]); // In ra "lamdong"
    Console.WriteLine(myArray[0, 1]); // In ra "B"
    }
    
}