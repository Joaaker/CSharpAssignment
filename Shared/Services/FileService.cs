using System.Diagnostics;
using System.Text.Json;
using Shared.Interface;
using Shared.Models;

namespace Shared.Services;

public class FileService : IFileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;
    private readonly JsonSerializerOptions _jsonOptions;

    public FileService(string directoryPath = "Data", string filePath = "list.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(directoryPath, filePath);
        _jsonOptions = new JsonSerializerOptions { WriteIndented = true };
    }

    public void SaveContactsToFile(List<ContactObjects> contactList)
    {
        try
        {
            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);
            
            string jsonData = JsonSerializer.Serialize(contactList, _jsonOptions);
            File.WriteAllText(_filePath, jsonData);
        }
        catch (Exception ex) 
        { 
            Debug.WriteLine(ex.Message);
        }
        
    }

    public List<ContactObjects> ReadContactsFromFile()
    {
        try
        {
            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath, "[]");

            string fileContent = File.ReadAllText(_filePath);
            List<ContactObjects>? contactList = JsonSerializer.Deserialize<List<ContactObjects>>(fileContent, _jsonOptions);

            return contactList ?? [];
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return [];
        }
    }
}