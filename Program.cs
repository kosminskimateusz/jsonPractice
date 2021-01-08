using System;

namespace JsonPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonManager manager = new JsonManager();
            manager.AddOverrideJsonFile("Mateusz", "Kośmiński", 29);
            manager.AddOverrideJsonFile("Mariusz", "Kat", 29);
            manager.AddOverrideJsonFile("Monika", "Kokolino", 29);
            manager.AddOverrideJsonFile("Seba", "Porter", 29);
            manager.AddOverrideJsonFile("Michał", "Szpak", 29);
            manager.AddOverrideJsonFile("Mietek", "Trep", 29);
        }
    }
}
