class Program
{
    public static void Main(string[] args)
    {
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        int c = Convert.ToInt32(Console.ReadLine());
        if (a > 0 && b > 0 && c > 0)
        {
            if (a + b > c && b + c > a && c + b > a)
            {
                Console.WriteLine("La hinh tam giac");
            }
            else
            {
                Console.WriteLine("");
            }
        }
        else
        {
            Console.WriteLine();

            
        }
    }
}
