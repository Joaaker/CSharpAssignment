using Shared.Factories;
using Shared.Models;

namespace Shared_Tests.Factories;

public class ContactFactory_Tests

    /* Detta är genererat av Chat GPT o1 - 
     * Denna kod kör ett test av ContactFactory där den skickar in värden och kollar så att den får tillbaka korrekt information  */
{
    [Fact]
    public void CreateContact_ShouldReturnValidContactObject()
    {
        // Arrange
        string firstName = "John";
        string lastName = "Doe";
        string email = "john.doe@domain.com";
        string phoneNumber = "1234567890";
        string address = "Street 1";
        string zipCode = "123 45";
        string city = "City";

        // Act
        ContactObjects contact = ContactFactory.CreateContact(firstName, lastName, email, phoneNumber, address, zipCode, city);

        // Assert
        Assert.NotNull(contact);
        Assert.False(string.IsNullOrEmpty(contact.Id));
        Assert.Equal(firstName, contact.FirstName);
        Assert.Equal(lastName, contact.LastName);
        Assert.Equal(email, contact.Email);
        Assert.Equal(phoneNumber, contact.PhoneNumber);
        Assert.Equal(address, contact.Address);
        Assert.Equal(zipCode, contact.ZipCode);
        Assert.Equal(city, contact.City);
        Assert.True(contact.DateCreated <= DateTime.Now);
    }
}