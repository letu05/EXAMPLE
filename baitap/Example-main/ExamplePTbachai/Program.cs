    //axx+bx+c=0;
class Program
{
    public static void Main(string[] args)
    {
        Double a,b,c;
        Console.WriteLine("Nhap gia tri a");
        a = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Nhap gia tri b");
        b = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Nhap gia tri c");
        c = Convert.ToDouble(Console.ReadLine());
        if(a==0)
        {
            if(b==0)
            {
              if(c==0)
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
               Double x = -c/b;
               Console.WriteLine($"Phuong trinh co nghiem {x}");
            }
        }
        else
        {
            Double delta = (b*b-4*a*c);
            if(delta>0)
            {
               Double x1 = (-b +Math.Sqrt(delta)/2*a);
               Double x2 = (-b - Math.Sqrt(delta)/2*a);
               Console.WriteLine("Phuong trinh co 2 nghiem phan biet");
               Console.WriteLine($"X1 = {x1}");
               Console.WriteLine($"X2 = {x2}");
            }
            else if(delta==0)
            {
               Double x = -b/(2*a);
               Console.WriteLine($"Phuong trinh cos 2 nghiem  kep {x}")
            }
            else
            {
                Console.WriteLine("Phuong trinh vo nghiem");
            }
        }
    }
    
}