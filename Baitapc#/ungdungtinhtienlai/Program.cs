public class Program
{
    public static void Main(string[] args)
    {
        double money = Convert.ToDouble(Console.ReadLine());
        double month = Convert.ToDouble(Console.ReadLine());
        double interset_rate = Convert.ToDouble(Console.ReadLine());
        double total_interset = 0;
        for (var i = 0; i < month; i++)
        {
            total_interset = money * (interset_rate / 100) / 12 * 3;

        }
        Console.WriteLine(""+total_interset);
    }
}