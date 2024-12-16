using Moq;
using Shared.Interface;
using Shared.Services;

namespace Shared_Tests.Services;

public class FileService_Tests
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly IFileService _fileService;

    public FileService_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
        _fileService = _fileServiceMock.Object;
    }
    [Fact]
    public void SaveContentToFile_ShouldReturnTrue()
    {
        // arange
        _fileServiceMock.Setup(fs => fs.SaveContentToFile(It.IsAny<string>())).Returns(true);

        // act
        var result = _fileService.SaveContentToFile("");

        // assert
        Assert.True(result);
    }
    [Fact]
    public void GetContentFromFile_ShouldReturnContentAsString()
    {
        // arrange
        _fileServiceMock.Setup(fs => fs.GetContentFromFile()).Returns("test");

        // act
        var result = _fileService.GetContentFromFile();

        // assert
        Assert.Equal("test", result);
    }
}
