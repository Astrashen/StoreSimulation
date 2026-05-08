using System;
using System.IO;
using System.Text.Json;
using Globals; 

public static class SaveSystem
{
    private static string savePath = "Players_save.json";

    public static void DeleteSave()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            Console.WriteLine("\n[Success] Progress Deleted.");
        }
        else
        {
            Console.WriteLine("\n[Info] No save file found to delete.");
        }
        System.Threading.Thread.Sleep(1000);
    }
    public static void SavePlayers()
    {
        try
        {
            // Serialize the Players object to a string
            string json = JsonSerializer.Serialize(PlayerEntity.MainPlayer);
            
            // Write the string to the disk
            File.WriteAllText(savePath, json);
            
            Console.WriteLine("\n[Success] Progress saved to disk.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n[Error] Could not save game: {ex.Message}");
        }
        System.Threading.Thread.Sleep(1000);
    }

    public static void LoadPlayers()
    {
        if (!File.Exists(savePath))
        {
            Console.WriteLine("\n[Info] No existing save file found.");
            System.Threading.Thread.Sleep(1000);
            return;
        }

        try
        {
            string json = File.ReadAllText(savePath);
            
            Players? loadedPlayers = JsonSerializer.Deserialize<Players>(json);
        
            if (loadedPlayers != null)
            {
                PlayerEntity.MainPlayer = loadedPlayers;
                Console.WriteLine("\n[Success] Character loaded successfully!");
            }
            else
            {
                Console.WriteLine("\n[Warning] Save file was empty or invalid.");
            }
        }
        catch (JsonException)
        {
            Console.WriteLine("\n[Error] Save file is corrupted and cannot be read.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n[Error] Load failed: {ex.Message}");
        }
        
        System.Threading.Thread.Sleep(1000);
    }
}