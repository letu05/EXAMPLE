class Program
{
    public static void Main(string[] args)
    {
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        if (a == 0)
        {
            if (b == 0)
            {
                Console.WriteLine("Phuong trinh vo so nghiem");
            }
            else
            {
                Console.WriteLine("phuong trinh vo nghiem");
            }
        }
        else
        {
            int x = -b / a;
            Console.WriteLine("Phuong trinh co nghiem" + x);
        }
    }
}
