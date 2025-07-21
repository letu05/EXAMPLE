public class Program
{
    public static void Main(string[] args)
    {
        List<string> Mylist = new List<string>();
        Mylist.Add("Hello");
        Mylist.Add("World");
        Mylist.Add("Orange");
        Console.WriteLine("List before removal:");
        foreach (var item in Mylist)
        {
            Console.WriteLine(item);
        }
        Mylist.Remove("Hello");
        Console.WriteLine("List after removal:");
        foreach (var item in Mylist)
        {
            Console.WriteLine(item);
        }
    }
}