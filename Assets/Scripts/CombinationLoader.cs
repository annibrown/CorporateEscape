using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CombinationLoader 
{
    private static string CombinationFileName = "combinations.txt";
    private static string CombinationFolderName = "Assets/Text";

    private static string CombinationPath
    {
        get
        {
            return Path.Combine(CombinationFolderName, CombinationFileName);
        }
       
    }
    public static List<int> Load(List<int> defaultCombination)
    {
        EnsureFileExists(defaultCombination);
        return ReadCombinationFromFile();
    }

    private static void EnsureFileExists(List<int> defaultCombination)
    {
        if (!File.Exists(CombinationPath))
            CreateFile(defaultCombination);
    }

    private static void CreateFile(List<int> defaultCombination)
    {

        EnsureDirectoryExists();
        StreamWriter writer = new StreamWriter(CombinationPath);
        foreach (int combinationEntry in defaultCombination)
        {
            writer.WriteLine(combinationEntry);
        }
        writer.Close();
    }

    private static void EnsureDirectoryExists()
    {
        if (!Directory.Exists(CombinationFolderName))
            Directory.CreateDirectory(CombinationFolderName);
    }
    public static List<int> ReadCombinationFromFile()
    {
        List<int> combination = new List<int>();

        StreamReader reader = new StreamReader(CombinationPath);
        string combinationNumber = string.Empty;
        while ((combinationNumber = reader.ReadLine()) != null)
        {
            int combinationInteger = int.Parse(combinationNumber);
            combination.Add(combinationInteger);
        }
            
        return combination;
    }


    
}