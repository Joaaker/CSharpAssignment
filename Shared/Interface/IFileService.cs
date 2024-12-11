using Shared.Models;

namespace Shared.Interface;

public interface IFileService
{
    void SaveContactsToFile(List<ContactObjects> contactList);
    List<ContactObjects> ReadContactsFromFile();
}
