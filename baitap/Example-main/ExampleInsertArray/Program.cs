public class Program
{
    public static void Main(string[] args)
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        Console.WriteLine("Mang ban dau la");
        PrintArray(arr);
        //nhap phan tu can chen
        //nhap vi tri chen
        Console.WriteLine("Nhap so can chen");
        int number = Convert.ToInt32(Console.ReadLine());
        //
        Console.WriteLine("Nhap vi tri can chen");
        int position = Convert.ToInt32(Console.ReadLine());
        //
        if (position < 0 || position > arr.Length) return;
        int[] newArr = new int[arr.Length + 1];
        int i;
        int j;
        for (i = 0, j = 0; i < newArr.Length; i++)
        {
            if (i == position)
            {
                newArr[i] = number;
            }
            else
            {
                newArr[i] = arr[j];
                j++;
            }
        }
        PrintArray(newArr);
    }
    static void PrintArray(int[] arrays)
    {
        foreach (var item in arrays)
        {
            Console.WriteLine(item);
        }
    }
}