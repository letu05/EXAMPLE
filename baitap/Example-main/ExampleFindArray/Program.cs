public class Program
{
    public static void Main(string[] args)
    {
        string[] student = { "Chrismas", "Michanel", "Camilia", "Sinena" };
        Console.WriteLine("Ban hay nhap vao mot cai ten");
        string inputname = Console.ReadLine();
        bool isExit = false;
        for (var i = 0; i < student.Length; i++)
        {
            if (student[i].Equals(inputname))
            {
                Console.WriteLine($"Co ten do trong mang co vi tri la {i}");
                isExit = true;
                break;
            }
        }
        if (!isExit)
        {
            Console.WriteLine("Khong tim thay te nhu vay");
        }
   } 
}