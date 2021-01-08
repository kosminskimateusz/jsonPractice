using System;

namespace JsonPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonManager manager = new JsonManager();
            manager.AddOverrideJsonFile("Mateusz", "Kosminski", 29);
        }
    }
}
