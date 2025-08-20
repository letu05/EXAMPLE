
    public class Program
    {
    public static void Main(string[] args)
    {
        Console.WriteLine("Hay nhap vao mot so");
        int choice = -1;
        while (choice != 0)
        {
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("*");
                    Console.WriteLine("**");
                    Console.WriteLine("****");
                    Console.WriteLine("*****");
                    Console.WriteLine("******");
                    break;
                case 2:
                    Console.WriteLine("******");
                    Console.WriteLine("******");
                    Console.WriteLine("******");
                    Console.WriteLine("******");
                    break;
                case 3:
                    Console.WriteLine("******");
                    Console.WriteLine("******");
                    Console.WriteLine("******");
                    Console.WriteLine("******");
                    Console.WriteLine("******");
                    Console.WriteLine("******");
                    Console.WriteLine("******");
                    Console.WriteLine("******");
                    Console.WriteLine("******");
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Nhap lai");
                    break;
            }            
        }    
            
    }
    }
