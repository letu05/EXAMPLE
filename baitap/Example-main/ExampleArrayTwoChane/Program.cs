public class Program
{
    public static void Main(string[] args)
    {
        string[,] nyarray ={{"Ha Noi","HCM","Thai Nguyen"},
                            {"Cao Bang","Bac Can","Hon Gai" },
                            {"Lam Dong","An Giang","Vung tau" }};
        Console.WriteLine("Array Length: " + nyarray.GetLength(0));
        Console.WriteLine("Array Length: " + nyarray.GetLength(1));

    }
}
