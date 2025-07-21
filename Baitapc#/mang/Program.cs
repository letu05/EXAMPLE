using System.ComponentModel.Design;

public class Program
{
    public static void Main(string[] args)
    {
        int [] myArray = {1, 2, 3, 4, 5};
        int [] myArray2 = new int[]{0,1,2,3,4,5};
        int n = Convert.ToInt32(Console.ReadLine());
        int[] myArray3 = new int[n];
        Console.WriteLine("Enter elements for myArray3:");
        for (int i = 0; i < n; i++)
        {
            myArray3[i] = Convert.ToInt32(Console.ReadLine());
        }
        Console.WriteLine("Elements of myArray:");
        //kiểu in 2
        foreach (var item in myArray)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Elements of myArray2:");
        //kiểu in 1
        for (int i = 0; i < myArray.Length; i++)
        {
            Console.WriteLine($"phần tử thứ {i + 1} là: {myArray[i]}");
        }
        Console.WriteLine("Hello, World!");
    }
}