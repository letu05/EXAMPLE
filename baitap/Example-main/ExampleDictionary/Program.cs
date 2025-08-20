
namespace Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("Key1", "Book");
            dictionary.Add("key2", "Phone");
            dictionary.Add("Key3", "Tivi");
            dictionary.Add("Key4", "Radio");
            //
            foreach (var item in dictionary.Keys)
            {
                Console.WriteLine(item);
            }
            //
            foreach (var item in dictionary.Values)
            {
                Console.WriteLine(item);
            }
            //
            Console.WriteLine(dictionary["Key1"]);
        }
    }
}