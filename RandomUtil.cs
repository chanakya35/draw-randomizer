using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class RandomUtil
{
    public static void Main(string[] args)
    {
        // TODO: check if filename provided
        var names = ReadFile(""); //TODO: args[0]
        // TODO: check if names is even
        var draws = GeneratePairs(names, new List<Tuple<string, string>>());
    }

    private static List<Tuple<string,string>> GeneratePairs(List<string> names, List<Tuple<string,string>> current)
    {
        var random = new Random();
        var firstName = ExtractRandomName(names, random);
        var secondName = ExtractRandomName(names, random);
        current.Add(Tuple.Create(firstName, secondName));
        return names.Count > 0 ? GeneratePairs(names, current) : current;
    }

    private static string ExtractRandomName(List<string> names, Random random)
    {
        var name = names[random.Next(names.Count)];
        names.Remove(name);
        return name;
    }

    private static List<string> ReadFile(string v)
    {
        // list only
        return new string[] { "A", "B", "C", "D" }.ToList();
    }
}