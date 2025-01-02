using Moq;
using Shared.Interface;
using Shared.Models;
using Shared.Repositories;
using System.Text.Json;

namespace Shared_Tests.Repositories;

public class ContactRepository_Tests
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly ContactRepository _contactRepository;

    public ContactRepository_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
        _contactRepository = new ContactRepository(_fileServiceMock.Object);
    }

    [Fact]
    public void GetContacts_ShouldReturnListOfContacts()
    {
        // arange
        var contacts = new List<ContactObjects>
        {
            new("abcd1234", "Pelle", "Svanslös", "pelle@domain.com", "123456789", "Gatan 1", "123 45", "Stockholm"),
            new("1234abcd", "Lille", "Skutt", "skutt@domain.com", "987654321", "Vägen 1", "54 321", "Göteborg")
        };
        var jsonData = JsonSerializer.Serialize(contacts);
        _fileServiceMock.Setup(fs => fs.GetContentFromFile()).Returns(jsonData);

        // act
        var result = _contactRepository.GetContacts();

        // assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Contains(result, c => c.Id == "abcd1234");
        Assert.Contains(result, c => c.Id == "1234abcd");
    }
    [Fact]
    public void SaveContacts_ShouldReturnTrue_WhenContactsAreSavedSuccessfully()
    {
        // arrange
        var contacts = new List<ContactObjects>
        {
            new("abcd1234", "Pelle", "Svanslös", "pelle@domain.com", "123456789", "Gatan 1", "123 45", "Stockholm"),
            new("1234abcd", "Lille", "Skutt", "skutt@domain.com", "987654321", "Vägen 1", "54 321", "Göteborg")
        };
        _fileServiceMock.Setup(fs => fs.SaveContentToFile(It.IsAny<string>())).Returns(true);

        // act
        var result = _contactRepository.SaveContacts(contacts);

        // assert
        Assert.True(result);
    }
}