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
        // JsonSerializerOptions ładnie formatuje kod w pliku JSON
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };

        byte[] jsonUtf8Bytes;
        jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(person, options);
        person.LastName = "oko";

        

        if (!File.Exists(path))
        {
            File.WriteAllBytes(path, jsonUtf8Bytes);
            Console.WriteLine("Zapisano bajty");
        }
        else 
        {
            File.WriteAllBytes(path, jsonUtf8Bytes);
            Console.WriteLine("Nadpisano bajty");
        }

        var jsonBytes = File.ReadAllBytes(path);
        var personX = JsonSerializer.Deserialize<People>(jsonBytes);

        Console.WriteLine($"Obiekt z pliku JSON:\n\tName:\t\t{personX.Name}\n\tLast Name:\t{personX.LastName}\n\tAge:\t\t{personX.Age}");

        // string jsonString = JsonSerializer.Serialize(person, options);
        // if (!File.Exists($"{folder}{person.Name}{person.LastName}.json"))
        // {
        //     File.WriteAllText(path, jsonString);
        //     Console.WriteLine("Utworzono json.");
        // }
        // else
        // {
        //     Console.WriteLine("Czy nadpisać plik?");
        //     string input = "y";
        //     if (input == "y")
        //     {
        //         File.WriteAllText(path, jsonString);
        //         Console.WriteLine("Nadpisano plik.");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Nie nadpisano pliku");
        //     }
        // }
    }

    public void ReadJsonFile(byte[] jsonUtf8Bytes)
    {
        var readOnlySpan = new ReadOnlySpan<byte>(jsonUtf8Bytes);
        var person1 = JsonSerializer.Deserialize<People>(readOnlySpan);
        Console.WriteLine(person1.LastName);
        var utf8Reader = new Utf8JsonReader(jsonUtf8Bytes);
        var person2 = JsonSerializer.Deserialize<People>(ref utf8Reader);
        Console.WriteLine(person2.LastName);
    }
}