public class Program
{
    public static void Main(string[] args)
    {
        List<string> names = new List<string> { "Alice", "Bob", "Charlie", "Diana", "Apple", "Tom" };
        Console.WriteLine("nhap vao 1 ten :");
        string inputName = Console.ReadLine();
        bool isExist = false;
        for (var i = 0; i < names.Count; i++)
        {
            if (names[i].Equals(inputName))
            {
                Console.WriteLine("Ten {0} da ton tai trong danh sach" + i + inputName);
                isExist = true;
                break;
            }
        }
        if (!isExist)
        {
            Console.WriteLine("Ten {0} khong ton tai trong danh sach", inputName);
        }
    }
}