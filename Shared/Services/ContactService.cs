using System.Diagnostics;
using Shared.Interface;
using Shared.Models;

namespace Shared.Services;

public class ContactService : IContactService
{
    public readonly List<ContactObjects> contacts = [];
    public void AddContact(ContactObjects contact)
    {
        if (contact == null)
            throw new ArgumentNullException(nameof(contact), "User cannot be null");

        if (contacts.Any(u => u.Id == contact.Id))
            throw new InvalidOperationException($"User with ID {contact.Id} already exists.");

        contacts.Add(contact);

    }
    public ContactObjects GetContactById(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentNullException(nameof(id), "ID cannot be null or empty");

        try
        {
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
        return new List<ContactObjects>(contacts);
    }

    //Redigera en kontakt 

    //Radera en kontakt
}
