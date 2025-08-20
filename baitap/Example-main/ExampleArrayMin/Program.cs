public class Program
{
    public static void Main(string[] args)
    {
        int[] myarray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int min = myarray[0];
        for (int i = 0; i < myarray.Length; i++)
        {
            if (myarray[i] < min)
            {
                min = myarray[i];
            }
        } 
        Console.WriteLine($"Gia tri nho nhat la{min}");
    }
}