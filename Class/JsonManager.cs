using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

class JsonManager
{
    private string folder = @".\json\";
    public void AddOverrideJsonFile(string name, string lastName, int age)
    {
        People person = new People(name, lastName, age);
        string path = folder + person.Name.ToLower() + person.LastName + ".json";
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };
        string jsonString = JsonSerializer.Serialize(person, options);
        if (!File.Exists($"{folder}{person.Name}{person.LastName}.json"))
        {
            File.WriteAllText(path, jsonString);
            Console.WriteLine("Utworzono json.");
        }
        else
        {
            Console.WriteLine("Czy nadpisać plik?");
            string input = "y";
            if (input == "y")
            {
                File.WriteAllText(path, jsonString);
                Console.WriteLine("Nadpisano plik.");
            }
            else
            {
                Console.WriteLine("Nie nadpisano pliku");
            }
        }
    }
}