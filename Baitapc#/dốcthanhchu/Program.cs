public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Nhập số bạn cần biến đổi thành chữ:  ");
        int x = Convert.ToInt32(Console.ReadLine());
        if (x >= 0 && x < 10)
        {
            switch (x)
            {
                case 0:
                    Console.WriteLine("khong");
                    break;
                case 1:
                    Console.WriteLine("mot");
                    break;
                case 2:
                    Console.WriteLine("hai");
                    break;
                case 3:
                    Console.WriteLine("ba");
                    break;
                case 4:
                    Console.WriteLine("bon");
                    break;
                case 5:
                    Console.WriteLine("nam");
                    break;
                case 6:
                    Console.WriteLine("sau");
                    break;
                case 7:
                    Console.WriteLine("bay");
                    break;
                case 8:
                    Console.WriteLine("tam");
                    break;
                case 9:
                    Console.WriteLine("chin");
                    break;
                default:
                    break;
            }
        }
        else if (x >= 20 && x < 99)
        {
            int a = x / 10;
            int b = x % 10;
            switch (a)
            {
                case 2:
                    Console.Write("hai ");
                    break;
                case 3:
                    Console.Write("ba ");
                    break;
                case 4:
                    Console.Write("bon ");
                    break;
                case 5:
                    Console.Write("nam ");
                    break;
                case 6:
                    Console.Write("sau ");
                    break;
                case 7:
                    Console.Write("bay ");
                    break;
                case 8:
                    Console.Write("tam ");
                    break;
                case 9:
                    Console.Write("chin ");
                    break;
                default:
                    break;
            }
            switch (b)
            {
                case 0:
                    Console.WriteLine("muoi");
                    break;
                case 1:
                    Console.WriteLine("mot");
                    break;
                case 2:
                    Console.WriteLine("hai");
                    break;
                case 3:
                    Console.WriteLine("ba");
                    break;
                case 4:
                    Console.WriteLine("bon");
                    break;
                case 5:
                    Console.WriteLine("nam");
                    break;
                case 6:
                    Console.WriteLine("sau");
                    break;
                case 7:
                    Console.WriteLine("bay");
                    break;
                case 8:
                    Console.WriteLine("tam");
                    break;
                case 9:
                    Console.WriteLine("chin");
                    break;
                default:
                    break;
            }
            
        }

    }
}
