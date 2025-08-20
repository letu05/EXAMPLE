public class Program
{
    public static void Main(string[] args)
    {
        int[,] arr = new int[4, 4]
        {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 },
            { 13, 14, 15, 16 }
        };

        int sumDiagonal = 0;
        for (int i = 0; i < 4; i++)
        {
            sumDiagonal += arr[i, i];
        }

        Console.WriteLine("Tổng đường chéo chính là: " + sumDiagonal);
    }
}
