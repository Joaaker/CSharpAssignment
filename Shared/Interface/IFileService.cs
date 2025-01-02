namespace Shared.Interface;

public interface IFileService
{
    bool SaveContentToFile(string content);
    string? GetContentFromFile();
}