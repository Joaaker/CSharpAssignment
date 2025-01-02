using Moq;
using Shared.Interface;
using Shared.Services;
using Shared.Models;

namespace Shared_Tests.Services;

public class ContactService_Tests
{
    private readonly Mock<IContactRepository> _contactRepositoryMock;
    private readonly ContactService _contactService;

    public ContactService_Tests()
    {
        _contactRepositoryMock = new Mock<IContactRepository>();
        _contactService = new ContactService(_contactRepositoryMock.Object);
    }
    [Fact]
    public void AddContact_ShouldReturnTrue_WhenSuccess()
    {
        // arrange
        var contact = new ContactObjects("abcd1234","Pelle", "Svanslös", "pelle@domain.com", "123456789", "Gatan 1", "123 45", "Stockholm");
        _contactRepositoryMock.Setup(x => x.SaveContacts(It.IsAny<List<ContactObjects>>())).Returns(true);

        // act
        var result = _contactService.AddContact(contact);

        // assert
        Assert.True(result);
    }

    [Fact]
    public void GetAllContacts_ShouldReturnList()
    {
        // arange
        var expectedContacts = new List<ContactObjects>
        {
            new("abcd1234", "Pelle", "Svanslös", "pelle@domain.com", "123456789", "Gatan 1", "123 45", "Stockholm"),
            new("1234abcd", "Lille", "Skutt", "skutt@domain.com", "987654321", "Vägen 1", "54 321", "Göteborg")
        };
        _contactRepositoryMock.Setup(c => c.GetContacts()).Returns(expectedContacts);

        // act
        var result = _contactService.GetAllContacts();

        // assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Contains(result, c => c.Id == "abcd1234");
        Assert.Contains(result, c => c.Id == "1234abcd");
    }

    [Fact]
    public void GetContactById_ShouldReturnContact()
    {
        // arrange
        var expectedContact = new ContactObjects("1234abcd", "Lille", "Skutt", "skutt@domain.com", "987654321", "Vägen 1", "54 321", "Göteborg");
        var contacts = new List<ContactObjects> { expectedContact };
        _contactRepositoryMock.Setup(r => r.GetContacts()).Returns(contacts);

        // act
        var result = _contactService.GetContactById("1234abcd");

        // assert
        Assert.NotNull(result);
        Assert.Equal("1234abcd", result.Id);
        Assert.Equal("Lille", result.FirstName);
        Assert.Equal("Skutt", result.LastName);
        Assert.Equal("skutt@domain.com", result.Email);
        Assert.Equal("987654321", result.PhoneNumber);
        Assert.Equal("Vägen 1", result.Address);
        Assert.Equal("54 321", result.ZipCode);
        Assert.Equal("Göteborg", result.City);
    }
}
