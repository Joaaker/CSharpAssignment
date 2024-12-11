using System.Diagnostics;
using Shared.Interface;
using Shared.Models;

namespace Shared.Services;

public class ContactService(IFileService fileService) : IContactService
{
    private readonly IFileService _fileService = fileService;

    public void AddContact(ContactObjects contact)
    {
        if (contact == null)
            throw new ArgumentNullException(nameof(contact), "User cannot be null");

        /* Detta är genererat av ChatGPT o1 
         * Denna kod hämtar kontaktlistan, kontrollerar så en med samma ID inte existerar, 
         * sedan lägger till den nya kontakten och sedan sparar den uppdaterade listan */
        var contacts = _fileService.ReadContactsFromFile();
        if (contacts.Any(u => u.Id == contact.Id))
            throw new InvalidOperationException($"User with ID {contact.Id} already exists.");

        contacts.Add(contact);
        _fileService.SaveContactsToFile(contacts);
    }
    public ContactObjects GetContactById(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentNullException(nameof(id), "ID cannot be null or empty");

        try
        {
            /* Detta är genererat av ChatGPT o1 
            * Denna kod hämtar kontaktlistan från json filen, kontrollerar så ID matchar 
            * och returnerar contact eller ger en Exception om det blir något fel  */
            var contacts = _fileService.ReadContactsFromFile();
            var contact = contacts.FirstOrDefault(u => u.Id == id);
            return contact ?? throw new ArgumentException("A contact with that ID was not found.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            throw new ApplicationException("An unexpected error occurred while retrieving the contact.", ex);
        }
    }

    public List<ContactObjects> GetAllContacts()
    { 
        return _fileService.ReadContactsFromFile();
    }

    //Redigera en kontakt 

    //Radera en kontakt
}
