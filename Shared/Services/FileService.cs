using System.Diagnostics;
using Shared.Interface;

namespace Shared.Services;

public class FileService(string directoryPath = "Data", string filePath = "list.json") : IFileService
{
    private readonly string _filePath = Path.Combine(directoryPath, filePath);

    public bool SaveContentToFile(string content)
    {
        try
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);


            if (!string.IsNullOrWhiteSpace(content))
            {
                File.WriteAllText(_filePath, content);
                return true;
            }else 
                return false;
        }
        catch (Exception ex) 
        { 
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public string GetContentFromFile()
    {
        try
        {
            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath, "[]");

            return File.ReadAllText(_filePath);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }
}