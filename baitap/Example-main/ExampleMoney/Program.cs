public class Program
{
    public static void Main(string[] args)
    {
     double money =1;
     double month=1;
     double interset_rate=1.0;
     Console.WriteLine("Nhap gia tri money");
     money = Convert.ToDouble(Console.ReadLine());    

     Console.WriteLine("Nhap gia tri thang");
     month = Convert.ToDouble(Console.ReadLine());    

     Console.WriteLine("Nhap gia tri ty gia");
     interset_rate = Convert.ToDouble(Console.ReadLine());    
     double total_interset=0;
     for (var i = 0; i < month; i++)
     {
        total_interset = money*(interset_rate/100)/12*3;
     }
     Console.WriteLine(total_interset);  
    }
}
