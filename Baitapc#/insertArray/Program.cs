public class Program
{
    public static void Main(string[] args)
    {
        int[] mang = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Console.WriteLine("Original array:");
        PrintArray(mang);
        // nhap phan tu caN CHEN
        // NHAP SO CAN CHEN
        Console.Write("Nhap so can chen: ");
        int x = Convert.ToInt32(Console.ReadLine());
        // nhap vi tri can chen
        Console.Write("Nhap vi tri can chen: ");
        int position = Convert.ToInt32(Console.ReadLine());
        // Kiem tra vi tri
        if (position < 0 || position > mang.Length)
        {
            Console.WriteLine("Vi tri chen khong hop le.");
            return;
        }
        // Tao mang moi co kich thuoc lon hon
        int[] newMang = new int[mang.Length + 1];
        for (int i = 0, j = 0; i < newMang.Length; i++)
        {
            if (i == position)
            {
                newMang[i] = x; // Chen phan tu moi vao vi tri
            }
            else
            {
                newMang[i] = mang[j]; // Sao chep phan tu cu
                j++;
            }
        }
        Console.WriteLine("Mang sau khi chen:");
        PrintArray(newMang);
        

    }
    static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}