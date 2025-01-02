using Shared.Helpers;
using Shared.Models;

namespace Shared.Factories;

public static class ContactFactory
{
    public static ContactObjects CreateContact(string firstName, string lastName, string email, string phoneNumber, string address, string zipCode, string city)
    {
        string id = UniqueIdentifierGenerator.Generate();
        return new ContactObjects(id, firstName, lastName, email, phoneNumber, address, zipCode, city);
    }
}