using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        string filePath = "B:\\filePath";
        DirectoryInfo dirInfo = Directory.CreateDirectory(filePath);
        // DirectoryInfo.Create() is not valid, removed.
        // You can use dirInfo for further operations if needed.
    }
}