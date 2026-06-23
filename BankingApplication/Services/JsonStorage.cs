using System;
using System.IO;
using System.Text.Json;

static class JsonStorage
{
    public static BankData Data { get; private set; } = new BankData();

    public static void Load()
    {
        try
        {
            if (File.Exists("bank.json"))
            {
                string text = File.ReadAllText("bank.json");
                Data = JsonSerializer.Deserialize<BankData>(text) ?? new BankData();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("ფაილის წაკითხვა ვერ მოხერხდა");
            Logger.Log("LoadJson შეცდომა: " + ex.Message);
        }
    }

    public static void Save()
    {
        try
        {
            string text = JsonSerializer.Serialize(Data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("bank.json", text);
            Logger.Log("bank.json შენახულია");
        }
        catch (Exception ex)
        {
            Console.WriteLine("ფაილის შენახვა ვერ მოხერხდა");
            Logger.Log("SaveJson შეცდომა: " + ex.Message);
        }
    }
}
