public class Program
{
    public static void Main(string[] args)
    {
        int sum = 0;
        int[] myarray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        for (int i = 0; i < myarray.Length; i++)
        {
            sum += myarray[i];
        }
        Console.WriteLine("The sum of the array elements is: " + sum);
    }
}