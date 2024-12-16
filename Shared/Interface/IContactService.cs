using Shared.Models;

namespace Shared.Interface;

public interface IContactService
{
    bool AddContact(ContactObjects contact);
    ContactObjects GetContactById(string id);
    IEnumerable<ContactObjects>? GetAllContacts();

    //Redigera en kontakt 

    //Radera en kontakt
}