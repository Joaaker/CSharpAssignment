using Shared.Interface;
using Shared.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Shared.Repositories;

public class ContactRepository(IFileService fileService) : IContactRepository
{
    private readonly IFileService _fileService = fileService;

    public bool SaveContacts(List<ContactObjects> contacts)
    {
        try
        {
            var jsonData = JsonSerializer.Serialize(contacts);
            _fileService.SaveContentToFile(jsonData);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
    public List<ContactObjects>? GetContacts()
    {
        try
        {
            var jsonData = _fileService.GetContentFromFile();
            var contacts = JsonSerializer.Deserialize<List<ContactObjects>>(jsonData);
            return contacts ?? [];
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return [];
        }
    }
}