using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

public class RandomUtil
{
    public static void Main(string[] args)
    {
        // TODO: check if filename arg provided
        var names = ReadFile(args[0]);
        var fileNameWithoutExtension = args[0].Split('.')[0];
        WriteDraws(fileNameWithoutExtension, GeneratePairs(names, new List<Tuple<string, string>>()));
    }

    private static void WriteDraws(string fileNamePrefix, List<Tuple<string, string>> draws)
    {
        using (var writer = new StreamWriter(File.Create($"{fileNamePrefix}-Draws.txt")))
        {
            int i = 1;
            foreach (var draw in draws)
            {
                writer.WriteLine($"{i++}. {draw.Item1}, {draw.Item2}");
            }
        }
    }

    private static List<Tuple<string,string>> GeneratePairs(List<string> names, List<Tuple<string,string>> current)
    {
        if (names.Count == 1) // random person leftover from the draw
        {
            current.Add(Tuple.Create(names.Single(), string.Empty));
            names.Clear();
            return current;
        }

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

    private static List<string> ReadFile(string fileName)
    {
        var lines = new List<string>(); 
        using (var file = File.OpenText(fileName))
        {
            while (!file.EndOfStream)
            {
                var lineText = file.ReadLine();
                if (!string.IsNullOrWhiteSpace(lineText))
                {
                    lines.Add(lineText);
                }
            }
        }
        return lines;
    }
}