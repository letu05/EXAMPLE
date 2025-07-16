public class Program
{
    public static void Main(string[] args)
    {
        int[] myArray = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        foreach (var item in myArray)
        {
            Console.WriteLine(item);
        }
        int i = 0;
        while (i < 10)
        {
            Console.WriteLine(i);
            i += 1;
        }
    }
}