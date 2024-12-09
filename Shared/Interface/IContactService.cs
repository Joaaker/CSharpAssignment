using Shared.Models;

namespace Shared.Interface;

public interface IContactService
{
    void AddContact(ContactObjects contact);
    ContactObjects GetContactById(string id);
    List<ContactObjects> GetAllContacts();

    //Redigera en kontakt 

    //Radera en kontakt
}
