using Shared.Models;

namespace Shared.Interface
{
    public interface IContactRepository
    {
        List<ContactObjects>? GetContacts();
        bool SaveContacts(List<ContactObjects> contact);
    }
}