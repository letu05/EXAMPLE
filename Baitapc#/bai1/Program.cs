class Program
{
    public static void Main(string[] args)


    {
        int a = 10;
        a += 10;
        Console.WriteLine("" + a);
        DateTime dateTime = new DateTime();
        Console.WriteLine($"{dateTime.Hour} {dateTime.Minute} {dateTime.Second}");
    }
}