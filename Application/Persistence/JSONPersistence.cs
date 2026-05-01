using System;
using System.IO;
using System.Text.Json;

namespace Restaurant.Persistence;

public class JSONPersistence
{
    private JsonSerializerOptions _jsonOptions;

    public JSONPersistence()
    {
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };
    }

    public T? Load<T>(string filename)
    {
        string filePath = GetFilePath(filename);
        if (!File.Exists(filePath))
        {
            // Returns null but in a generic method
            return default(T);
        }

        string json = File.ReadAllText(filePath);
        T? data = JsonSerializer.Deserialize<T>(json, _jsonOptions);
        return data;
    }

    public void Save<T>(T data, string filename)
    {
        string filePath = GetFilePath(filename);
        string json = JsonSerializer.Serialize(data, _jsonOptions);
        File.WriteAllText(filePath, json);
    }

    private string GetFilePath(string filename)
    {
        return Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Assets", filename);
    }
}