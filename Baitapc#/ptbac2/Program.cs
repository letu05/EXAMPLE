class Program
{
    public static void Main(string[] args)
    {
        double a, b, c;
        Console.WriteLine("Nha gia tri a");
        a = Convert.ToDouble(Console.ReadLine());
        b = Convert.ToDouble(Console.ReadLine());
        c = Convert.ToDouble(Console.ReadLine());
        if (a == 0)
        {
            if (b == 0)
            {
                if (c == 0)
                {
                    Console.WriteLine("Phuong trinh vo so nghiem");
                }
                else
                {
                    Console.WriteLine("Phuong trinh vo nghiem");
                }
            }
            else
            {
                double x = -b / c;
                Console.WriteLine("Phuong trinh co 1 nghiem" + x);

            }
        }
        else
        {
            double d = b * b - 4 * a * c;
            if (d > 0)
            {
                double y = (-b + Math.Sqrt(d)) / 2 * a;
                Console.WriteLine("Phuong trinh co 2 nghiem" + y);
            }
            else if (d == 0)
            {
                double z = -b / 2 * a;
                Console.WriteLine("Phuong trinh co nghiem kep" + z);
            }
            else
            {
                Console.WriteLine("phuonmg trinh vo nghiem");
            }
        }
        
    }
}