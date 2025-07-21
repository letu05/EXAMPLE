using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hay nhap vao mot so");
        int choice = 1;
        while (choice != 0)
        {
            choice = Convert.ToInt32(Console.ReadLine()); // Moved outside switch
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Ban da chon lua chon 1");
                    break;
                case 2:
                    Console.WriteLine("Ban da chon lua chon 2");
                    break;
                case 3:
                    Console.WriteLine("Ban da chon lua chon 3");
                    break;
                case 4:
                    Console.WriteLine("Ban da chon lua chon 4");
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le, vui long nhap lai");
                    break;
            }
        }
    }
}