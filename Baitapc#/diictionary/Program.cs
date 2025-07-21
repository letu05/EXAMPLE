using System.IO.Compression;

namespace client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Initialize the client application
            Dictionary<string, string> config = new Dictionary<string, string>();
            config.Add("key1", "book");
            config.Add("key2", "pen");
            config.Add("key3", "notebook");
            config.Add("key4", "eraser");
            //
            foreach (var item in config.Keys)
            {
                Console.WriteLine(item);
            }
            foreach (var item in config.Values)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(config["key1"]);
        }
    }
}